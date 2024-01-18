using Microsoft.AspNetCore.Identity;
using Models.Enums;

namespace Models.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }

        public string Lastname { get; set; }

        public DateTime Birthdate { get; set; }

        public Gender Gender { get; set; }

        public bool? IsDeleted { get; set; }
        
        public DateTime InsertedDate { get; set; }

        public DateTime? DeletedDate { get; set; }
        
        public DateTime LastEditedDate { get; set; }
    }
}
