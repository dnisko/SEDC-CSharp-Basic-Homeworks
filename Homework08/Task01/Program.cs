using Task01.Models;

namespace Task01
{
    internal class Program
    {
        #region Task1

        /*
        Task 1

        Create an ATM application. A customer should be able to authenticate with card number and pin and should be greeted with a message greeting
        them by full name. After that they can choose one of the following:

        Balance checking - This should print out the current balance of money on their account

            Cash withdrawal - This should try and withdraw cash from the users account and print a message. If it has enough it should print a
        success message that contains the money withdrawn and the balance of money after the withdrawal

            Cash deposition - This should deposit cash on the account and give a message with the new balance of money on the account after the deposit.

            In order for the ATM app to work we need Customers. This ATM asks for the number ( string ) of the card and searches
        through the customers if a card like that exists. After that it asks for a pin. If the Pin matches that customer a welcome
        message is shown and the customer can now choose the options.

            Example
            Welcome to the ATM app
        Please enter your card number:
        > 1234-1234-1234-1234
        Enter Pin:
        > 4325
        Welcome Bob Bobsky!
        What would you like to do:
        Check Balance
        Cash Withdrawal
        Cash Deposit
        > 2
        You withdrew 250$. You have 400$ left on your account.
            Thank you for using the ATM app.

            Bonus: The balance and pin should not be public

            Bonus: The ATM card number to be a number instead of a string. The user should still input 1234-1234-1234-1234.

            Bonus: When the Customer finishes with a transaction a question must pop up if the Customer wants to do another action.
        If not it should print a goodbye message and show up the login menu again.

            Bonus: Add an option to register a new card in the system that store the customer in the system
        if the card number is not used for any other customer
        */

        #endregion

        static void Main(string[] args)
        {
            long cardNumber;
            int pin;

            Customer[] customers = Populate();
            //Console.WriteLine(customers[0].FirstName);
            while (true)
            {
                Console.WriteLine("Enter card number: ");
                string stringCardNo = Console.ReadLine();
                string test = stringCardNo.Replace("-", "");

                if (!long.TryParse(test, out cardNumber) || !stringCardNo.Contains("-"))
                {
                    Console.WriteLine("Enter valid card number (xxxx-xxxx-xxxx-xxxx)\n");
                    continue;
                }

                Console.WriteLine("Enter pin: ");

                if (!int.TryParse(Console.ReadLine(), out pin))
                {
                    Console.WriteLine("Enter valid pin number (xxxx)\n");
                    continue;
                }

                Customer current = FindCard(customers, cardNumber, pin);

                /* PESKI :)
                //foreach (Customer customer in customers)
                //{
                //    if (customer.CardNumber == cardNumber)
                //    {
                //        if (customer.Pin == pin)
                //        {
                //            current = customer;
                //            break;
                //        }

                //        Console.WriteLine("Wrong pin.");
                //        break;
                //    }
                //}
                */

                if (current == null)
                {
                    Console.WriteLine("Card not found, or wrong pin\n");

                    while (true)
                    {
                        Console.WriteLine("Would you like to add an account? (y/n)\n");
                        string userInput = Console.ReadLine().ToLower();

                        if (userInput == "y")
                        {
                            int idNew;
                            string firstNameNew;
                            string lastNameNew;
                            long cardNumberNew = GenerateCardNumber();
                            decimal balanceNew;
                            int pinNew;

                            Console.WriteLine("Enter id: ");
                            if (!int.TryParse(Console.ReadLine(), out idNew))
                            {
                                Console.WriteLine("Wrong input.\n");
                                continue;
                            }

                            Console.WriteLine("Enter first name: ");
                            firstNameNew = Console.ReadLine();

                            Console.WriteLine("Enter last name: ");
                            lastNameNew = Console.ReadLine();

                            Console.WriteLine("Enter balance: ");
                            if (!decimal.TryParse(Console.ReadLine(), out balanceNew))
                            {
                                Console.WriteLine("Wrong input.\n");
                                continue;
                            }

                            Console.WriteLine("Enter pin: ");
                            if (!int.TryParse(Console.ReadLine(), out pinNew))
                            {
                                Console.WriteLine("Wrong input.\n");
                                continue;
                            }

                            Console.WriteLine($"Your new card number is: {cardNumberNew}\n");

                            current = CreateCustomer(idNew, firstNameNew, lastNameNew, pinNew, balanceNew, cardNumberNew);
                            Array.Resize(ref customers, customers.Length + 1);
                            customers[customers.Length - 1] = current;

                        }
                        else if (userInput == "n")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Enter 'y' or 'n'.");
                            continue;
                        }

                        break;
                    }
                    continue;
                }

                Console.WriteLine($"\n\nWelcome {current.FirstName} {current.LastName}\n");
                int choice;

                while (true)
                {
                    Console.WriteLine("What would you like to do?\n" +
                                      "1. Check balance\n" +
                                      "2. Cash Withdrawal\n" +
                                      "3. Cash Deposit");

                    if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                    {
                        Console.WriteLine("Wrong input, please enter number from 1 to 3.\n");
                        continue;
                    }


                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"\nYour balance is: {current.Balance}\n");
                            //Console.WriteLine("Do you want another transaction? (y/n)\n");
                            //Another(Console.ReadLine());;
                            break;
                        case 2:
                            while (true)
                            {
                                Console.WriteLine("Enter amount to withdraw:");
                                if (!int.TryParse(Console.ReadLine(), out int withdraw))
                                {
                                    Console.WriteLine("Wrong amount. Please enter whole number.\n");
                                    continue;
                                }

                                if (withdraw > current.Balance)
                                {
                                    Console.WriteLine("Cannot withdraw more than the current balance.\nTry again.");
                                    continue;
                                }

                                current.Balance -= withdraw;
                                Console.WriteLine($"\nYou withdraw {withdraw} from your account.\n" +
                                                  $"Your new balance is {current.Balance}\n");
                                //Console.WriteLine("Do you want another transaction? (y/n)\n");
                                //Another(Console.ReadLine());
                                break;
                            }
                            break;

                        case 3:
                            while (true)
                            {
                                Console.WriteLine("Enter amount to deposit\n");
                                if (!int.TryParse(Console.ReadLine(), out int deposit))
                                {
                                    Console.WriteLine("Wrong amount. Please enter whole number.");
                                    continue;
                                }

                                if (current.Balance + deposit > long.MaxValue)
                                {
                                    Console.WriteLine("What are you, what are youuuu :)");
                                    continue;

                                }
                                current.Balance += deposit;
                                Console.WriteLine($"You deposit {deposit} to your account.\n" +
                                                  $"Your new balance is {current.Balance}");
                                //Console.WriteLine("Do you want another transaction? (y/n)\n");
                                //Another(Console.ReadLine());
                                break;
                            }
                            break;
                            //default: Console.WriteLine("Something went wrong");
                            //    break;
                    }

                    string another;

                    while (true)
                    {
                        Console.WriteLine("Do you want another transaction? (y/n)\n");
                        another = Console.ReadLine();
                        if (another.ToLower() != "y" && another.ToLower() != "n")
                        {
                            Console.WriteLine("Wrong input. Enter 'y' or 'n'\n");
                            continue;
                        }

                        break;
                    }

                    if (another.ToLower() != "n")
                    {
                        continue;
                    }
                    Console.WriteLine("\nThank you for using our ATM App.");
                    break;
                }

                break;
            }
        }

        //tried to use methods in switch and at the end, but couldn't benefit from them :)
        public static string Another(string another)
        {
            string result = "";// = "Do you want another transaction? (y/n)\n";
            //string another = Console.ReadLine();
            while (true)
            {
                if (another.ToLower() != "y" || another.ToLower() != "n")
                {
                    result += "Wrong input. Enter 'y' or 'n'";
                    return result;
                }

                if (another.ToLower() == "n")
                {
                    result += "$\"Thank you for using our ATM App.";
                    return result;
                }

                break;
            }
            return result;
        }

        public static decimal Withdrawal(Customer customer, decimal withdraw)
        {
            customer.Balance -= withdraw;
            return customer.Balance;
        }

        public static Customer[] Populate()
        {
            Customer c1 = new Customer(1, "Bob", "Bobsky", 1234, 500, 1234123412341234);
            Customer c2 = new Customer(2, "Kevin", "Kevinsky", 5896, 1500, 5846221344855546);
            Customer c3 = new Customer(3, "James", "Bond", 0007, 9999999999, 0000000000000007);
            Customer c4 = new Customer(4, "Dave", "Davesky", 3358, 2500, 3358449624857468);
            Customer c5 = new Customer(5, "Jane", "Janesky", 1111, 200, 9874654132588764);
            //Console.WriteLine(c1.GetInfo());
            Customer[] customers = { c1, c2, c3, c4, c5 };
            return customers;
        }

        public static Customer CreateCustomer(int id, string firstName, string lastName, int pin, decimal balance, long cardNumber)
        {
            return new Customer(id, firstName, lastName, pin, balance, cardNumber);

        }

        static Customer FindCard(Customer[] customers, long cardNo, int pin)
        {
            foreach (Customer customer in customers)
            {
                if (customer.CardNumber == cardNo)
                {
                    if (customer.Pin == pin)
                    {
                        return customer;
                    }

                    //Console.WriteLine("Wrong pin.");
                    break;
                }
            }

            return null;
        }

        public static long GenerateCardNumber()
        {
            Random random = new Random();
            string number = "";

            for (int i = 0; i < 16; i++)
            {
                number += random.Next(0, 10);
            }

            long.TryParse(number, out long cardNo);
            return cardNo;
        }

        /*
        static void Main(string[] args)
        {
            Random random = new Random();
            long cardNumber = random.NextInt64();
            Console.WriteLine($"Your new card number is: {cardNumber}");

            Customer[] customers = Populate();

            Console.WriteLine(customers[0].Balance);

            customers[0].Balance -= 100;
            Console.WriteLine(customers[0].Balance);

            Console.WriteLine(GenerateCardNumber());
            Console.WriteLine(GenerateCardNumber());
            Console.WriteLine(GenerateCardNumber());
        }
        */

    }
}
