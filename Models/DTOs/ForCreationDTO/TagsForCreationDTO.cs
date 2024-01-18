using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ForCreationDTO
{
    public class TagsForCreationDTO
    {
        public string? Name { get; set; } = null;
        public string? Description { get; set; } = null;
        public Guid InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
    }
}
