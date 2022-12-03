using CloudBees.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBees.BLL.DTOs;

public class AlertRequestDTO
{
    public string TypeId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Location { get; set; }
}
