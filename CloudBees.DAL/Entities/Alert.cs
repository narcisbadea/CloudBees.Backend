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
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string? Status { get; set; }
    public string? Photo { get; set; }
}
