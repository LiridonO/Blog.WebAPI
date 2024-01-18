using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ForUpdateDTO
{
    public class CommentsForUpdateDTO
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid? BlogEntityId { get; set; } = null;
        public int Status { get; set; }
        public Guid? CommentId { get; set; } = null;
        public Guid LastEditedBy { get; set; }
    }
}
