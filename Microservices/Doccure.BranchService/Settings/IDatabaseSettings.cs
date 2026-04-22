namespace Doccure.BranchService.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string BranchCollectionName { get; set; }
    }
}
