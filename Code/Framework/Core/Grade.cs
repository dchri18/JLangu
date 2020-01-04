using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core
{
    class Grade
    {
        /// <summary>
        /// Used to identify what IVocabulary object this is permanetley associated with.
        /// </summary>
        public string IVocabularyId { get; }

        /// <summary>
        /// Number of times the assoicated IVocabulary has been answered correctly.
        /// </summary>
        public int TimesCorrect { get; private set; }

        /// <summary>
        /// Number of times ths associated IVocabulary has been answered incorrectly.
        /// </summary>
        public int TimesIncorrect { get; private set; }

        /// <summary>
        /// The DateTime when the associated IVocabulary object was unlocked.
        /// </summary>
        public DateTime UnlockedOn { get; }

        /// <summary>
        /// States the current rank of the associated IVocabulary object.
        /// </summary>
        public Rank CurrentRank { get; private set; }

        // Comments:
        //   This object only exists for each Kanji/Vocab once they've been unlocked.
        //   Beacuse of this, "UnlockedOn" gets set upon first construction using the parameter-less constructor.

        /// <summary>
        /// Basic constructor for first time unlocking something.
        /// </summary>
        /// <param name="id">The Id of the associated IVocabulary.</param>
        public Grade(string id)
        {
            IVocabularyId = id;
            UnlockedOn = DateTime.Now;
            CurrentRank = Rank.OneStudent;
        }

        /// <summary>
        /// Used for Json deserialisation.
        /// </summary>
        /// <param name="id">Used to identify what IVocabulary object this is permanetley associated with.</param>
        /// <param name="timesCorrect">Number of times the assoicated IVocabulary has been answered correctly.</param>
        /// <param name="timesIncorrect">Number of times ths associated IVocabulary has been answered incorrectly.</param>
        /// <param name="unlockedOn">The DateTime when the associated IVocabulary object was unlocked.</param>
        /// <param name="currentRank">States the current rank of the associated IVocabulary object.</param>
        public Grade(string id, int timesCorrect, int timesIncorrect, DateTime unlockedOn, Rank currentRank)
        {
            IVocabularyId = id;
            TimesCorrect = timesCorrect;
            TimesIncorrect = timesIncorrect;
            UnlockedOn = unlockedOn;
            CurrentRank = currentRank;
        }

        /// <summary>
        /// Increments the TimesCorrected parameter and upgrades the Rank of the object.
        /// OneStudent > TwoStudent > ThreeStudent > FourStudent > FiveProficient > SixMaster
        /// </summary>
        public void Correct()
        {
            TimesCorrect++;
            switch(CurrentRank) {
                case Rank.OneStudent:
                    CurrentRank = Rank.TwoStudent;
                    break;
                case Rank.TwoStudent:
                    CurrentRank = Rank.ThreeStudent;
                    break;
                case Rank.ThreeStudent:
                    CurrentRank = Rank.FourStudent;
                    break;
                case Rank.FourStudent:
                    CurrentRank = Rank.FiveProficient;
                    break;
                case Rank.FiveProficient:
                    CurrentRank = Rank.SixMaster;
                    break;
                case Rank.SixMaster:
                    break;
            }
        }

        /// <summary>
        /// Increments the TimesIncorrect parameter and downgrades the Rank of the object.
        /// OneStudent > TwoStudent > ThreeStudent > FourStudent > FiveProficient > SixMaster
        /// </summary>
        public void Incorrect()
        {
            TimesIncorrect++;
            switch (CurrentRank)
            {
                case Rank.OneStudent:
                    break;
                case Rank.TwoStudent:
                    CurrentRank = Rank.OneStudent;
                    break;
                case Rank.ThreeStudent:
                    CurrentRank = Rank.TwoStudent;
                    break;
                case Rank.FourStudent:
                    CurrentRank = Rank.ThreeStudent;
                    break;
                case Rank.FiveProficient:
                    CurrentRank = Rank.FourStudent;
                    break;
                case Rank.SixMaster:
                    CurrentRank = Rank.FiveProficient;
                    break;
            }
        }

        /// <summary>
        /// Returns the ratio weighted towards how many times the associated IVocabulary was answered correctly.
        /// </summary>
        /// <returns></returns>
        public double CorrectRatio()
        {
            int attempts = TimesCorrect + TimesIncorrect;
            return TimesCorrect / attempts;
        }

        /// <summary>
        /// Returns the ratio weighted towards how many times the associated IVocabulary was answered incorrectly.
        /// </summary>
        /// <returns></returns>
        public double IncorrectRatio()
        {
            int attempts = TimesCorrect + TimesIncorrect;
            return TimesIncorrect / attempts;
        }

        /// <summary>
        /// returns a percentage as a string correlating the times answered correctly.
        /// </summary>
        /// <returns></returns>
        public string CorrectPercentage()
        {
            char[] ratio = CorrectRatio().ToString().ToCharArray();
            StringBuilder sb = new StringBuilder();
            sb.Append(ratio[2]);
            if (ratio.Length == 3)
            {
                sb.Append("0");
                sb.Append("%");
            }
            else
            {
                sb.Append(ratio[3]);
                sb.Append("%");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns a percentage as a string correlating the times answered incorrectly.
        /// </summary>
        /// <returns></returns>
        public string IncorrectPercentage()
        {
            char[] ratio = IncorrectRatio().ToString().ToCharArray();
            StringBuilder sb = new StringBuilder();
            sb.Append(ratio[2]);
            if (ratio.Length == 3)
            {
                sb.Append("0");
                sb.Append("%");
            }
            else
            {
                sb.Append(ratio[3]);
                sb.Append("%");
            }
            return sb.ToString();
        }
    }
}
