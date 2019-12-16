using System;
using System.Collections.Generic;
using System.Text;
using Framework.Exceptions;
using Framework.Utilities;

namespace Framework.Core
{
    /// <summary>
    /// Disposable object that builds a Kanji Object.
    /// </summary>
    public class KanjiBuilder : IDisposable
    {
        private Kanji _kanji;
        private string _id;
        private string _name;
        private string _symbol;
        private List<string> _alternativeMeanings;
        private List<string> _onyomiReadings;
        private List<string> _kunyomiReadings;
        private List<string> _visuallySimilarKanji;
        private List<string> _foundInVocabulary;

        public KanjiBuilder()
        {

        }

        /// <summary>
        /// Call the Identifier class and ask for the next available Id.
        /// </summary>
        public void GenerateId()
        {
            if (_id == null)
            {
                _id = Identifier.NextKanjiId();
            }
            else
            {
                throw new BuilderException("Builder tried to generate Unique ID twice of Kanji Object.");
            }
        }

        /// <summary>
        /// Set the Name of the Kanji Object.
        /// </summary>
        /// <param name="name">The English name for this Kanji.</param>
        public void SetName(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Set the Symbol of the Kanji Object.
        /// </summary>
        /// <param name="symbol">The actual Kanji symbol.</param>
        public void SetSymbol(string symbol)
        {
            _symbol = symbol;
        }

        /// <summary>
        /// Add an alternative meanings to this Kanji Object.
        /// </summary>
        /// <param name="meaning">Other english meanings for this Kanji.</param>
        public void AddAlternativeMeaning(string meaning)
        {
            if (_alternativeMeanings == null)
            {
                _alternativeMeanings = new List<string>();
                _alternativeMeanings.Add(meaning);
            }
            else
            {
                _alternativeMeanings.Add(meaning);
            }
        }

        /// <summary>
        /// Add a On'yomi readings to this Kanji Object.
        /// </summary>
        /// <param name="reading">All On'yomi readings for this Kanji in Hiragana.</param>
        public void AddOnyomiReading(string reading)
        {
            if (_onyomiReadings == null)
            {
                _onyomiReadings = new List<string>();
                _onyomiReadings.Add(reading);
            }
            else
            {
                _onyomiReadings.Add(reading);
            }
        }

        /// <summary>
        /// Add a Kun'yomi reading to this Kanji Object.
        /// </summary>
        /// <param name="reading">All Kun'yomi readings for this Kanji.</param>
        public void AddKunyomiReading(string reading)
        {
            if (_kunyomiReadings == null)
            {
                _kunyomiReadings = new List<string>();
                _kunyomiReadings.Add(reading);
            }
            else
            {
                _kunyomiReadings.Add(reading);
            }
        }

        /// <summary>
        /// Add an Id of a visually similar Kanji to the Kanji Object.
        /// </summary>
        /// <param name="id">Kanji that are visually similar.</param>
        public void AddVisuallySimilarKanji(string id)
        {
            // Exception is thrown if "id" is found to be invalid.
            if (!Identifier.IsForKanji(id))
            {
                throw new IdentifierException($"Invalid identifier for Kanji:<{_id}>");
            }

            if (_visuallySimilarKanji == null)
            {
                _visuallySimilarKanji = new List<string>();
                _visuallySimilarKanji.Add(id);
            }
            else
            {
                _visuallySimilarKanji.Add(id);
            }
        }

        /// <summary>
        /// Add an Id of a Vocabulary that contains this Kanji.
        /// </summary>
        /// <param name="id">List of Ids of all Japanese Vocabulary that use this Kanji.</param>
        public void AddFoundInVocabulary(string id)
        {
            // Exception is thrown if "id" is found to be invalid.
            if (!Identifier.IsForVocab(id))
            {
                throw new IdentifierException($"Invalid identifier for Vocabulary:<{_id}>");
            }

            if (_foundInVocabulary == null)
            {
                _foundInVocabulary = new List<string>();
                _foundInVocabulary.Add(id);
            }
            else
            {
                _foundInVocabulary.Add(id);
            }
        }

        public override string ToString()
        {
            return "Kanji Builder Object";
        }

        /// <summary>
        /// Builds the Kanji Object and returns it from the KanjiBuilder.
        /// </summary>
        /// <returns>The constructed Kanji Object.</returns>
        public Kanji ToKanji()
        {
            // Check if all required parameters are assigned to within the KanjiBuilder.
            if (_id == null || _name == null || _symbol == null ||
                _onyomiReadings == null || _kunyomiReadings == null)
            {
                throw new BuilderException("Not all required parameters were filled when building Kanji Object.");
            }

            // Create the Kanji and return it.
            _kanji = new Kanji(_id, _name, _symbol, _onyomiReadings, _kunyomiReadings, _visuallySimilarKanji, _foundInVocabulary, _alternativeMeanings);
            return _kanji;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~KanjiBuilder()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
