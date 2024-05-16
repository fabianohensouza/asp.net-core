namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        //public static Task<long?> GetPageLength()
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://apress.com");
            return httpMessage.Content.Headers.ContentLength;

            //var httpTask = client.GetAsync("http://apress.com");
            //return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) => {
            //    return antecedent.Result.Content.Headers.ContentLength;
            //});
        }

        public static async IAsyncEnumerable<long?> GetPageLengths(
            List<string> output, 
            params string[] urls)
        {
            HttpClient client = new HttpClient();

            foreach (string url in urls)
            {
                output.Add($"Started request for {url}");
                var httpMessage = await client.GetAsync($"http://{url}");
                output.Add($"Completed request for {url}");

                yield return httpMessage.Content.Headers.ContentLength;
            }
        }
    }
}
