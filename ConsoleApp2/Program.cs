using System.Diagnostics;
using System.Text;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ===============================
            // Question 01: String vs StringBuilder
            // ===============================

            Stopwatch sw = new Stopwatch();

            sw.Start();
            string productList = "";
            for (int i = 1; i <= 5000; i++)
            {
                productList += "PROD-" + i + ",";
            }
            sw.Stop();
            Console.WriteLine("String time: " + sw.ElapsedMilliseconds + " ms");

            sw.Restart();
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 5000; i++)
            {
                sb.Append("PROD-").Append(i).Append(",");
            }
            sw.Stop();
            Console.WriteLine("StringBuilder time: " + sw.ElapsedMilliseconds + " ms");

            Console.WriteLine("====================================");

            // ===============================
            // Question 02: Ticket Pricing System
            // ===============================

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter day (1-7, 6=Fri, 7=Sat): ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Do you have student ID? (yes/no): ");
            string student = Console.ReadLine().ToLower();

            double price = 0;

            if (age < 5)
                price = 0;
            else if (age <= 12)
                price = 30;
            else if (age <= 59)
                price = 50;
            else
                price = 25;

            Console.WriteLine("Base price: " + price);

            if (price > 0 && (day == 6 || day == 7))
            {
                price += 10;
                Console.WriteLine("Weekend surcharge: +10");
            }

            if (price > 0 && student == "yes")
            {
                double discount = price * 0.2;
                price -= discount;
                Console.WriteLine("Student discount: -" + discount);
            }

            Console.WriteLine("Final price: " + price);

            Console.WriteLine("====================================");

            // ===============================
            // Question 03: Switch Statements
            // ===============================

            string fileExtension = ".pdf";
            string fileType;

            switch (fileExtension)
            {
                case ".pdf":
                    fileType = "PDF Document";
                    break;
                case ".doc":
                case ".docx":
                    fileType = "Word Document";
                    break;
                case ".xls":
                case ".xlsx":
                    fileType = "Excel Spreadsheet";
                    break;
                case ".jpg":
                case ".png":
                case ".gif":
                    fileType = "Image File";
                    break;
                default:
                    fileType = "Unknown File Type";
                    break;
            }

            Console.WriteLine("File type: " + fileType);

            Console.WriteLine("====================================");

            // ===============================
            // Question 04: Ternary Operator
            // ===============================

            int temperature = 35;

            string weatherAdvice =
                temperature < 0 ? "Freezing! Stay indoors." :
                temperature < 15 ? "Cold. Wear a jacket." :
                temperature < 25 ? "Pleasant weather." :
                temperature < 35 ? "Warm. Stay hydrated." :
                "Hot! Avoid sun exposure.";

            Console.WriteLine(weatherAdvice);

            Console.WriteLine("====================================");

            // ===============================
            // Question 05: Password Validation
            // ===============================

            int attempts = 0;

            do
            {
                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                attempts++;

                bool hasUpper = false;
                bool hasDigit = false;
                bool hasSpace = false;

                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpper = true;
                    if (char.IsDigit(c)) hasDigit = true;
                    if (char.IsWhiteSpace(c)) hasSpace = true;
                }

                if (password.Length < 8)
                    Console.WriteLine("Password must be at least 8 characters.");
                if (!hasUpper)
                    Console.WriteLine("Password must contain uppercase letter.");
                if (!hasDigit)
                    Console.WriteLine("Password must contain digit.");
                if (hasSpace)
                    Console.WriteLine("Password must not contain spaces.");

                if (password.Length >= 8 && hasUpper && hasDigit && !hasSpace)
                {
                    Console.WriteLine("Password accepted!");
                    break;
                }

                if (attempts == 5)
                {
                    Console.WriteLine("Account locked");
                    break;
                }

            } while (true);

            Console.WriteLine("====================================");

            // ===============================
            // Question 06: Array Processing
            // ===============================

            int[] scores = { 85, 42, 91, 67, 55, 78, 39, 88, 72, 95, 60, 48 };

            // (a) Failing scores
            foreach (int s in scores)
            {
                if (s < 50)
                    Console.WriteLine("Failing score: " + s);
            }

            // (b) First score above 90
            foreach (int s in scores)
            {
                if (s > 90)
                {
                    Console.WriteLine("First score above 90: " + s);
                    break;
                }
            }

            // (c) Average excluding below 40
            int sum = 0;
            int count = 0;

            foreach (int s in scores)
            {
                if (s >= 40)
                {
                    sum += s;
                    count++;
                }
            }

            Console.WriteLine("Class average: " + (sum / count));

            // (d) Grade ranges
            int A = 0, B = 0, C = 0, D = 0, F = 0;

            foreach (int s in scores)
            {
                if (s >= 90) A++;
                else if (s >= 80) B++;
                else if (s >= 70) C++;
                else if (s >= 60) D++;
                else F++;
            }

            Console.WriteLine($"A:{A} B:{B} C:{C} D:{D} F:{F}");
        }
    }
}
