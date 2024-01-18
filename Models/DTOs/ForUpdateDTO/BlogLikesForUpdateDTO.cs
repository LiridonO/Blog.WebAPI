using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ForUpdateDTO
{
    public class BlogLikesForUpdateDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BlogEntityId { get; set; }
    }
}
