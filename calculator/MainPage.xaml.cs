using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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




        //Handler for when a number is selected
        void on_select_num(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string num = button.Text; //number pressed


            this.resultText.Text += num; // add on to Text

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



        //When the "=" button is pressed to solve equation
        void on_compute(object sender, EventArgs e)
        {
            double result = 0; //Our result of the equation

            switch(math_operator)
            {
                case "x":
                    first_num = result = first_num * second_num;
                    this.resultText.Text = result.ToString();//Display
                    break;
                case "/":
                    first_num = result = first_num / second_num;
                    this.resultText.Text = result.ToString();//Display
                    break;
                case "+":
                    first_num = result = first_num + second_num;
                    this.resultText.Text = result.ToString();//Display
                    break;
                case "-":
                    first_num = result = first_num - second_num;
                    this.resultText.Text = result.ToString();//Display

                    break;
            }
            is_first_operand = false; //Allow to continue operating on result
        }



        //Handler for when an Operator is selected
        void on_select_operator(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            math_operator = button.Text; //extract the operator
            is_first_operand = false; //now we need the second operand
            this.resultText.Text = "0"; //i default this back to zero before the user inputs the next number
        }



        //Resets the Display text when cleared and resets the variables
        //Also makes sure it is back to FIRST OPERAND of the equation
        void on_clear(object sender, EventArgs e)
        {
            this.resultText.Text = "0";
            first_num = 0;
            second_num = 0;
            is_first_operand = true;

        }




    }

}
