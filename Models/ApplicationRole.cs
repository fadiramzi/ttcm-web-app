using Microsoft.AspNetCore.Identity;

namespace ttcm_mvc.Models
{
    public class ApplicationRole:IdentityRole<int>
    {
        public ApplicationRole() { 
        }
        public ApplicationRole(string roleName):base(roleName) { }
    }
}
