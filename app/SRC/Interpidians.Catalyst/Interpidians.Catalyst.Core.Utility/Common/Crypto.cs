using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Interpidians.Catalyst.Core.Utility
{
    public static class Crypto
    {
        private static string _key = "TESLA";

        public static RijndaelManaged GetRijndaelManaged(String secretKey)
        {
            var keyBytes = new byte[16];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length));
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            try
            {
                rijndaelManaged.Mode = CipherMode.CBC;
                rijndaelManaged.Padding = PaddingMode.PKCS7;
                rijndaelManaged.KeySize = 128;
                rijndaelManaged.BlockSize = 128;
                rijndaelManaged.Key = keyBytes;
                rijndaelManaged.IV = keyBytes;
            }
            catch
            {
                if (rijndaelManaged != null)
                    rijndaelManaged.Dispose();
            }
            return rijndaelManaged;
        }

        private static byte[] Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateEncryptor()
                .TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }

        private static byte[] Decrypt(byte[] encryptedData, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateDecryptor()
                .TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }

        /// <summary>
        /// Encrypts plaintext using AES 128bit key and a Chain Block Cipher and returns a base64 encoded string
        /// </summary>
        /// <param name="plainText">Plain text to encrypt</param>
        /// <returns>Base64 encoded string</returns>
        public static String Encrypt(String plainText)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(Encrypt(plainBytes, GetRijndaelManaged(_key)));
        }

        /// <summary>
        /// Decrypts a base64 encoded string using the given key (AES 128bit key and a Chain Block Cipher)
        /// </summary>
        /// <param name="encryptedText">Base64 Encoded String</param>
        /// <returns>Decrypted String</returns>
        public static String Decrypt(String encryptedText)
        {
            try
            {
                var encryptedBytes = Convert.FromBase64String(encryptedText);
                return Encoding.UTF8.GetString(Decrypt(encryptedBytes, GetRijndaelManaged(_key)));
            }
            catch
            {
                return null;
            }
        }

        public static bool IsValidBase64String(string encryptedText)
        {
            try
            {
                var encryptedBytes = Convert.FromBase64String(encryptedText);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Dictionary<string, string> DecryptInKeyValue(string encryptedText)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            encryptedText = encryptedText.Replace('-', '=').Replace('_', '/').Replace(',', '+');
            string decryptedText = Decrypt(encryptedText);

            if (decryptedText != null)
            {
                string[] keyPair = decryptedText.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string key in keyPair)
                {
                    string[] keyValue = key.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    dictionary.Add(keyValue[0].ToUpper(), keyValue[1]);
                }
            }

            return dictionary;
        }

        public static string Encrypt(Dictionary<string, string> keyValue)
        {
            string encryptedText = string.Empty;

            foreach (KeyValuePair<string, string> key in keyValue)
            {
                encryptedText += key.Key + "=" + key.Value;
                encryptedText += ";";
            }

            encryptedText = Encrypt(encryptedText);

            return encryptedText.Replace('=', '-').Replace('/', '_').Replace('+', ',');
        }

        /// <summary>
        /// Encrypts the specified key value.
        /// </summary>
        /// <param name="keyValue">The key value.</param>
        /// <returns></returns>
        public static string Encrypt(string key, string value)
        {
            string encryptedText = key + "=" + value + ";"; ;
            encryptedText = Encrypt(encryptedText);
            return encryptedText.Replace('=', '-').Replace('/', '_').Replace('+', ',');
        }

        public static string Generatehash512(string text)
        {

            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;

        }
    }
}
