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
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}
