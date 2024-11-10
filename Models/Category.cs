namespace ttcm_mvc.Models
{
    public class Category
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        // Has Many, one to many relationship
        public ICollection<ttcm_mvc.Models.Prog> Programs { get; set; }
    }
}
