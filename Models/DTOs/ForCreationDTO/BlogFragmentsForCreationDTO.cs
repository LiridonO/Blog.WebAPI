using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ForCreationDTO
{
    public class BlogFragmentsForCreationDTO
    {
        public Guid? BlogEntityId { get; set; } = null;
        public Guid? ImageId { get; set; } = null;
        public string? ImageTitle { get; set; } = null;
        public string? ImageDescription { get; set; } = null;
        public int Order { get; set; }
        public string? SubTitle { get; set; } = null;
        public string? Content { get; set; } = null;
        public Guid InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
    }
}
