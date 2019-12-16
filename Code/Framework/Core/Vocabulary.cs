using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core
{
    /// <summary>
    /// Standard Object containing all static data related to a particular piece of Japanese Vocabulary.
    /// </summary>
    public class Vocabulary : IVocabulary
    {
        /// <summary>
        /// The unique identifier of the object for the entire project.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The english reading of the vocabulary.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Alternative English ways of reading the vocabulary.
        /// </summary>
        public List<string> Synynoms { get; }

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
        /// Id of Kanji used in the normal reading of the vocabulary.
        /// </summary>
        public List<string> UsedKanji { get; }

        /// <summary>
        /// Basic constructor used to create a Vocabulary Object.
        /// </summary>
        /// <param name="id">The unique identifier of the object for the entire project.</param>
        /// <param name="name">The english reading of the vocabulary.</param>
        /// <param name="synynoms">Alternative English ways of reading the vocabulary.</param>
        /// <param name="type">The type of speech the vocabulary falls under.</param>
        /// <param name="reading">The Japanese way of reading the vocabulary.</param>
        /// <param name="NoKanjiReading">The Hiragana or Katakana only reading of the word.</param>
        /// <param name="usedKanji">Id of Kanji used in the normal reading of the vocabulary.</param>
        public Vocabulary(string id, string name, TypeOfSpeech type, string reading, string noKanjiReading, List<string> usedKanji = null, List<string> synynoms = null)
        {
            Id = id;
            Name = name;
            Synynoms = synynoms ?? new List<string>();
            Type = type;
            Reading = reading;
            NoKanjiReading = noKanjiReading;
            UsedKanji = usedKanji ?? new List<string>();
        }

        public override string ToString()
        {
            return Reading;
        }
    }
}
