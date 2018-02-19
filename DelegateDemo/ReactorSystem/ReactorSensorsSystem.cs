using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorSystem
{
    public class ReactorSensorsSystem
    {
        public delegate void NuclearReactorWarningHandler(string message, int currentTemp);

        public static int GetTempFromSensor()
        {
            Random random = new Random();
            return random.Next(1_000);
        }

        public void CheckReactorTemperature(int temp, NuclearReactorWarningHandler dlg)
        {
            if (temp > 100)
            {
                ApplyCoolingPolicy();
                dlg("Ractor is getting too hot!", temp);
            }
            else
            {
                Console.WriteLine("No worry! Temperature is still OK!");
            }
            //Do other operations.
        }

        private void ApplyCoolingPolicy()
        {
            //Some important stuff ;).
        }
    }
}
