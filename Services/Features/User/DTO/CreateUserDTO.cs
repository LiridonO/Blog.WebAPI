using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Features.DTO;

public class CreateUserDTO
{
    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Name { get; set; }

    public string Lastname { get; set; }

    public DateTime Birthdate { get; set; }

    public Gender Gender { get; set; }
}
