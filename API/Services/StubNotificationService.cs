using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class StubNotificationService : INotificationService
    {
        public StubNotificationService()
        {
            var customSetting = Startup.Configuration["DefaultConfigSettings:Setting1"];
        }

        public void NotifyPlayer()
        {
            var customSetting = Startup.Configuration["DefaultConfigSettings:Setting2"];
            Console.WriteLine("Stub Notification Service");
        }
    }
}
