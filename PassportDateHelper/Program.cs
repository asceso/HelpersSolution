using System;

namespace PassportDateHelper
{
    class Program
    {
        private static int[] PassportAges = new int[] { 14, 20, 45 };

        static void Main()
        {
            Console.WriteLine("Input date in format dd.mm.yyyy");
            var input_date_string = Console.ReadLine();
            DateTime.TryParse(input_date_string, out DateTime birthday);
            int age = (int)((DateTime.Now - birthday).TotalDays / 365);
            int passport_index = GetMinIndexForPassportAges(age);
            if (passport_index == -1)
            {
                Console.WriteLine("No passport");
            }
            else
            {
                Console.WriteLine($"Birthday is : {birthday.ToShortDateString()}");
                Console.WriteLine($"Age is : {age}");
                Console.WriteLine($"Passport last age : {PassportAges[passport_index]}");

                DateTime receive_passport_start = birthday.AddYears(PassportAges[passport_index]);
                DateTime receive_passport_end = receive_passport_start.AddDays(14);

                Console.WriteLine($"Passport received between {receive_passport_start.ToShortDateString()} - {receive_passport_end.ToShortDateString()}");
            }
            Console.ReadKey();
        }
        static int GetMinIndexForPassportAges(int age)
        {
            if (age >= PassportAges[0] && age < PassportAges[1]) return 0;
            else if (age >= PassportAges[1] && age < PassportAges[2]) return 1;
            else if (age >= PassportAges[2]) return 2;
            return -1;
        }
    }
}
