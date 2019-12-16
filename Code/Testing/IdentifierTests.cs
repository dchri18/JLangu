using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Utilities;
using Framework.Exceptions;

namespace Testing
{
    [TestClass]
    public class IdentifierTests
    {
        [TestMethod]
        public void IdentifierToInt()
        {
            string id = "K001";
            int newId = Identifier.IdentifierToInt(id);
            Assert.AreEqual(1, newId);
        }

        [TestMethod]
        [ExpectedException(typeof(IdentifierException))]
        public void IdentifierToIntFailed()
        {
            string id = "NoNo";
            int newId = Identifier.IdentifierToInt(id);
        }

        [TestMethod]
        public void CorrectKanjiId()
        {
            Assert.AreEqual(true, Identifier.IsForKanji("K091"));
        }

        [TestMethod]
        public void IncorrectKanjiId()
        {
            Assert.AreEqual(false, Identifier.IsForKanji("V091"));
        }

        [TestMethod]
        public void CorrectVocabId()
        {
            Assert.AreEqual(true, Identifier.IsForVocab("V091"));
        }

        [TestMethod]
        public void IncorrectVocabId()
        {
            Assert.AreEqual(false, Identifier.IsForVocab("K091"));
        }
    }
}
