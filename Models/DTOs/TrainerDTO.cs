using ttcm_mvc.Models;

namespace ttcm_mvc.Models.DTOs
{
    public class TrainerDTO:UserDTO
    {
        public decimal Salary { get; set; }
        public string Specialization { get; set; }
    }
    public class TrainerDTOResponse : TrainerDTO
    {
        public int Id { get; set; }
        public IEnumerable<CourseDTOResponse> Courses { get; set; } = new List<CourseDTOResponse>();
    }
}
