using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Core;
using Framework.Exceptions;

namespace Testing
{
    [TestClass]
    public class VocabularyBuilderTests
    {
        [TestMethod]
        public void FullConstructor()
        {
            VocabularyBuilder vb = new VocabularyBuilder();
            vb.GenerateId();
            vb.SetName("Fire");
            vb.AddSynonym("Heat");
            vb.SetType(TypeOfSpeech.Noun);
            vb.SetReading("火");
            vb.SetLevel(5);
            vb.SetNoKanjiReading("ひ");
            vb.AddUsedKanji("K10");
            Vocabulary vocab = vb.ToVocabulary();
            Assert.AreEqual("Fire", vocab.Name);
        }

        [TestMethod]
        public void CtorNoOptionals()
        {
            VocabularyBuilder vb = new VocabularyBuilder();
            vb.GenerateId();
            vb.SetName("Fire");
            vb.SetReading("火");
            vb.SetLevel(5);
            vb.SetNoKanjiReading("ひ");
            Vocabulary vocab = vb.ToVocabulary();
            Assert.AreEqual(0, vocab.Synynoms.Count);
            Assert.AreEqual(TypeOfSpeech.Unknown, vocab.Type);
            Assert.AreEqual(0, vocab.UsedKanji.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(BuilderException))]
        public void CtorNotCompleted()
        {
            VocabularyBuilder vb = new VocabularyBuilder();
            vb.ToVocabulary();
        }

        [TestMethod]
        [ExpectedException(typeof(IdentifierException))]
        public void BadUsedKanjiId()
        {
            VocabularyBuilder vb = new VocabularyBuilder();
            vb.AddUsedKanji("20");
        }
    }
}
