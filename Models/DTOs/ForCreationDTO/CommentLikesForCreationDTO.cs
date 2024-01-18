using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ForCreationDTO
{
    public class CommentLikesForCreationDTO
    {
        public Guid? Id { get; set; } = null;
        public Guid? CommentId { get; set; } = null;
        public Guid? UserId { get; set; } = null; 
    }
}
