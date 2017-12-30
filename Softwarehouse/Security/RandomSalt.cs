using System;
using System.Linq;

namespace Security
{
    public class RandomSalt
    {
        /// <summary>
        /// 取得隨機整數
        /// </summary>
        /// <returns></returns>
        public int GetRandomInteger()
        {
            Random random = new Random();
            return random.Next(50);
        }
        /// <summary>
        /// 取得隨機亂數
        /// </summary>
        /// <returns></returns>
        public string GetRandomSaltString()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var Length = GetRandomInteger();
            var result = new string(Enumerable.Repeat(chars, Length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            if (string.IsNullOrWhiteSpace(result) || result.Length <= 5)
                return GetRandomSaltString();
            else return result;
        }
    }
}
