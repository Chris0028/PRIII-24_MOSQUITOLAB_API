using System.Text.RegularExpressions;
using Microsoft.AspNetCore.SignalR;

namespace MosquitoLaboratorio.Services.Hub
{
    public class NotificationHub : DynamicHub
    {
        // Add user to Group
        public async Task AddToLaboratoryGroup(string laboratoryId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, laboratoryId);
        }
    }

}
