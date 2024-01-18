using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ForCreationDTO
{
    public class DocumentsForCreationDTO
    {
        public string? Name { get; set; } = null;
        public string? FileNameGuid { get; set; } = null;
        public string? FileMimeType { get; set; } = null;
        public Guid InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
    }
}
