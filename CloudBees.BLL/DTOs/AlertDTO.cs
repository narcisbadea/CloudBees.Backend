using CloudBees.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBees.BLL;

public class AlertDTO
{
    public string Id { get; set; }
    public string Type { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public string Location { get; set; }
}
