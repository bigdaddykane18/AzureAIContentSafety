using System;
using Azure.AI.ContentSafety;

namespace Azure.AI.ContentSafety.Dotnet.Sample
{
    class ContentSafetySampleAnalyzeImage
    {
        public static void AnalyzeImage()
        {
            // Create Azure AI ContentSafety Client

            string endpoint = Environment.GetEnvironmentVariable("CONTENT_SAFETY_ENDPOINT");
            string key = Environment.GetEnvironmentVariable("CONTENT_SAFETY_KEY") ;

            ContentSafetyClient client = new ContentSafetyClient(new Uri(endpoint), new AzureKeyCredential(key));

            // Example: analyze image

            string imagePath = @"sample_data\image.jpg";
            ImageData image = new ImageData() { Content = BinaryData.FromBytes(File.ReadAllBytes(imagePath)) };

            var request = new AnalyzeImageOptions(image);

            Response<AnalyzeImageResult> response;
            try
            {
                response = client.AnalyzeImage(request);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine("Analyze image failed.\nStatus code: {0}, Error code: {1}, Error message: {2}", ex.Status, ex.ErrorCode, ex.Message);
                throw;
            }

            Console.WriteLine("\nAnalyze image succeeded:");
            Console.WriteLine("Hate severity: {0}", response.Value.HateResult?.Severity ?? 0);
            Console.WriteLine("SelfHarm severity: {0}", response.Value.SelfHarmResult?.Severity ?? 0);
            Console.WriteLine("Sexual severity: {0}", response.Value.SexualResult?.Severity ?? 0);
            Console.WriteLine("Violence severity: {0}", response.Value.ViolenceResult?.Severity ?? 0);
        }

        static void Main()
        {
            AnalyzeImage();
        }
    }
}
Console.WriteLine("Hate severity: {0}", response.Value.HateResult?.Severity ?? 0);
Console.WriteLine("Hate category: {0}", response.Value.HateResult?.Category ?? "None");
Speichern der Ergebnisse in einer Datei: Du könntest die Ergebnisse in einer Datei speichern, um sie später zu analysieren:

using (StreamWriter writer = new StreamWriter("analyze_results.txt"))
{
    writer.WriteLine("Hate severity: {0}", response.Value.HateResult?.Severity ?? 0);
    writer.WriteLine("SelfHarm severity: {0}", response.Value.SelfHarmResult?.Severity ?? 0);
    writer.WriteLine("Sexual severity: {0}", response.Value.SexualResult?.Severity ?? 0);
    writer.WriteLine("Violence severity: {0}", response.Value.ViolenceResult?.Severity ?? using System.Timers;

class Program
{
    private static Timer timer;

    static void Main()
    {
        timer = new Timer(60000); // Set the interval to 60 seconds
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
        timer.Enabled = true;

        Console.WriteLine("Press [Enter] to exit the program.");
        Console.ReadLine();
    }

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        ContentSafetySampleAnalyzeImage.AnalyzeImage();
    }
}

