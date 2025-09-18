namespace IKEA.PL.Models.ViewModels.Department
{
    public class DepartmentViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
