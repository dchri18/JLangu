using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Core;
using Framework.Exceptions;

namespace Testing
{
    [TestClass]
    public class VocabularyTests
    {
        [TestMethod]
        public void AddUsedKanji()
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
            vocab.AddUsedKanji("K978");
            Assert.AreEqual("K978", vocab.UsedKanji[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IdentifierException))]
        public void AddUsedKanjiBadId()
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
            vocab.AddUsedKanji("999978");
        }

        [TestMethod]
        public void RemoveUsedKanji()
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
            vocab.RemoveUsedKanji("K10");
            Assert.AreEqual(0, vocab.UsedKanji.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IdentifierException))]
        public void RemoveUsedKanjiBadId()
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
            vocab.RemoveUsedKanji("8810");
        }

        [TestMethod]
        public void ClearUsedKanji()
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
            vocab.AddUsedKanji("K978");
            vocab.ClearUsedKanji();
            Assert.AreEqual(0, vocab.UsedKanji.Count);
        }
    }
}
