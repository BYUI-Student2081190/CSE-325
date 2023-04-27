using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimedMathQuiz
{
    public partial class Form1 : Form
    {
        // Create a Random Object called 'randomizer'
        // to generate random numbers.
        Random randomizer = new Random();

        // Addition problem varibles to store the numbers
        // for the addition problems.
        int addend1;
        int addend2;

        // Subtraction integers to store numbers
        // for the subtraction problems.
        int minuend;
        int subtrahend;

        // Multiplication integers to store numbers
        // for the multiplication problems.
        int multiplicand;
        int multiplier;

        // Division integers to store numbers
        // for the division problems.
        int dividend;
        int divisor;

        // This integer keeps track of the remaining
        // time on the quiz.
        int timeLeft;

        // DateTime object to hold today's date.
        string currentDate;

        /* Method to start the quiz, start timer, and 
          place all the numbers where they should go.*/
        public void StartTheQuiz() 
        {
            // Get the values for addend1 and addend2.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the numbers into strings.
            // Then display.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // Make sure 'sum' equals zero before adding numbers to it.
            sum.Value = 0;

            // Add code for Subtraction.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);

            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();

            difference.Value = 0;

            // Add code for Multiplication.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);

            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();

            product.Value = 0;

            // Add code for Division.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;

            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();

            quotient.Value = 0;

            // Start the Timer.
            timeLeft = 30;
            timeLabel.Text = timeLeft + " seconds";
            timer1.Start();
        }

        /* Method that checks the user's answers to
          see if they are right.*/
        private bool CheckTheAnswer() 
        {
            // If the answers are right, return true.
            if ((addend1 + addend2 == sum.Value) &&
                (minuend - subtrahend == difference.Value) &&
                (multiplicand * multiplier == product.Value) &&
                (dividend / divisor == quotient.Value))
            {
                return true;
            }

            // Else return false.
            else 
            {
                return false;
            }
        }

        public Form1()
        {
            InitializeComponent();

            // When form gets create, also display date.
            GenerateDate();
        }

        /* Method to generate a string Date for the computer to
         use.*/
        private void GenerateDate() 
        {
            // Create a new dateTime object.
            DateTime todayDate = DateTime.Now;

            int day = todayDate.Day;
            int month = todayDate.Month;
            int year = todayDate.Year;

            // Create a array to hold the month in
            // string form.
            string[] months = new string[13];
            months[0] = null;
            months[1] = "January";
            months[2] = "Febuary";
            months[3] = "March";
            months[4] = "April";
            months[5] = "May";
            months[6] = "June";
            months[7] = "July";
            months[8] = "August";
            months[9] = "September";
            months[10] = "October";
            months[11] = "November";
            months[12] = "December";

            //Now have month equal the month it has an index of.
            string currMonth = months[month];

            //Now set up the string.
            currentDate = (day) + " " + (currMonth) + " " + (year);

            //Now set the text of the form element date.
            date.Text = currentDate;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Call the quiz to start.
            StartTheQuiz();
            // Stop the user from selecting the button
            // again during the quiz.
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer returns true,
                // stop the timer, and display a message.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                    "Congradulations!");

                // Enable the start button again so the user can
                // play again.
                startButton.Enabled = true;
            }

            else if (timeLeft > 0) 
            {
                // If CheckTheAnswer returns false, keep on ticking.
                // Decrease the time by one second and display the
                // new time.
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }

            else 
            {
                // If the user ran out of time, stop timer,
                // show a messageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Times up!";
                MessageBox.Show("You did not finish in time.", "Sorry!");

                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;

                // Enable the start button so the user can play again.
                startButton.Enabled = true;
            }
        }
    }
}
