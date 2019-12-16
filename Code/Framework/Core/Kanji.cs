using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core
{
    /// <summary>
    /// Standard Object containing all static data related to a particular Kanji.
    /// </summary>
    public class Kanji : IVocabulary
    {
        /// <summary>
        /// The unqiue identifier for this Kanji.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The English name for this Kanji.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The actual Kanji symbol.
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// Other english meanings for this Kanji.
        /// </summary>
        public List<string> AlternativeMeanings { get; }

        /// <summary>
        /// All On'yomi readings for this Kanji in Hiragana.
        /// </summary>
        public List<string> OnyomiReadings { get; }

        /// <summary>
        /// All Kun'yomi readings for this Kanji.
        /// </summary>
        public List<string> KunyomiReadings { get; }

        /// <summary>
        /// Kanji that are visually similar.
        /// </summary>
        public List<string> VisuallySimilarKanji { get; }

        /// <summary>
        /// List of Ids of all Japanese Vocabulary that use this Kanji.
        /// </summary>
        public List<string> FoundInVocabulary { get; }

        /// <summary>
        /// Basic constructor for a Kanji Object.
        /// </summary>
        /// <param name="id">The unqiue identifier for this Kanji.</param>
        /// <param name="name">The English name for this Kanji.</param>
        /// <param name="symbol">The actual Kanji symbol.</param>
        /// <param name="alternativeMeanings">Other english meanings for this Kanji.</param>
        /// <param name="onyomiReadings">All On'yomi readings for this Kanji in Hiragana.</param>
        /// <param name="kunyomiReadings">All Kun'yomi readings for this Kanji.</param>
        /// <param name="visuallySimilarKanji">Ids of Kanji that are visually similar.</param>
        /// <param name="foundInVocabulary">Ids of all Japanese Vocabulary that use this Kanji.</param>
        public Kanji(string id, string name, string symbol, List<string> onyomiReadings, List<string> kunyomiReadings, 
            List<string> visuallySimilarKanji = null, List<string> foundInVocabulary = null, List<string> alternativeMeanings = null)
        {
            Id = id;
            Name = name;
            Symbol = symbol;
            AlternativeMeanings = alternativeMeanings ?? new List<string>();
            OnyomiReadings = onyomiReadings;
            KunyomiReadings = kunyomiReadings;
            VisuallySimilarKanji = visuallySimilarKanji ?? new List<string>();
            FoundInVocabulary = foundInVocabulary ?? new List<string>();
        }

        public override string ToString()
        {
            return Symbol;
        }
    }
}
