using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class BlogFragments : BaseModel
    {
        public Guid BlogEntityId { get; set; }
        public Guid ImageId { get; set; }
        public string ImageTitle { get; set; }
        public string ImageDescription { get; set; }
        public int Order { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
    }
}
