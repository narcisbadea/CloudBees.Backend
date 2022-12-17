using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBees.BLL.DTOs;

public class AlertsStatsDTO
{
    public int OpenedAlerts { get; set; }
    public int ClosedAlerts { get; set; }
    public DateTime Date { get; set; }
}
