namespace ttcm_mvc.Models.Views
{
    public class AddTrainerViewModel
    {

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        //public int Id { get; set; }
        //public string UserId { get; set; } // FK to ApplicationUser
        public decimal Salary { get; set; }
        public string Specialization { get; set; }
        
    }
}
