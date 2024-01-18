using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class BlogLikes
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BlogEntityId { get; set; }
    }
}
