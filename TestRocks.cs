using RocksDbSharp;
using Xunit;

namespace TestExample
{
    public class TestRocks
    {
        [Fact]
        public void Test()
        {
            var options = new DbOptions().SetCreateIfMissing(true).EnableStatistics();
            using (var db = RocksDb.Open(options, "rocksdb_simple_hl_example"))
            {
                string value = db.Get("key");
                db.Put("key", "value");
                value = db.Get("key");
                string iWillBeNull = db.Get("non-existent-key");
                Assert.Equal("null", iWillBeNull);
                db.Remove("key");
            }
        }
    }
}
