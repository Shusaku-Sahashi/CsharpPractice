using System;
using System.Configuration;

namespace PracticeForlog4net
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AppSettingsReader ar = new AppSettingsReader();
            var numberOfTimes = (int) ar.GetValue("RepeatTimes", typeof(int));
            var textColor = (string) ar.GetValue("TextColor", typeof(string));

            for (var i = 0; i < numberOfTimes; i++)
            {
                Console.WriteLine("Howdy!");
            }
        }
    }
}