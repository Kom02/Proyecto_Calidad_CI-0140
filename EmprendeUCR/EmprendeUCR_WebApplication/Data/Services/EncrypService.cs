using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class EncrypService
    {
        byte[] Key = { 55, 44, 195, 55, 222, 61, 56, 207, 192, 137, 79, 77, 80, 84, 123, 53, 41, 123, 159, 185, 44, 179, 112, 237, 85, 82, 226, 66, 122, 186, 204, 185 };
        byte[] IV = { 186, 64, 237, 198, 188, 85, 101, 152, 93, 165, 235, 75, 123, 140, 67, 216 };
        public string hashEmail(string email)
        {
            string hashEmail = "";
            if (string.IsNullOrEmpty(email))
            {
                hashEmail = "";
            }
            else
            {
                string salt = getSalt();
                var passwordBytes = Encoding.UTF8.GetBytes(salt + email);
                hashEmail = Convert.ToBase64String(passwordBytes);
            }
            return hashEmail;
        }

        public string getSalt() {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[15];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            string finalString = new String(stringChars);
            return finalString;
        }

        public string encryptPassword(string password) {
            string encriptPassword = "";

            if (!string.IsNullOrEmpty(password)) 
            {      
                byte[] encrypt = encryptStringToBytes_Aes(password, Key, IV);
                encriptPassword = Convert.ToBase64String(encrypt);
            }
            return encriptPassword;
        }

        public static byte[] encryptStringToBytes_Aes(string password, byte[] Key, byte[] IV)
        {
            if (password == null || password.Length <= 0)
                throw new ArgumentNullException("password");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(password);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }
    }
}
