using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Blogs : BaseModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public Guid HeaderImageId { get; set; }
        public int Views { get; set; }
    }
}