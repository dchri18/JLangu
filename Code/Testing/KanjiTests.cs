using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Framework.Core;
using Framework.Exceptions;

namespace Testing
{
    [TestClass]
    public class KanjiTests
    {
        [TestMethod]
        public void AddVisuallySimilarKanji()
        {
            KanjiBuilder kb = new KanjiBuilder();
            kb.GenerateId();
            kb.SetName("Fire");
            kb.SetSymbol("火");
            kb.SetLevel(5);
            kb.AddAlternativeMeaning("Nothing");
            kb.AddOnyomiReading("か");
            kb.AddKunyomiReading("ひ");
            kb.AddKunyomiReading("ほ");
            kb.AddFoundInVocabulary("V110");
            Kanji kanji = kb.ToKanji();
            kanji.AddVisuallySimilarKanji("K010");
            kanji.AddVisuallySimilarKanji("K908");
            Assert.AreEqual("K908", kanji.VisuallySimilarKanji[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IdentifierException))]
        public void AddVisuallySimilarKanjiBadId()
        {
            KanjiBuilder kb = new KanjiBuilder();
            kb.GenerateId();
            kb.SetName("Fire");
            kb.SetSymbol("火");
            kb.SetLevel(5);
            kb.AddAlternativeMeaning("Nothing");
            kb.AddOnyomiReading("か");
            kb.AddKunyomiReading("ひ");
            kb.AddKunyomiReading("ほ");
            kb.AddFoundInVocabulary("V110");
            Kanji kanji = kb.ToKanji();
            kanji.AddVisuallySimilarKanji("88010");
        }

        [TestMethod]
        public void RemoveVisuallySimilarKanji()
        {
            KanjiBuilder kb = new KanjiBuilder();
            kb.GenerateId();
            kb.SetName("Fire");
            kb.SetSymbol("火");
            kb.SetLevel(5);
            kb.AddAlternativeMeaning("Nothing");
            kb.AddVisuallySimilarKanji("K010");
            kb.AddOnyomiReading("か");
            kb.AddKunyomiReading("ひ");
            kb.AddKunyomiReading("ほ");
            kb.AddFoundInVocabulary("V110");
            Kanji kanji = kb.ToKanji();
            kanji.RemoveVisuallySimilarKanji("K010");
            Assert.AreEqual(0, kanji.VisuallySimilarKanji.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IdentifierException))]
        public void RemoveVisuallySimilarKanjiBadId()
        {
            KanjiBuilder kb = new KanjiBuilder();
            kb.GenerateId();
            kb.SetName("Fire");
            kb.SetSymbol("火");
            kb.SetLevel(5);
            kb.AddAlternativeMeaning("Nothing");
            kb.AddVisuallySimilarKanji("K010");
            kb.AddOnyomiReading("か");
            kb.AddKunyomiReading("ひ");
            kb.AddKunyomiReading("ほ");
            kb.AddFoundInVocabulary("V110");
            Kanji kanji = kb.ToKanji();
            kanji.RemoveVisuallySimilarKanji("6010");
        }

        [TestMethod]
        public void ClearVisuallySimilarKanji()
        {
            KanjiBuilder kb = new KanjiBuilder();
            kb.GenerateId();
            kb.SetName("Fire");
            kb.SetSymbol("火");
            kb.SetLevel(5);
            kb.AddAlternativeMeaning("Nothing");
            kb.AddVisuallySimilarKanji("K010");
            kb.AddVisuallySimilarKanji("K210");
            kb.AddVisuallySimilarKanji("K110");
            kb.AddOnyomiReading("か");
            kb.AddKunyomiReading("ひ");
            kb.AddKunyomiReading("ほ");
            kb.AddFoundInVocabulary("V110");
            Kanji kanji = kb.ToKanji();
            Assert.AreEqual(3, kanji.VisuallySimilarKanji.Count);
            kanji.ClearVisuallySimilarKanji();
            Assert.AreEqual(0, kanji.VisuallySimilarKanji.Count);
        }

        [TestMethod]
        public void AddFoundInVocab()
        {
            KanjiBuilder kb = new KanjiBuilder();
            kb.GenerateId();
            kb.SetName("Fire");
            kb.SetSymbol("火");
            kb.SetLevel(5);
            kb.AddAlternativeMeaning("Nothing");
            kb.AddOnyomiReading("か");
            kb.AddKunyomiReading("ひ");
            kb.AddKunyomiReading("ほ");
            kb.AddVisuallySimilarKanji("K010");
            kb.AddFoundInVocabulary("V110");
            Kanji kanji = kb.ToKanji();
            kanji.AddFoundInVocabulary("V789");
            Assert.AreEqual("V789", kanji.FoundInVocabulary[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IdentifierException))]
        public void AddFoundInVocabBadId()
        {
            KanjiBuilder kb = new KanjiBuilder();
            kb.GenerateId();
            kb.SetName("Fire");
            kb.SetSymbol("火");
            kb.SetLevel(5);
            kb.AddAlternativeMeaning("Nothing");
            kb.AddOnyomiReading("か");
            kb.AddKunyomiReading("ひ");
            kb.AddKunyomiReading("ほ");
            kb.AddVisuallySimilarKanji("K010");
            kb.AddFoundInVocabulary("V110");
            Kanji kanji = kb.ToKanji();
            kanji.AddFoundInVocabulary("88789");
        }

        [TestMethod]
        public void RemoveFoundInVocab()
        {
            KanjiBuilder kb = new KanjiBuilder();
            kb.GenerateId();
            kb.SetName("Fire");
            kb.SetSymbol("火");
            kb.SetLevel(5);
            kb.AddAlternativeMeaning("Nothing");
            kb.AddOnyomiReading("か");
            kb.AddKunyomiReading("ひ");
            kb.AddKunyomiReading("ほ");
            kb.AddVisuallySimilarKanji("K010");
            kb.AddFoundInVocabulary("V110");
            Kanji kanji = kb.ToKanji();
            kanji.RemoveFoundInVocabulary("V110");
            Assert.AreEqual(0, kanji.FoundInVocabulary.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IdentifierException))]
        public void RemoveFoundInVocabBadId()
        {
            KanjiBuilder kb = new KanjiBuilder();
            kb.GenerateId();
            kb.SetName("Fire");
            kb.SetSymbol("火");
            kb.SetLevel(5);
            kb.AddAlternativeMeaning("Nothing");
            kb.AddOnyomiReading("か");
            kb.AddKunyomiReading("ひ");
            kb.AddKunyomiReading("ほ");
            kb.AddVisuallySimilarKanji("K010");
            kb.AddFoundInVocabulary("V110");
            Kanji kanji = kb.ToKanji();
            kanji.AddFoundInVocabulary("9OO0");
        }

        [TestMethod]
        public void ClearFoundInVocab()
        {
            KanjiBuilder kb = new KanjiBuilder();
            kb.GenerateId();
            kb.SetName("Fire");
            kb.SetSymbol("火");
            kb.SetLevel(5);
            kb.AddAlternativeMeaning("Nothing");
            kb.AddOnyomiReading("か");
            kb.AddKunyomiReading("ひ");
            kb.AddKunyomiReading("ほ");
            kb.AddVisuallySimilarKanji("K010");
            kb.AddFoundInVocabulary("V110");
            Kanji kanji = kb.ToKanji();
            kanji.AddFoundInVocabulary("V789");
            kanji.ClearFoundInVocabulary();
            Assert.AreEqual(0, kanji.FoundInVocabulary.Count);
        }
    }
}
