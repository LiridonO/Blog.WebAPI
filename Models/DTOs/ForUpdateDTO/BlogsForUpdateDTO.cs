using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ForUpdateDTO
{
    public class BlogsForUpdateDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public Guid? HeaderImageId { get; set; } = null;
        public int Views { get; set; }
        public Guid LastEditedBy { get; set; }
    }
}
