/*
 * Dalton Carter
 * This program takes user input for a mathematical expression and evaluates it 
 * left to right without adhering to the order of operations.
 */
using System;

namespace StringToMath
{
    class Program
    {
        /// <summary>
        /// Returns the sum of two double values.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        /// <summary>
        /// Returns the difference of two double values.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        /// <summary>
        /// Returns the quotient of two double values.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        static double Divide(double num1, double num2)
        {
            return num1 / num2;
        }

        /// <summary>
        /// Returns the product of two double values.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        /// <summary>
        /// Returns num1 to the power of num2.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        static double Exponent(double num1, double num2)
        {
            return Math.Pow(num1, num2);
        }

        /// <summary>
        /// Returns the remainder of the quotient of two double numbers.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        static double Modulus(double num1, double num2)
        {
            return num1 % num2;
        }

        /// <summary>
        /// Calulates a mathematical expression given as input.
        /// </summary>
        /// <param name="expression"></param>
        static void doCal(string expression)
        {
            // Check for whitespace to remove and evaluate as intended.
            if (expression.Contains(" "))
                expression = expression.Replace(" ", "");

            // Split string into array of just the numbers.
            string[] operand = expression.Split('+', '-', '*', '/', '%', '^');
            // Split string into array of just operators based on operands found.
            string[] operation = expression.Split(operand, StringSplitOptions.None);
            // Numbers array to hold numbers converted from string.
            double[] numbers = new double[operand.Length];

            // Parse the values in operand array to doubles into the numbers array.
            for (int i = 0; i < operand.Length; i++)
            {
                numbers[i] = Double.Parse(operand[i]);           
            }

            // Variable to hold the current value from each operation.
            double answer = numbers[0];

            // Loop through the operator array for each operation of the expression.
            for (int i = 0; i < operation.Length; i++)
            {
                switch (operation[i])
                {
                    // Addition operation.
                    case "+":
                        answer = Add(answer, numbers[i]);
                        break;
                    // Subtraction operation.
                    case "-":
                        answer = Subtract(answer, numbers[i]);
                        break;
                    // Mulitplication operation
                    case "*":
                        answer = Multiply(answer, numbers[i]);
                        break;
                    // Division operation.
                    case "/":
                        answer = Divide(answer, numbers[i]);
                        break;
                    // Modulo operation.
                    case "%":
                        answer = Modulus(answer, numbers[i]);
                        break;
                    // Exponent operation.
                    case "^":
                        answer = Exponent(answer, numbers[i]);
                        break;
                    default:
                        break;
                }
            }

            // Print the expression followed by the final answer.
            Console.WriteLine("Answer: " + answer);

        } // End of doCal.

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a mathematical expression to be evaluated: ");
            string input = Console.ReadLine();

            // Call doCal method.
            doCal(input);
        }
    }
}
