using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Services
{
    public static class EncryptionService
    {
        private static readonly string key = "YourSecretKey123"; // В реальном приложении следует хранить ключ безопасно

        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key.PadRight(32));
                aes.Key = keyBytes;
                aes.IV = new byte[16];

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key.PadRight(32));
                aes.Key = keyBytes;
                aes.IV = new byte[16];

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
} 