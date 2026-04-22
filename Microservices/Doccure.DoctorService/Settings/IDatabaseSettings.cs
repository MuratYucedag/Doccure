namespace Doccure.DoctorService.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string DoctorCollectionName { get; set; }
    }
}
