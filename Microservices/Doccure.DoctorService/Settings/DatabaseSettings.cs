namespace Doccure.DoctorService.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string DoctorCollectionName { get; set; }
    }
}
