using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Security
{
    public static class Encrypt
    {
        private static string strKey = "SOFTWAREHOUSEAPP";

        private static string strIV = "SOFTWAREHOUSEAPP";
        /// <summary>
        /// SHA512加密
        /// </summary>
        /// <param name="inputPassword"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string EncryptSHA512(string inputPassword, string salt)
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
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="_strQ"></param>
        /// <returns></returns>
        public static string AESEncrypt(string _strQ)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(_strQ);
            MemoryStream ms = new MemoryStream();
            AesCryptoServiceProvider taes = new AesCryptoServiceProvider();
            CryptoStream encStream =
                new CryptoStream(ms, taes.CreateEncryptor(Encoding.UTF8.GetBytes(strKey), Encoding.UTF8.GetBytes(strIV)), CryptoStreamMode.Write);
            encStream.Write(buffer, 0, buffer.Length);
            encStream.FlushFinalBlock();
            return HttpUtility.UrlEncode(Convert.ToBase64String(ms.ToArray()));
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="_strQ"></param>
        /// <returns></returns>
        public static string AESDecrypt(string _strQ)
        {
            byte[] buffer = Convert.FromBase64String(_strQ);
            MemoryStream ms = new MemoryStream();
            AesCryptoServiceProvider taes = new AesCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(ms, taes.CreateDecryptor(Encoding.UTF8.GetBytes(strKey), Encoding.UTF8.GetBytes(strIV)), CryptoStreamMode.Write);
            encStream.Write(buffer, 0, buffer.Length);
            encStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);

        }
    }
}
