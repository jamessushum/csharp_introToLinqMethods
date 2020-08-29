using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display fruits from the collection that starts with the letter 'L'
            List<string> fruits = new List<string>()
            {
                "Lemon",
                "Apple",
                "Orange",
                "Lime",
                "Watermelon",
                "Loganberry"
            };

            IEnumerable<string> LFruits = from fruit in fruits
            where fruit.StartsWith("L")
            select fruit;

            foreach (string fruit in LFruits)
            {
                Console.WriteLine($"{fruit}");
            }
            Console.WriteLine("----------");

            // Display numbers from collection that are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };

            IEnumerable<int> fourSixMultiples = numbers.Where(num => num % 4 == 0 || num % 6 == 0);

            foreach (int num in fourSixMultiples)
            {
                Console.WriteLine($"{num}");

            }
            Console.WriteLine("----------");

            // Order names alphabetically in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather",
                "James",
                "Xavier",
                "Michelle",
                "Brian",
                "Nina",
                "Kathleen",
                "Sophia",
                "Amir",
                "Douglas",
                "Zarley",
                "Beatrice",
                "Theodora",
                "William",
                "Svetlana",
                "Charisse",
                "Yolanda",
                "Gregorio",
                "Jean-Paul",
                "Evangelina",
                "Viktor",
                "Jacqueline",
                "Francisco",
                "Tre"
            };

            List<string> descend = names.OrderByDescending(n => n).ToList();

            descend.ForEach(name => Console.WriteLine($"{name}"));
            Console.WriteLine("----------");

            // Sort numbers in ascending order
            List<int> numbersToSort = new List<int>()
            {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };

            List<int> ascend = numbersToSort.OrderBy(n => n).ToList();

            ascend.ForEach(num => Console.WriteLine($"{num}"));
            Console.WriteLine("----------");

            // Output how many numbers are in the list
            List<int> numbersToCount = new List<int>()
            {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };

            int counted = numbersToCount.Count;
            Console.WriteLine($"{counted}");
            Console.WriteLine("----------");

            // Sum the amounts in list
            List<double> purchases = new List<double>()
            {
                2340.29,
                745.31,
                21.76,
                34.03,
                4786.45,
                879.45,
                9442.85,
                2454.63,
                45.65
            };

            double sumOfPurchases = purchases.Sum();
            Console.WriteLine($"{sumOfPurchases}");
            Console.WriteLine("----------");

            // Find the most expensive price
            List<double> prices = new List<double>()
            {
                879.45,
                9442.85,
                2454.63,
                45.65,
                2340.29,
                34.03,
                4786.45,
                745.31,
                21.76
            };

            double mostExpensive = prices.Max();
            Console.WriteLine($"{mostExpensive}");
            Console.WriteLine("----------");

            // Find the perfect squares from the list
            List<int> wheresSquaredo = new List<int>()
            {
                66,
                12,
                8,
                27,
                82,
                34,
                7,
                50,
                19,
                46,
                81,
                23,
                30,
                4,
                68,
                14
            };

            List<int> perfectSquares = wheresSquaredo.Where(n =>
                {
                    double res = Math.Sqrt(n);
                    return res % 1 == 0;
                }

            ).ToList();
            perfectSquares.ForEach(n => Console.WriteLine(n));
            Console.WriteLine("----------");

            // Display number of millionaires per bank
            List<Customer> customers = new List<Customer>()
            {
                new Customer() { Name = "Bob Lesman", Balance = 80345.66, Bank = "FTB" },
                new Customer() { Name = "Joe Landy", Balance = 9284756.21, Bank = "WF" },
                new Customer() { Name = "Meg Ford", Balance = 487233.01, Bank = "BOA" },
                new Customer() { Name = "Peg Vale", Balance = 7001449.92, Bank = "BOA" },
                new Customer() { Name = "Mike Johnson", Balance = 790872.12, Bank = "WF" },
                new Customer() { Name = "Les Paul", Balance = 8374892.54, Bank = "WF" },
                new Customer() { Name = "Sid Crosby", Balance = 957436.39, Bank = "FTB" },
                new Customer() { Name = "Sarah Ng", Balance = 56562389.85, Bank = "FTB" },
                new Customer() { Name = "Tina Fey", Balance = 1000000.00, Bank = "CITI" },
                new Customer() { Name = "Sid Brown", Balance = 49582.68, Bank = "CITI" }
            };

            List<MillionairesByBank> MillionairesReport = (
                from customer in customers group customer by customer.Bank into millionGroup select new MillionairesByBank
                {
                    Bank = millionGroup.Key,
                        Num = millionGroup.Where(c => c.Balance >= 1000000).Count()
                }
            ).ToList();

            foreach (MillionairesByBank entry in MillionairesReport)
            {
                Console.WriteLine($"{entry.Bank}: {entry.Num}");
            }
        }

    }

    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }

    public class MillionairesByBank
    {
        public string Bank { get; set; }
        public double Num { get; set; }
    }
}