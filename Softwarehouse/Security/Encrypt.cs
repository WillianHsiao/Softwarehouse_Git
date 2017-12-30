using System.Security.Cryptography;
using System.Text;

namespace Security
{
    public class Encrypt
    {
        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="inputPassword"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public string EncryptSHA512(string inputPassword, string salt)
        {
            SHA512CryptoServiceProvider sha1Hasher = new SHA512CryptoServiceProvider();

            byte[] myData = sha1Hasher.ComputeHash(Encoding.Default.GetBytes(inputPassword + salt));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < myData.Length; i++)
            {
                sBuilder.Append(myData[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
