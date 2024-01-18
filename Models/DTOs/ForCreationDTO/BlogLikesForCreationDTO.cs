using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ForCreationDTO
{
    public class BlogLikesForCreationDTO
    {
        public Guid? Id { get; set; } = null;
        public Guid? UserId { get; set; } = null;
        public Guid? BlogEntityId { get; set; } = null; 
    }
}
