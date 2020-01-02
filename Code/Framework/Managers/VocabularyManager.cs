using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core;

namespace Framework.Managers
{
    static class VocabularyManager
    {
        // This is where all IVocabulary data is stored along side associated Note and Grade object.
        // 
        // 1. Store all Kanji and Vocabulary in seperate Lists.
        //
        // 2. Intiailise a triple-tuple that contains: (IVocabulary, Grade, Notes).
        // 
        // 3. Use the current level of the User to decide what Kanji are unlocked and placed them in the unlocked list.
        //
        // 4. Use the rank of all unlocked Kanji to decide what Vocabulary are unlocked and place them in the unlocked list.

        /// <summary>
        /// List of all available Kanji in the Database.
        /// </summary>
        public static List<Kanji> Kanji { get; private set; }

        /// <summary>
        /// List of all available Vocabulary in the Database.
        /// </summary>
        public static List<Vocabulary> Vocabulary { get; private set; }

        /// <summary>
        /// Holds all unlocked Vocabulary and Kanji and their associated Grade and Notes Object.
        /// </summary>
        public static List<Tuple<IVocabulary, Grade, Notes>> UnlockedMaterial { get; private set; }

        /// <summary>
        /// Initialises all Core Data of the Application.
        /// </summary>
        public static void Initialise()
        {
            // NOTE: USERMANAGER MUST BE INITIALISED FIRST.
            // 1. Load all Kanji and Vocabulary from local Disk into their Lists
            // 2. Get user level and have unlocked material reference all Kanji of the same level.
            // 3. Load their Grade and Note objects from disk.
            // 4. Based on user level and Kanji Rank via Grade Object, have unlocked material reference all applicable vocabulary.
            // 5. load their Grade and Note objects from disk.
            // End result is UnlockedMaterial being full for content for LessonHandler to use.
        }
    }
}
