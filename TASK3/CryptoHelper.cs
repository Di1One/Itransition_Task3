using System.Security.Cryptography;
using System.Text;

namespace TASK3
{
    public class CryptoHelper
    {
        private RNGCryptoServiceProvider rng;

        public CryptoHelper()
        {
            rng = new RNGCryptoServiceProvider();
        }

        public byte[] GenerateKey()
        {
            byte[] key = new byte[64];
            rng.GetBytes(key);
            return key;
        }

        public string GenerateHMAC(byte[] key, string move)
        {
            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                byte[] moveBytes = Encoding.UTF8.GetBytes(move);
                byte[] hmacBytes = hmac.ComputeHash(moveBytes);
                return BitConverter.ToString(hmacBytes).Replace("-", "");
            }
        }
    }
}
