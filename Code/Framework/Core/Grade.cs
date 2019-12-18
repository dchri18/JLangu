using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core
{
    class Grade
    {
        public int TimesCorrect { get; private set; }
        public int TimesIncorrect { get; private set; }
        public DateTime UnlockedOn { get; }
        public Rank CurrentRank { get; private set; }

        // Comments:
        //   This object only exists for each Kanji/Vocab once they've been unlocked.
        //   Beacuse of this, "UnlockedOn" gets set upon first construction using the parameter-less constructor.

        public Grade()
        {
            UnlockedOn = DateTime.Now;
            CurrentRank = Rank.OneStudent;
        }

        public Grade(int timesCorrect, int timesIncorrect, DateTime unlockedOn, Rank currentRank)
        {
            TimesCorrect = timesCorrect;
            TimesIncorrect = timesIncorrect;
            UnlockedOn = unlockedOn;
            CurrentRank = currentRank;
        }

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

        public double CorrectRatio()
        {
            int attempts = TimesCorrect + TimesIncorrect;
            return TimesCorrect / attempts;
        }

        public double IncorrectRatio()
        {
            int attempts = TimesCorrect + TimesIncorrect;
            return TimesIncorrect / attempts;
        }

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
