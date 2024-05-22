using System.Security.Cryptography;
using System.Text;

namespace Ultilities
{
    public class EncryptExtensions
    {
        /// <summary>
        /// Băm chuỗi
        /// </summary>
        /// <param name="input">đầu vào</param>
        /// <param name="alg">Thuật toán băm</param>
        /// <returns></returns>
        public static string Hash(string input, HashAlgorithm alg)
        {
            if(alg== null)
            {
                alg = MD5.Create();
            }
            // Chuyển đổi chuỗi input thành mảng byte
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Băm mảng byte input
            byte[] hashedBytes = alg.ComputeHash(inputBytes);

            // Chuyển đổi mảng byte thành chuỗi hex
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                stringBuilder.Append(hashedBytes[i].ToString("x2")); // "x2" để chuyển đổi thành hex
            }

            // Trả về chuỗi đã băm
            return stringBuilder.ToString();
        }
    }
}
