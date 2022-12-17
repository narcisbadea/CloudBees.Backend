using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBees.BackgroundWorker.Entitis.Stats;

public class AlertsStats
{
    public string Id { get; set; }
    public int OpenedAlerts { get; set; }
    public int ClosedALerts { get; set; }
    public DateTime Date { get; set; }
}
