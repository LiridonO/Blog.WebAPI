using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ForUpdateDTO
{
    public class DocumentsForUpdateDTO
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string FileNameGuid { get; set; }
        public string FileMimeType { get; set; }
        public Guid LastEditedBy { get; set; }
    }
}
