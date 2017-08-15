using System;
using System.Threading.Tasks;

namespace couchbase_5._0_auth_demo
{
    public class Program
    {
        public static void Main()
        {
            var bucket = Helpers.CouchHelper.GetBucket("default");

            // simulate some traffic
            Parallel.For(1, 100, index =>
            {
                var key = $"key-{index}";

                var upsertResult = bucket.Upsert(key, new {index});
                if (!upsertResult.Success)
                {
                    Console.WriteLine($"Failed to write key {key}");
                }

                var getResult = bucket.Get<dynamic>(key);
                if (!getResult.Success)
                {
                    Console.WriteLine($"Failed to gey key {key}");
                }
            });
        }
    }
}
