namespace Doccure.BranchService.Dtos.BranchDtos
{
    public class CreateBranchDto
    {
        public string BranchName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
