using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core
{
    public class Notes
    {
        // Sets an Id to each entry within the note object.
        // These Ids are set per instance and are not needed to store object as JSON.
        private int _newestId;

        private Dictionary<int, string> _entries;

        /// <summary>
        /// Used to identify what IVocabulary object this is permanetley associated with.
        /// </summary>
        public string IVocabularyId { get; }

        /// <summary>
        /// Create a new empty Notes Object.
        /// </summary>
        public Notes(string id)
        {
            IVocabularyId = id;
            _entries = new Dictionary<int, string>();
        }

        /// <summary>
        /// Create a new Notes Object with one entry.
        /// </summary>
        /// <param name="entry">A user customised note.</param>
        public Notes(string id, string entry)
        {
            IVocabularyId = id;
            _entries = new Dictionary<int, string>();
            AddEntry(entry);
        }

        /// <summary>
        /// Re-Create a Notes Object with a list of entries.
        /// </summary>
        /// <param name="entries">User customised notes.</param>
        public Notes(List<string> entries)
        {
            foreach (string entry in entries)
            {
                AddEntry(entry);
            }
        }

        /// <summary>
        /// Add a new entry to the Notes Object and assign it with an Id.
        /// </summary>
        /// <param name="entry">A user customised note.</param>
        public void AddEntry(string entry)
        {
            _entries.Add(_newestId, entry);
            _newestId++;
        }
        
        /// <summary>
        /// Removes a entry based on its Id.
        /// </summary>
        /// <param name="id">The Id of the user customised entry.</param>
        public void RemoveEntry(int id)
        {
            _entries.Remove(id);
        }

        /// <summary>
        /// Gets all the entries and their associated Ids.
        /// </summary>
        /// <returns>Dictionary containing Ids and user customised entries.</returns>
        public Dictionary<int, string> GetKeyValuePairs()
        {
            return _entries;
        }

        /// <summary>
        /// Gets all the entries without their associated Ids.
        /// Use this method when storing into the JSON database.
        /// </summary>
        /// <returns>A List of strings which represent each entry.</returns>
        public IEnumerable<string> GetAllEntries()
        {
            foreach (KeyValuePair<int, string> entry in _entries)
            {
                yield return entry.Value;
            }
        }
    }
}
