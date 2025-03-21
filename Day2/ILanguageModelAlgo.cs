namespace PredictionEngine;

public interface ILanguageModelAlgo {
    public String PredictUsingMonogram(String word);

    public String PredictUsingBigram(String word) ;
}
