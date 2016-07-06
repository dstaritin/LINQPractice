using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPractice
{
    class Program
    {
        public static void Main(string[] args)
        {

            // Initialing of clients
            var cl1 = new Client(new Name("Sam", "Sobutilov"), 10, "000021");
            var cl2 = new Client(new Name("Abdul", "Sulahmed", "Musalim"), "000154", 25);
            var cl3 = new Client(new Name("Jack", "Rosting"), 3, "010045", 65);
            var cl4 = new Client(new Name("Sam", "Ruchshleng"), 10, "000932", -4);
            var cl5 = new Client(new Name("Vova", "Crudu"), 4, "000013", 50);
            var cl6 = new Client(new Name("Nicoleta", "Morari"), "000145");

            //Creating client list
            var clientList = new ClientList<Client>() {cl1, cl2, cl3, cl4, cl5, cl6};

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-List of Clients-");
            Console.ResetColor();
            clientList.Print(false);


            clientList.BubbleSorting((a, b) =>
            {
                return string.Compare(a.ClientName.FirtsName, b.ClientName.FirtsName, StringComparison.Ordinal);
            });

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-List of Clients sorted by Firstname-");
            Console.ResetColor();
            clientList.Print(false);


            // Selecting by pozitive priority to IEnumerable
            var IpriorityClientList = from p in clientList
                                        where p.GetPriority(true) > 0
                                        select p;

            //Copying to ClientList and sorting by Priority
            var priorityClientList = ClientList<Client>.CopyToClientList(IpriorityClientList);
            priorityClientList.BubbleSorting((a, b) =>
            {
                //Verifying nullable variables
                var priority = a.GetPriority(true);
                if (priority != null)
                {
                    var i = b.GetPriority(true);
                    if (i != null) return (priority.Value) - (i.Value);
                }
                return 0;
            });

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-Sorted list of Clients with good priority-");
            Console.ResetColor();
            priorityClientList.Print(true);

            //Selecting from clientList and changing priority to 0
            var IzeroPriorityClientList =
                clientList.Select(n =>
                {
                    //Verifying another nullable variable
                    var countOfFlights = n.GetCountOfFlights(true);
                    if (countOfFlights != null)
                        return new Client(n.ClientName, countOfFlights.Value, n.GetId(true), 0);
                    return null;
                });

            //Copying from IEnumerable to ClientList to sort by ID
            var zeroPriorityClientList = ClientList<Client>.CopyToClientList(IzeroPriorityClientList);
            zeroPriorityClientList.BubbleSorting( (a, b) => int.Parse(a.GetId(true)) - int.Parse(b.GetId(true)) );



            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-Rewritten Client list with non-priority sorted by ID-");
            Console.ResetColor();
            zeroPriorityClientList.Print(true);

            //Adding to clientList new Client
            clientList.Add(new Client(new Name("Viorel", "Rares"), "054678"));


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("---Demonstrating of deferring execution system---\n-To Client list was added new Client and now will be printed our non-priority list-");
            Console.ResetColor();

            //Printing IEnumerable collection
            Console.WriteLine("".PadRight(40, '_'));
            foreach (var obj in IzeroPriorityClientList)
            {
                if (obj.ClientName.FirtsName == "Viorel")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    obj.Print(true);
                    Console.ResetColor();
                }
                else
                    obj.Print(true);
            }
            Console.WriteLine("".PadRight(40, '_') + "\n");


            //Exposing method/ Just for practice
            Console.WriteLine(cl1.Concat(cl2));
        }
    }
}
