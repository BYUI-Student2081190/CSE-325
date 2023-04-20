using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create two varibles to hold my name and location.
            string name = "Christopher Scott";
            string location = "Utah, United States";

            //Display the two varibles to the console.
            Console.WriteLine($"Hello, my name is {name}. I am located in {location}.");

            //Create a varible to hold the current date, but not TIME.
            string currDate = "";

            //Create a DateTime object.
            DateTime todayDate = DateTime.Now;

            //Get the parts of the object we need for today's date.
            int todayYear = todayDate.Year;
            int todayMonth = todayDate.Month;
            int todayDay = todayDate.Day;

            //Set currDate to equal a string made of these parts.
            currDate = $"{todayMonth}/{todayDay}/{todayYear}";

            //Now create a varible to hold the date of christmas this year.
            int dayToChristmas = 0;

            //Call the function.
            ChristmasGenerator();

            //Create a function that gets called to find how many days are left till christmas.
            void ChristmasGenerator() 
            { 
                //Create a check to see if this month is dec.
                if (todayMonth == 12) 
                {
                    //Count the days till Christmas.
                    //Subtract the current day from Christmas Day.
                    dayToChristmas = 25 - todayDay;
                }

                else 
                {
                    //Count the days till Christmas.
                    //Create a varible to break loop.
                    int monthCount = todayMonth;

                    //Create varible to hold the total amount of days in each month.
                    int dayCount = 0;

                    //Create a loop to get how many days there are till Christmas.
                    while (monthCount < 12) 
                    {
                        //Create a new DateTime object.
                        //Now get the number of days in that month.
                        int monthInfo = DateTime.DaysInMonth(todayYear, monthCount);

                        //Add them to the dayCount.
                        dayCount += monthInfo;

                        //Now add to monthCount to break the loop.
                        monthCount++;
                    };

                    //Now that the while loop is over, add 25 to the total, and then set the days to Christmas.
                    dayCount += 25;

                    //Then subtract the currentDay so you do not have too many days.
                    dayCount -= todayDay;

                    dayToChristmas = dayCount;
                };
            };

            //Display today's Date.
            Console.WriteLine();
            Console.WriteLine($"Today's Date: {currDate}");

            //Display the Day's to Christmas.
            //Create a check to see if it is Christmas day or not.

            //Special Message 1.
            if (dayToChristmas == 0) 
            {
                Console.WriteLine();
                Console.WriteLine($"Today is Christmas! Merry Christmas!");
            }

            //Special Message 2.
            else if (dayToChristmas == 1)
            {
                Console.WriteLine();
                Console.WriteLine($"There is {dayToChristmas} day until Christmas.\nAre you excited?");
            }

            //Normal execution.
            else 
            {
                Console.WriteLine();
                Console.WriteLine($"There are {dayToChristmas} days until Christmas.");
            };

            //Now add the example from 2.1 in the C# Programming Yellow Book by Rob Miles.

            double width, height, woodLength, glassArea;

            string widthString, heightString;

            //To help make it user freindly I added some things to it.
            Console.WriteLine();

            //Added this for display.
            Console.WriteLine("Please Enter a width: ");

            widthString = Console.ReadLine();
            width = double.Parse(widthString);

            //Added this for Display.
            Console.WriteLine("Please Enter a height: ");

            heightString = Console.ReadLine();
            height = double.Parse(heightString);

            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height);

            //Added this for display.
            Console.WriteLine();

            Console.WriteLine("The length of the wood is " +
            woodLength + " feet");

            Console.WriteLine("The area of the glass is " +
            glassArea + " square metres");

            //This goes at the bottom to prevent the console from closing.
            Console.WriteLine();
            Console.WriteLine("Press Enter to close the Program: ");
            Console.ReadLine();
        }
    }
}
