using System.Text;
using Security.Enums;

namespace Security
{
    public interface IHashProvider
    {
        string Hash(string plainText, HashAlgorithmKind algorithm, HashStringKind kind, Encoding encoding);

        string Hash(string plainText, HashAlgorithmKind algorithm, HashStringKind kind);

        byte[] Hash(byte[] data, byte[] salt, HashAlgorithmKind algorithm);

        byte[] GenerateRandomString(ushort length);
    }
}