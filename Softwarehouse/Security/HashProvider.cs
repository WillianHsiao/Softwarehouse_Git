using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Security.Enums;

namespace Security
{
    public sealed class HashProvider : IHashProvider
    {
        private readonly IHashProvider _hashProvider;
        private readonly RNGCryptoServiceProvider _randomGenerator = new RNGCryptoServiceProvider();

        private static readonly IDictionary<HashAlgorithmKind, Func<HashAlgorithm>> AlgByKind =
            new Dictionary<HashAlgorithmKind, Func<HashAlgorithm>>
            {
                {HashAlgorithmKind.Md5, () => new MD5CryptoServiceProvider()},
                {HashAlgorithmKind.Sha1, () => new SHA1CryptoServiceProvider()},
                {HashAlgorithmKind.Sha256, () => new SHA256Managed()},
                {HashAlgorithmKind.Sha384, () => new SHA384Managed()},
                {HashAlgorithmKind.Sha512, () => new SHA512Managed()}
            };

        public HashProvider()
        {
            _hashProvider = this;
        }

        string IHashProvider.Hash(string plainText, HashAlgorithmKind algorithm, HashStringKind kind, Encoding encoding)
        {
            Func<HashAlgorithm> func;
            if (AlgByKind.TryGetValue(algorithm, out func))
            {
                var data = encoding.GetBytes(plainText);

                var hash = func().ComputeHash(data);
                switch (kind)
                {
                    case HashStringKind.Base64:
                        return hash.ToBase64String();

                    case HashStringKind.Hex:
                        return hash.ToHexString();
                }
            }
            throw new ArgumentException("Unknown hash algorithm " + algorithm);
        }

        string IHashProvider.Hash(string plainText, HashAlgorithmKind algorithm, HashStringKind kind)
        {
            return _hashProvider.Hash(plainText, algorithm, kind, Encoding.UTF8);
        }

        byte[] IHashProvider.Hash(byte[] data, byte[] salt, HashAlgorithmKind algorithm)
        {
            Func<HashAlgorithm> func;
            if (AlgByKind.TryGetValue(algorithm, out func))
            {
                return func().ComputeHash(BinaryUtil.ConcatinateBytes(salt, data));
            }
            throw new ArgumentException("Unknown hash algorithm " + algorithm);
        }

        byte[] IHashProvider.GenerateRandomString(ushort length)
        {
            if (length == 0) throw new ArgumentException("Length of random bytes generated cannot be 0");

            var bytes = new byte[length];
            _randomGenerator.GetNonZeroBytes(bytes);
            return bytes;
        }
    }
}
