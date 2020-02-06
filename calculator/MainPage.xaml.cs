using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
//Jerry Compton
//CS481
//Assignment 2 -- CALCULATOR
//This file contains all of the logic for my calculator


namespace calculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        //VARIABLES NEEDED
        string math_operator; // This will be either +, -, /, or x
        double first_num; //The first number in the math expression
        double second_num; // The second number in the math expression
        bool is_first_operand = true;//Initially on first operand in the math expression.
        int count = 0;//initial count used for restricting the LENGTH of the number inputted into the calculator

        
        //is_select_operator is true if the user has already selected an operator
        //is_first_after_select_op is true if it is the first number selected after selecting an operator
        bool is_select_operator = false; //default to false because the user has not selected operator yet
        bool is_first_after_select_op = true; //default to true because it is initially the first digit after selecting the operator

        //Handler for when a number is selected
        void on_select_num(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;
            string num = button.Text; //number pressed

            //IF THE NUMBER HAS NOT REACHED ITS MAX LENGTH
            if(count <= 11) 
            {

                if (is_select_operator)//If the user has selected an operator
                {
                    //if it is the first digit after selecting the operator
                    //then we must first set Text to zero
                    if (is_first_after_select_op)
                    {
                        this.resultText.Text = "0";//reset to zero first
                        this.resultText.Text += num;
                        is_first_after_select_op = false;
                        count++;

                    }
                    else//it is not the first digit after selecting operator, therefore just add normally
                    {
                        this.resultText.Text += num;
                        count++;
                    }
                }
                else //it is the first number so the Text was already ZERO
                {
                    this.resultText.Text += num; // add on to Text
                    count++;
                }
                double number;//the converted number

                if (double.TryParse(this.resultText.Text, out number))//Convert the text to double
                {
                    this.resultText.Text = number.ToString("N0");
                    if (is_first_operand)
                    {
                        first_num = number;

                    }
                    else
                    {
                        second_num = number;

                    }

                }
            }

        }



        //When the "=" button is pressed to solve equation
        void on_compute(object sender, EventArgs e)
        {
            double result = 0; //Our result of the equation

            switch(math_operator)
            {
                case "x":
                    first_num = result = first_num * second_num;
                    this.resultText.Text = Math.Round(result,5).ToString();//Display /w only up to 5 decimal
                    break;
                case "/":
                    first_num = result = first_num / second_num;
                    this.resultText.Text = Math.Round(result,5).ToString();//Display w/ only up to 5 decimal
                    break;
                case "+":
                    first_num = result = first_num + second_num;
                    this.resultText.Text = Math.Round(result, 5).ToString();//Display w/ only up to 5 decimal
                    break;
                case "-":
                    first_num = result = first_num - second_num;
                    this.resultText.Text = Math.Round(result, 5).ToString();//Display w/ only up to 5 decimal

                    break;
            }
            
            is_first_operand = false; //Allow to continue operating on result
            count = 0;//reset count (length of input)
            is_select_operator = false; //reset to default
            is_first_after_select_op = true; //reset to default
        }



        //Handler for when an Operator is selected
        void on_select_operator(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            math_operator = button.Text; //extract the operator
            is_first_operand = false; //now we need the second operand
            //this.resultText.Text = "0"; //i default this back to zero before the user inputs the next number
            count = 0; //reset count
            is_select_operator = true; //the select operator has been pressed -> true
        }



        //Resets the Display text when cleared and resets the variables
        //Also makes sure it is back to FIRST OPERAND of the equation
        void on_clear(object sender, EventArgs e)
        {
            this.resultText.Text = "0";
            first_num = 0;
            second_num = 0;
            is_first_operand = true; //reset to default
            count = 0;//reset count
            is_select_operator = false; //reset to default
            is_first_after_select_op = true; //reset to default

        }




    }

}
