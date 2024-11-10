using System.ComponentModel.DataAnnotations.Schema;

namespace ttcm_mvc.Models
{
    public class Prog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }

        // Belongs to 
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
