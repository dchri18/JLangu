using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Core;
using Framework.Exceptions;

namespace Testing
{
    [TestClass]
    public class KanjiBuilderTests
    {
        [TestMethod]
        public void FullConstructor()
        {
            KanjiBuilder kb = new KanjiBuilder();
            kb.GenerateId();
            kb.SetName("Fire");
            kb.SetSymbol("火");
            kb.AddAlternativeMeaning("Nothing");
            kb.AddOnyomiReading("か");
            kb.AddKunyomiReading("ひ");
            kb.AddKunyomiReading("ほ");
            kb.AddVisuallySimilarKanji("K010");
            kb.AddFoundInVocabulary("V110");
            Kanji kanji = kb.ToKanji();
            Assert.AreEqual("火", kanji.Symbol);
        }

        [TestMethod]
        public void CtorNoOptionals()
        {
            KanjiBuilder kb = new KanjiBuilder();
            kb.GenerateId();
            kb.SetName("Fire");
            kb.SetSymbol("火");
            kb.AddOnyomiReading("か");
            kb.AddKunyomiReading("ひ");
            kb.AddKunyomiReading("ほ");
            Kanji kanji = kb.ToKanji();
            Assert.AreEqual(0, kanji.FoundInVocabulary.Count);
            Assert.AreEqual(0, kanji.AlternativeMeanings.Count);
            Assert.AreEqual(0, kanji.VisuallySimilarKanji.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(BuilderException))]
        public void CtorNoCompleted()
        {
            KanjiBuilder kb = new KanjiBuilder();
            var kanji = kb.ToKanji();
        }

        [TestMethod]
        [ExpectedException(typeof(IdentifierException))]
        public void BadVisuallySimilarKanjiId()
        {
            KanjiBuilder kb = new KanjiBuilder();
            kb.GenerateId();
            kb.SetName("Fire");
            kb.SetSymbol("火");
            kb.AddAlternativeMeaning("Nothing");
            kb.AddOnyomiReading("か");
            kb.AddKunyomiReading("ひ");
            kb.AddKunyomiReading("ほ");
            kb.AddVisuallySimilarKanji("010");
        }

        [TestMethod]
        [ExpectedException(typeof(IdentifierException))]
        public void BadFoundInVocabularyId()
        {
            KanjiBuilder kb = new KanjiBuilder();
            kb.GenerateId();
            kb.SetName("Fire");
            kb.SetSymbol("火");
            kb.AddAlternativeMeaning("Nothing");
            kb.AddOnyomiReading("か");
            kb.AddKunyomiReading("ひ");
            kb.AddKunyomiReading("ほ");
            kb.AddFoundInVocabulary("110");
        }
    }
}
