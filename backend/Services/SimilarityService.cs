using Azure;
using Azure.AI.TextAnalytics;
using System;
using System.Threading.Tasks;

namespace docmatchMS.Services;

public class SimilarityService
{
    private readonly TextAnalyticsClient _textAnalyticsClient;

    public SimilarityService(string azureEndpoint, string azureApiKey)
    {
        var credentials = new AzureKeyCredential(azureApiKey);
        _textAnalyticsClient = new TextAnalyticsClient(new Uri(azureEndpoint), credentials);
    }

    /// <summary>
    /// Calculates the semantic similarity of two texts using Azure Cognitive Services.
    /// </summary>
    /// <param name="text1">The first text.</param>
    /// <param name="text2">The second text.</param>
    /// <returns>A similarity score between 0.0 and 1.0.</returns>
    public async Task<double> CalculateSemanticSimilarityAsync(string text1, string text2)
    {
        try
        {
            var document1 = new TextDocumentInput("1", text1);
            var document2 = new TextDocumentInput("2", text2);

            var result = await _textAnalyticsClient.AnalyzeSentimentBatchAsync(new[] { document1, document2 });

            // Placeholder: Replace with actual logic to interpret Azure's results.
            // Azure Text Analytics doesn't directly provide a similarity score,
            // so you might need to pre-train a model or use embeddings.
            return ComputeSimilarity(text1, text2); // Simple placeholder
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calculating semantic similarity: {ex.Message}");
            return 0.0;
        }
    }

    private double ComputeSimilarity(string text1, string text2)
    {
        // Use Azure outputs or embeddings to calculate actual similarity.
        // Placeholder similarity calculation:
        return text1 == text2 ? 1.0 : 0.5;
    }

        /// <summary>
    /// Calculates the Jaccard similarity between two texts.
    /// </summary>
    /// <param name="text1">The first text.</param>
    /// <param name="text2">The second text.</param>
    /// <returns>A similarity score between 0.0 and 1.0.</returns>
    public double CalculateJaccardSimilarity(string text1, string text2)
    {
        var set1 = text1.Split(' ').ToHashSet();
        var set2 = text2.Split(' ').ToHashSet();

        var intersectionSize = set1.Intersect(set2).Count();
        var unionSize = set1.Union(set2).Count();

        return (double)intersectionSize / unionSize;
    }
}