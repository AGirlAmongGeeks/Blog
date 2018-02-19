using ReactorSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DelegateDemo.Program;

namespace DelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hellow from DelegateDemo project!");

            var wSystem = new ReactorSensorsSystem();
            var isWeekend = DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
            while(true)
            {
                Thread.Sleep(1000);
                int temp = ReactorSensorsSystem.GetTempFromSensor();
                if (isWeekend)
                {
                    wSystem.CheckReactorTemperature(temp, (new Program()).SendWarningSMS);
                }
                else
                {
                    wSystem.CheckReactorTemperature(temp, SendWarningEmail);
                }
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
