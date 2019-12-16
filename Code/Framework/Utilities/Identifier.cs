using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Framework.Exceptions;

namespace Framework.Utilities
{
    public static class Identifier
    {
        private static string _kanjiId;
        private static string _vocabId;

        private static readonly int _kanjiIdMin = 0;
        private static readonly int _kanjiIdMax = 9999;
        private static readonly int _vocabIdMin = 0;
        private static readonly int _vocabIdMax = 999999;

        public static void Initialise()
        {
            // TODO

            // Look through all current Kanji and Vocabulary objects in the memory and see which has the highest ID,
            // get the incremented value of those numbers and set them to this class.

            // Kanji ID example: K####
            // Vocabulary ID example: V######
        }

        public static string NextKanjiId()
        {
            // After initialisation, give the current identifier then increment.
            return "K001";
        }

        public static string NextVocabId()
        {
            // After initialisation, give the current identifier then increment.
            return "V001";
        }

        public static int IdentifierToInt(string id)
        {
            char[] split = id.ToCharArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < id.Length; i++)
            {
                sb.Append(split[i]);
            }
            
            if (Int32.TryParse(sb.ToString(), out int tmp))
            {
                return tmp;
            }
            else
            {
                throw new IdentifierException($"Failed to string id <{id}> to an interger");
            }
        }

        public static bool IsForKanji(string id)
        {
            char[] split = id.ToCharArray();
            if (split[0] == 'K')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsForVocab(string id)
        {
            char[] split = id.ToCharArray();
            if (split[0] == 'V')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
