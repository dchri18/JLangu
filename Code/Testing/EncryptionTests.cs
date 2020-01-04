using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Framework.Utilities.Encryption;

namespace Testing
{
    [TestClass]
    public class EncryptionTests
    {
        [TestMethod]
        public void EncryptAndDecrypt()
        {
            byte[] key = Encoding.ASCII.GetBytes("CE0581F19725CA80C9C2F31BCF2E734A");
            byte[] iv = Encoding.ASCII.GetBytes("454CC630A49029B2");

            Initialise(key, iv);

            string plaintext = "Thisisateststring";

            byte[] ciphertext = EncryptString(plaintext);

            Assert.AreEqual(plaintext, DecryptString(ciphertext));
        }

        [TestMethod]
        public void FailEncryptAndDecrypt()
        {
            byte[] key = Encoding.ASCII.GetBytes("CE0581F19725CA80C9C2F31BCF2E734A");
            byte[] iv = Encoding.ASCII.GetBytes("454CC630A49029B2");

            Initialise(key, iv);

            string plaintext = "Thisisateststring";

            byte[] ciphertext = EncryptString(plaintext);

            Assert.AreNotEqual("Thisisateststring1", DecryptString(ciphertext));
        }
    }
}
