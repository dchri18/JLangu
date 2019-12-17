using System;
using System.Collections.Generic;
using System.Text;
using Framework.Utilities;
using Framework.Exceptions;

namespace Framework.Core
{
    /// <summary>
    /// Disposable object that builds a Vocabulary Object.
    /// </summary>
    public class VocabularyBuilder : IDisposable
    {

        private Vocabulary _vocab;
        private string _id;
        private string _name;
        private List<string> _synynoms;
        private TypeOfSpeech _type;
        private string _reading;
        private string _noKanjiReading;
        private List<string> _usedKanji;
        private int _level;

        public VocabularyBuilder()
        {

        }

        /// <summary>
        /// Calls the Identifier class and asks for the next available Id.
        /// </summary>
        public void GenerateId()
        {
            if (_id == null)
            {
                _id = Identifier.NextVocabId();
            }
            else
            {
                throw new BuilderException("Builder tried to generate Unique ID twice of Kanji Object.");
            }
        }

        /// <summary>
        /// Set the Name of the Vocabulary Object.
        /// </summary>
        /// <param name="name">The english reading of the vocabulary.</param>
        public void SetName(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Add an English alternative word or synonym to this Vocabulary Object.
        /// </summary>
        /// <param name="synonym">Alternative English ways of reading the vocabulary.</param>
        public void AddSynonym(string synonym)
        {
            if (_synynoms == null)
            {
                _synynoms = new List<string>();
                _synynoms.Add(synonym);
            }
            else
            {
                _synynoms.Add(synonym);
            }
        }

        /// <summary>
        /// Set the type of Vocabulary of which it is.
        /// </summary>
        /// <param name="type">The type of speech the vocabulary falls under.</param>
        public void SetType(TypeOfSpeech type)
        {
            _type = type;
        }

        /// <summary>
        /// Set the Japanese reading of the Vocabulary Object.
        /// </summary>
        /// <param name="reading">The Japanese way of reading the vocabulary.</param>
        public void SetReading(string reading)
        {
            _reading = reading;
        }

        /// <summary>
        /// Set the Japanese reading of the Vocabulary Object that does not use any Kanji.
        /// </summary>
        /// <param name="reading">The Hiragana or Katakana only reading of the word.</param>
        public void SetNoKanjiReading(string reading)
        {
            _noKanjiReading = reading;
        }

        /// <summary>
        /// Add the Ids of Kanji that are used in this Vocabulary Object.
        /// </summary>
        /// <param name="id">Id of Kanji used in the normal reading of the vocabulary.</param>
        public void AddUsedKanji(string id)
        {
            // Exception is thrown if "id" is found to be invalid.
            if (!Identifier.IsForKanji(id))
            {
                throw new IdentifierException($"Invalid identifier for Kanji:<{_id}>");
            }

            if (_usedKanji == null)
            {
                _usedKanji = new List<string>();
                _usedKanji.Add(id);
            }
            else
            {
                _usedKanji.Add(id);
            }
        }

        /// <summary>
        /// Set the Level of the Vocabulary Object.
        /// </summary>
        /// <param name="level">Indicates when the Vocabulary should be unlocked based on the Users level.</param>
        public void SetLevel(int level)
        {
            _level = level;
        }

        public override string ToString()
        {
            return "Vocabulary Builder Object";
        }

        /// <summary>
        /// Builds the Vocabulary Object and returns it from the VocabularyBuilder.
        /// </summary>
        /// <returns>The constructed Vocabulary.</returns>
        public Vocabulary ToVocabulary()
        {
            // Check if all required parameters are assigned to within the VocabularyBuilder.
            if (_id == null || _name == null || _reading == null || _noKanjiReading == null || _level == 0)
            {
                throw new BuilderException("Not all required parameters were filled when building Vocabulary Object.");
            }

            // Create the Vocab and return it.
            _vocab = new Vocabulary(_id, _name, _type, _reading, _noKanjiReading, _level, _usedKanji, _synynoms);
            return _vocab;
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
        // ~VocabularyBuilder()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
