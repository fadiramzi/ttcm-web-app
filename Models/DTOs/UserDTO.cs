namespace ttcm_mvc.Models.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "Admin", "Trainer", "Trainee"
    }
    public class UserResponseDTO
    {
        public int   Id { get; set; }


        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

}
