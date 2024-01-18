using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Comments : BaseModel
    {
        public string Content { get; set; }
        public Guid BlogEntityId { get; set; }
        public int Status { get; set; }
        public Guid CommentId { get; set; }
    }
}
