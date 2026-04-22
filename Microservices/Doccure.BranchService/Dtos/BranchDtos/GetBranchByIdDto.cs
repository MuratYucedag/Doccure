namespace Doccure.BranchService.Dtos.BranchDtos
{
    public class GetBranchByIdDto
    {
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
