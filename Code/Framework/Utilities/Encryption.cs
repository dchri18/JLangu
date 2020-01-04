using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Framework.Utilities
{
    public static class Encryption
    {
        private static byte[] _key;
        private static byte[] _iv;

        /// <summary>
        /// Initialises the Encryption class with a Key and Initialisation Vector.
        /// </summary>
        /// <param name="key">The Key.</param>
        /// <param name="iv">The Initialisation Vector.</param>
        public static void Initialise(byte[] key, byte[] iv)
        {
            _key = key;
            _iv = iv;
        }

        /// <summary>
        /// Using AES - the string plaintext is encrypted to a byte stream.
        /// </summary>
        /// <param name="plaintext">The string to encrypt.</param>
        /// <returns>The Encrypted string.</returns>
        public static byte[] EncryptString(string plaintext)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;

                ICryptoTransform encrypter = aes.CreateEncryptor(_key, _iv);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypter, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plaintext);
                        }

                        return msEncrypt.ToArray();
                    }
                }
            }
        }
        
        /// <summary>
        /// Using AES - the byte stream is decrypted and returned as a string.
        /// </summary>
        /// <param name="ciphertext">The byte stream to decrypt.</param>
        /// <returns>The decrypted string.</returns>
        public static string DecryptString(byte[] ciphertext)
        {
            string plaintext = null;

            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;

                ICryptoTransform decrypter = aes.CreateDecryptor(_key, _iv);

                using (MemoryStream msDecrypt = new MemoryStream(ciphertext))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decrypter, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
