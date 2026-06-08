namespace Doccure.DoctorService.Dtos.DoctorDtos
{
    public class GetDoctorNameAndSurnameByIdDto
    {
        public string DoctorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
