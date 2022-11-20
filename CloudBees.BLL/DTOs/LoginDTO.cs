using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBees.BLL.DTOs;

public class LoginDTO
{
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;    
}
