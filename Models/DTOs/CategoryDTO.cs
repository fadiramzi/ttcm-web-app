using System.ComponentModel.DataAnnotations;

namespace ttcm_mvc.Models.DTOs
{
    public class CategoryDTO
    {
        [Required]
        [MinLength(2, ErrorMessage ="Name is too short")]
        public string Name { get; set; }
        
    }
    public class CategoryDTOResponse:CategoryDTO
    {
        public int Id { get; set; }
    }
}
