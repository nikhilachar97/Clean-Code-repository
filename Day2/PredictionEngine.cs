using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictionEngine
{
    public class PredictionEngine
    {
        private ILanguageModelAlgo myLanguageModelAlgo;

        public PredictionEngine(ILanguageModelAlgo theLanguageModelAlgo)
        {
            this.myLanguageModelAlgo = theLanguageModelAlgo;
        }

        public string Predict(string theInputPhrase)
        {
            string aLastWord = GetLastWord(theInputPhrase);
            if (theInputPhrase.EndsWith(""))
            {
                myLanguageModelAlgo.PredictUsingBigram(aLastWord);
            }
            return myLanguageModelAlgo.PredictUsingMonogram(aLastWord);
        }

        private string GetLastWord(string theInputPhrase)
        {
            string[] aWords = theInputPhrase.Trim().Split(' ');
            string aLastWord = aWords[aWords.Length - 1];
            return aLastWord;
        }
    }
}
