using System;
using System.Collections.Generic;
using Teste_GFT_CreditSuisse.DomainTrade;

namespace Teste_GFT_CreditSuisse
{
    class Program
    {
        static void Main(string[] args)
        {
            var lstTrades = new List<Trade>();
            string aux;
            DateTime dateRef = new DateTime(1900, 1, 1);
            int nTrades = 0;

            //Clear the screen and start again.
            Console.Clear();

            bool parameterValid = false;
            do
            {
                try
                {
                    Console.Write("Report the reference date, in format (mm/dd/yyyy): ");
                    aux = Console.ReadLine();

                    var day = aux.Substring(3, 2);
                    var month = aux.Substring(0, 2);
                    var year = aux.Substring(6, 4);

                    dateRef = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                    parameterValid = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The reference date is invalid.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } while (parameterValid == false);

            parameterValid = false;
            do
            {
                try
                {
                    Console.Write("Report the amount of trades: ");
                    nTrades = Convert.ToInt32(Console.ReadLine());
                    parameterValid = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The amount of trades invalid.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

            } while (parameterValid == false);

            //get Inputs
            input(dateRef, nTrades, ref lstTrades);

            //print Output
            output(lstTrades);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void input(DateTime dateRef, Int32 nTrades, ref List<Trade> trades)
        {
            Console.WriteLine("");
            Console.WriteLine("Input");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Report " + nTrades.ToString() + " trades in sequence of fields (trade amount, client’s sector, next pending payment in format (mm/dd/yyyy)).\n" +
                              "And press <ENTER>");
            Console.WriteLine("");

            for (int i = 0; i < nTrades; i++)
            {
                bool validateInput = false;
                do
                {
                    try
                    {
                        Console.Write((i + 1).ToString() + "-");
                        var auxTradeStart = Console.ReadLine();
                        var auxTradeArray = auxTradeStart.Split(" ");

                        var dayTrade = auxTradeArray[2].Trim().Substring(3, 2);
                        var monthTrade = auxTradeArray[2].Trim().Substring(0, 2);
                        var yearTrade = auxTradeArray[2].Trim().Substring(6, 4);
                        DateTime nextPayment = new DateTime(Convert.ToInt32(yearTrade), Convert.ToInt32(monthTrade), Convert.ToInt32(dayTrade));

                        //Question 2
                        //var IsPoliticallyExposed = Convert.ToBoolean(auxTradeArray[3].Trim());

                        var trade = new Trade(
                                              Convert.ToDouble(auxTradeArray[0].Trim()),
                                              auxTradeArray[1].Trim(),
                                              nextPayment,
                                              dateRef /*,IsPoliticallyExposed*/
                                              );

                        trades.Add(trade);
                        validateInput = true;
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This trade has a invalid information.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("");
                    }

                } while (validateInput == false);
            }
        }

        static void output(List<Trade> trades)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Output");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("");

            if (trades.Count > 0)
            {
                foreach (var item in trades)
                {
                    Console.WriteLine(item.category);
                    //Console.WriteLine("{0}, {1}, {2}, {3}", item.Value, item.ClientSector, item.NextPaymentDate.ToString("MM/dd/yyyy"), item.category);
                }


                Console.WriteLine(" ");
                Console.WriteLine("Processing completed successfully.");
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}

