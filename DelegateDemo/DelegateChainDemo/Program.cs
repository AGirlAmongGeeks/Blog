using ReactorSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateChainDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hellow from Delegate__Chain__Demo project!");

            var wSystem = new ReactorSensorsSystem();
            var isWeekend = DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
            var warningHandler = new ReactorSensorsSystem.NuclearReactorWarningHandler(SendWarningEmail);
            var smsWarning = new ReactorSensorsSystem.NuclearReactorWarningHandler(new Program().SendWarningSMS);

            while (true)
            {
                Thread.Sleep(1000);
                int temp = ReactorSensorsSystem.GetTempFromSensor();
                if (isWeekend)
                {
                    if(!warningHandler.GetInvocationList().Contains(smsWarning))
                    {
                        warningHandler += smsWarning;
                    }
                }
                else
                {
                    if (warningHandler.GetInvocationList().Contains(smsWarning))
                    {
                        warningHandler -= smsWarning;
                    }
                }

                wSystem.CheckReactorTemperature(temp, warningHandler);
            }
        }

        public static void SendWarningEmail(string message, int currentTemp)
        {
            string emailMsg = message + $"Temperate has changed! Now it equals {currentTemp}";

            //Logic for sending email.

            Console.WriteLine("Email sent!");
        }

        public void SendWarningSMS(string message, int currentTemp)
        {
            string emailMsg = message + $"Temperate has changed! Now it equals {currentTemp}";

            //Logic for texting users.

            Console.WriteLine($"SMS sent! The message was: \n {emailMsg}");
        }
    }
}
