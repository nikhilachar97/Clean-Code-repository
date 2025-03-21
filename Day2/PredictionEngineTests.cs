using Moq;

namespace PredictionEngine.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("Hello ho","ho")]
    [TestCase("Hello how are you", "you")]
    [TestCase("", "")]    
    public void WhenInputIsAPartialWordTheUnigramShouldBeCalled(string thePhrase,string theParameterToBeCalled)
    {
        var aMockILanguageModelAlgo = new Mock<ILanguageModelAlgo>();
        PredictionEngine aPredictionEngine = new PredictionEngine(aMockILanguageModelAlgo.Object);

        string aPredictionResult = aPredictionEngine.Predict(thePhrase);

        aMockILanguageModelAlgo.Verify(p => p.PredictUsingMonogram(theParameterToBeCalled), Times.Once());
    }

    [TestCase("Hello ", "Hello")]
    [TestCase("Hello how are y ", "y")]
    [TestCase("", "")]
    public void WhenInputIsEndingWithSpaceThenBigramShouldBeCalled(string thePhrase, string theParameterToBeCalled)
    {
        var aMockILanguageModelAlgo = new Mock<ILanguageModelAlgo>();
        PredictionEngine aPredictionEngine = new PredictionEngine(aMockILanguageModelAlgo.Object);

        string aPredictionResult = aPredictionEngine.Predict(thePhrase);

        aMockILanguageModelAlgo.Verify(p => p.PredictUsingBigram(theParameterToBeCalled), Times.Once());
    }
}
