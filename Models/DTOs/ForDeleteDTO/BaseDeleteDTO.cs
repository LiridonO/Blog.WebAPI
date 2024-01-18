using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ForDeleteDTO;

public class BaseDeleteDTO<TKey>
{
    public TKey Id { get; set; }
    public Guid DeletedBy { get; set; }
}
