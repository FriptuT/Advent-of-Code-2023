using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puzzle1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "strings.txt"; 

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                int sum = SumOfFirstLastDigits(lines);
                Console.WriteLine($"Sum of numbers created: {sum}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading the file: " + e.Message);
            }



            Console.ReadKey();
        }


        static int SumOfFirstLastDigits(string[] lines)
        {
            int sum = 0;

            foreach (var line in lines)
            {
                int number = GetNumberFromFirstLastDigits(line);
                sum += number;
            }

            return sum;
        }

        static int GetNumberFromFirstLastDigits(string input)
        {
            int number = 0;

            if (string.IsNullOrEmpty(input))
            {
                return 0; // Tratează cazurile speciale
            }

            // Elimină spațiile albe în exces și ia doar cifrele
            string digits = new string(input.Where(char.IsDigit).ToArray());

            if (digits.Length == 1)
            {
                number = (digits[0] - '0') * 10 + (digits[0] - '0');
            }
            else if (digits.Length > 1)
            {
                number = (digits[0] - '0') * 10 + (digits[digits.Length - 1] - '0');
            }

            return number;
        }


    }
}
