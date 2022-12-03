using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBees.DAL.Entities;

public class Alert
{
    public string Id { get; set; }
    public AlertType Type { get; set; }
    public User User { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? Location { get; set; }
}
