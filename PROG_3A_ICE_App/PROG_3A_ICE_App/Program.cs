namespace PROG_3A_ICE_App
{
    class Program
    {

        //Code attribution for below:
        //Author: Open AI
        //AI Chat Model used: ChatGPT
        //AI Chat Link: https://chatgpt.com/share/6809db04-ec4c-8002-a76f-f1afc8f8af77
        //Date Accessed: 24 April 2025

        static void Main()
        {
            var calculator = new TransportFareCalculator();
            IFareStrategy busStrategy = new BusFareStrategy();
            IFareStrategy taxiStrategy = new TaxiFareStrategy();
            IFareStrategy trainStrategy = new TrainFareStrategy();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("🚆 Smart Transportation Fare System 🚆");
                Console.WriteLine("1. Bus");
                Console.WriteLine("2. Taxi");
                Console.WriteLine("3. Train");
                Console.WriteLine("4. Exit");
                Console.Write("\nSelect transport mode [1–4]: ");

                if (!int.TryParse(Console.ReadLine(), out int mode) || mode < 1 || mode > 4)
                {
                    Console.WriteLine("Invalid choice. Press any key...");
                    Console.ReadKey();
                    continue;
                }
                if (mode == 4)
                    break;

                // 1) Pick the base strategy
                IFareStrategy baseStrategy = mode switch
                {
                    1 => busStrategy,
                    2 => taxiStrategy,
                    3 => trainStrategy,
                    _ => throw new InvalidOperationException()
                };

                // 2) Gather inputs
                decimal distance = 0;
                DateTime travelTime = DateTime.Now;

                if (mode == 2 || mode == 3)
                {
                    Console.Write("Enter distance travelled (km): ");
                    while (!decimal.TryParse(Console.ReadLine(), out distance) || distance < 0)
                        Console.Write("Invalid. Enter a non-negative number: ");
                }

                if (mode == 3)
                {
                    Console.Write("Enter travel time (HH:mm): ");

                    // declare once, outside the loop
                    TimeSpan timeInput;

                    // parse into that single variable
                    while (!TimeSpan.TryParse(Console.ReadLine(), out timeInput))
                    {
                        Console.Write("Invalid format. Use HH:mm: ");
                    }

                    travelTime = DateTime.Today + timeInput;
                }

                // 3) Optional discount
                Console.WriteLine("\nApply discount?");
                Console.WriteLine("1. None");
                Console.WriteLine("2. Student (20% off)");
                Console.WriteLine("3. Senior  (30% off)");
                Console.Write("Choice [1–3]: ");
                int dChoice = int.TryParse(Console.ReadLine(), out var dc) ? dc : 1;

                IFareStrategy finalStrategy = baseStrategy;
                if (dChoice == 2) finalStrategy = new DiscountedFareStrategy(baseStrategy, 0.20m);
                if (dChoice == 3) finalStrategy = new DiscountedFareStrategy(baseStrategy, 0.30m);

                // 4) Calculate & display
                calculator.SetStrategy(finalStrategy);
                var fare = calculator.Calculate(distance, travelTime);

                Console.WriteLine($"\nCalculated Fare: {fare:C2}");
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }
        }
    }
}
