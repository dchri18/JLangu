using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core
{
    /// <summary>
    /// Standard Object containing all static data related to a particular piece of Japanese Vocabulary.
    /// </summary>
    class Vocabulary : IVocabulary
    {
        /// <summary>
        /// The unique identifier of the object for the entire project.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The english reading of the vocabulary.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Alternative English ways of reading the vocabulary.
        /// </summary>
        public string[] Synynoms { get; }

        /// <summary>
        /// The type of speech the vocabulary falls under.
        /// </summary>
        public TypeOfSpeech Type { get; }

        /// <summary>
        /// The Japanese way of reading the vocabulary.
        /// </summary>
        public string Reading { get; }

        /// <summary>
        /// The Hiragana or Katakana only reading of the word.
        /// </summary>
        public string NoKanjiReading { get; }

        /// <summary>
        /// Kanji used in the normal reading of the vocabulary.
        /// </summary>
        public string[] UsedKanji { get; }

        /// <summary>
        /// Basic constructor used to create a Vocabulary Object.
        /// </summary>
        /// <param name="id">The unique identifier of the object for the entire project.</param>
        /// <param name="name">The english reading of the vocabulary.</param>
        /// <param name="synynoms">Alternative English ways of reading the vocabulary.</param>
        /// <param name="type">The type of speech the vocabulary falls under.</param>
        /// <param name="reading">The Japanese way of reading the vocabulary.</param>
        /// <param name="NoKanjiReading">The Hiragana or Katakana only reading of the word.</param>
        /// <param name="usedKanji">Kanji used in the normal reading of the vocabulary.</param>
        public Vocabulary(int id, string name, string[] synynoms, TypeOfSpeech type, string reading, string noKanjiReading, string[] usedKanji)
        {
            Id = id;
            Name = name;
            Synynoms = synynoms;
            Type = type;
            Reading = reading;
            NoKanjiReading = noKanjiReading;
            UsedKanji = usedKanji;
        }

        public override string ToString()
        {
            return Reading;
        }
    }
}
