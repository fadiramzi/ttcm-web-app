using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ttcm_mvc.Models
{
    public class User:IdentityUser<int>
    { 
    }

}
