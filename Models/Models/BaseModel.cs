using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public Guid InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
        public Guid LastEditedBy { get; set; }
        public DateTime LastEditedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Guid DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
