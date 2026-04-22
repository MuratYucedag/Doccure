namespace Doccure.ReviewService.Settings
{
    public class DatabaseSettings:IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ReviewCollectionName { get; set; }
    }
}
