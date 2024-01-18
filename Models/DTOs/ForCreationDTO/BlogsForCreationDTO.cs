using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ForCreationDTO
{
    public class BlogsForCreationDTO
    {
        public string? Title { get; set; } = null;
        public string? ShortDescription { get; set; } = null; 
        public Guid? HeaderImageId { get; set; } = null;
        public int Views { get; set; }
        public Guid InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
    }
}
