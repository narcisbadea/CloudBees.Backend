using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBees.DAL.Entitis;

public class UsersStats
{
    public string Id { get; set; }
    public int NumberOfUsers { get; set; }
    public DateTime Date { get; set; }
}
