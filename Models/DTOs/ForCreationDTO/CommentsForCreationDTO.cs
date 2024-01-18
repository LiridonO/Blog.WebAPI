using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ForCreationDTO
{
    public class CommentsForCreationDTO
    {
        public string? Content { get; set; } = null;
        public Guid? BlogEntityId { get; set; } = null;
        public int? Status { get; set; } = null;
        public Guid? CommentId { get; set; } = null;
        public Guid InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
    }
}
