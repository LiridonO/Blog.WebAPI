using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Documents : BaseModel
    {
        public string Name { get; set; }
        public string FileNameGuid { get; set; }
        public string FileMimeType { get; set; }
    }
}
