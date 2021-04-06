﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random randomizer = new Random();
        int add1;
        int add2;
        int minuend;
        int subtrahend;
        int timeLeft;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;


        public void StartTheQuiz()
        {
            add1 = randomizer.Next(51);
            add2 = randomizer.Next(51);


            plusLeftLabel.Text = add1.ToString();
            plusLabelRight.Text = add2.ToString();

            sum.Value = 0;

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);

            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();

            difference.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);

            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();

            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temp = randomizer.Next(2, 11);
            dividend = divisor * temp;

            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();

            quotient.Value = 0;


            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        public bool ChechkTheAnswer()
        {
            if ((add1 + add2 == sum.Value) &&
                (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value) && (dividend / divisor == quotient.Value))
            {
                return true;
            }
            else
                return false;

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ChechkTheAnswer())
            {

                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time", "Sorry");
                sum.Value = add1 + add2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplier * multiplicand;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;

            }
        }

        private void answer_enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
