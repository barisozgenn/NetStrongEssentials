using Elasticsearch.Net;
using Newtonsoft.Json.Linq;

namespace ElasticSearchBaris.ElasticsearchServices
{
    // ElasticsearchService provides utility methods for interacting with Elasticsearch.
    public static class ElasticsearchService
    {
        // Gets an instance of the ElasticLowLevelClient for communication with Elasticsearch.
        private static ElasticLowLevelClient GetClient()
        {
            var settings = new ConnectionConfiguration(new Uri("http://localhost:9200"));
            var client = new ElasticLowLevelClient(settings);
            return client;
        }

        // Synchronizes a list of items to Elasticsearch based on a specified index and a function to retrieve the data.
        public static async Task SyncToElastic<T>(string indexName, Func<Task<List<T>>> getDataFunc) where T : class
        {
            var client = GetClient();

            List<T> items = await getDataFunc();

            var tasks = new List<Task>();

            foreach (var item in items)
            {
                var itemId = item.GetType().GetProperty("Id")?.GetValue(item).ToString();

                if (string.IsNullOrEmpty(itemId))
                {
                    // Error handling or logging can be added here.
                    continue;
                }

                // Check if the item already exists in Elasticsearch.
                var response = await client.GetAsync<StringResponse>(indexName, itemId);

                if (response.HttpStatusCode != 200)
                {
                    // Index the item if it doesn't exist.
                    tasks.Add(client.IndexAsync<StringResponse>(indexName, itemId, PostData.Serializable(item)));
                }
            }

            // Wait for all indexing tasks to complete.
            await Task.WhenAll(tasks);
        }

        // Synchronizes a single item to Elasticsearch based on a specified index and the provided data.
        public static async Task SyncSingleToElastic<T>(string indexName, T data) where T : class
        {
            var client = GetClient();

            var dataId = data.GetType().GetProperty("Id")?.GetValue(data).ToString();

            if (string.IsNullOrEmpty(dataId))
            {
                throw new Exception("Id Not Found!"); // Alternatively, provide a suitable response.
            }

            // Check if the item already exists in Elasticsearch.
            var response = await client.GetAsync<StringResponse>(indexName, dataId);

            if (response.HttpStatusCode != 200)
            {
                // Index the item if it doesn't exist.
                await client.IndexAsync<StringResponse>(indexName, dataId, PostData.Serializable(data));
            }
        }

        // Retrieves a list of items from Elasticsearch based on a specified index, field name, and search value.
        public static async Task<List<T>> GetDataListWithElasticSearch<T>(string indexName, string fieldName, string value) where T : class
        {
            var client = GetClient();

            // Define a simple wildcard search query.
            var searchQuery = new
            {
                query = new
                {
                    wildcard = new Dictionary<string, object>
                    {
                        { fieldName, new { value = $"*{value}*" } }
                    }
                }
            };

            // Execute the search query and get the response.
            var response = await client.SearchAsync<StringResponse>(indexName, PostData.Serializable(searchQuery));

            // Parse the Elasticsearch response and extract the hits.
            var results = JObject.Parse(response.Body);
            var hits = results["hits"]["hits"].ToObject<List<JObject>>();

            // Convert hits to a list of strongly-typed items.
            List<T> items = new();

            foreach (var hit in hits)
            {
                items.Add(hit["_source"].ToObject<T>());
            }

            return items;
        }
    }
}
