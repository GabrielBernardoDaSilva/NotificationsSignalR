using API.Data;
using API.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Hubs
{
    public class DashboardHub : Hub
    {
        private readonly Context _context;
        public DashboardHub(Context context)
        {
            _context = context;
        }
        public async Task SendDashboardUpdate(string dashupdate)
        {
            await Clients.All.SendAsync("ReceiveDashUpdate", dashupdate);
        }
        public async Task SendNewChart(ChartData chartUpdate)
        {
            chartUpdate.Status = (short)0;
            _context.Add(chartUpdate);
            await _context.SaveChangesAsync();
        }
        public async Task SendChartsUpdate()
        {
            while (true)
            {
                var charts = await _context.Charts.Where(x => x.Status == 0).ToListAsync();
                if (charts.Count > 0)
                {
                    await Clients.All.SendAsync("ReceiveChartsUpdate", charts);
                    charts.ForEach(item => item.Status = 2);
                    _context.UpdateRange(charts);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}