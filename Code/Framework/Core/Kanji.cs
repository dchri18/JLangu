using System;
using System.Collections.Generic;
using System.Text;
using Framework.Utilities;
using Framework.Exceptions;

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
        /// List of Ids of all Kanji that are visually similar.
        /// </summary>
        public List<string> VisuallySimilarKanji { get; private set; }

        /// <summary>
        /// List of Ids of all Japanese Vocabulary that use this Kanji.
        /// </summary>
        public List<string> FoundInVocabulary { get; private set; }

        /// <summary>
        /// Indicates when the Kanji should be unlocked based on the Users level.
        /// </summary>
        public int Level { get; }

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
        public Kanji(string id, string name, string symbol, List<string> onyomiReadings, List<string> kunyomiReadings, int level,
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
            Level = level;
        }

        public override string ToString()
        {
            return Symbol;
        }

        /// <summary>
        /// Adds the Id of another Kanji object that looks similar to this one.
        /// </summary>
        /// <param name="id">The Id of the other Kanji.</param>
        public void AddVisuallySimilarKanji(string id)
        {
            if (!Identifier.IsForKanji(id))
            {
                throw new IdentifierException($"Invalid identifier for Kanji:<{ id}>");
            }

            VisuallySimilarKanji.Add(id);
        }

        /// <summary>
        /// Adds the Id of another Vocabulary that uses this Kanji.
        /// </summary>
        /// <param name="id">The Id of the Vocabulary.</param>
        public void AddFoundInVocabulary(string id)
        {
            if (!Identifier.IsForVocab(id))
            {
                throw new IdentifierException($"Invalid identifier for Vocabulary:<{id}>");
            }

            FoundInVocabulary.Add(id);
        }

        /// <summary>
        /// Remove the Id of a visually similar Kanji.
        /// </summary>
        /// <param name="id">The Id of the visually similar kanji to be removed.</param>
        public void RemoveVisuallySimilarKanji(string id)
        {
            if (!Identifier.IsForKanji(id))
            {
                throw new IdentifierException($"Invalid identifier for Kanji:<{ id}>");
            }

            VisuallySimilarKanji.Remove(id);
        }
        
        /// <summary>
        /// Remove the Id of the Vocabulary this Kanji is found in.
        /// </summary>
        /// <param name="id">The Id of the vocabulary to be removed from this reference.</param>
        public void RemoveFoundInVocabulary(string id)
        {
            if (!Identifier.IsForVocab(id))
            {
                throw new IdentifierException($"Invalid identifier for Vocabulary:<{id}>");
            }

            FoundInVocabulary.Remove(id);
        }

        /// <summary>
        /// Clear all Ids of visually similar Kanji.
        /// </summary>
        public void ClearVisuallySimilarKanji()
        {
            VisuallySimilarKanji.Clear();
        }

        /// <summary>
        /// Clear all Ids of Vocabulary this Kanji is found in.
        /// </summary>
        public void ClearFoundInVocabulary()
        {
            FoundInVocabulary.Clear();
        }
    }
}
