using System;

namespace LINQPractice
{
    public class Client 
    {
        private readonly string _id;
        public readonly Name ClientName;
        private readonly uint _countOfFlights;
        private int _priorityCoefficient;


        //Possibility creating of different clients
        public Client(Name name, string id)
        {
            
            ClientName = name;
            _id = id;
        }


        public Client(Name name, uint countOfFlights, string id)
        {
            ClientName = name;
            _id = id;
            _countOfFlights = countOfFlights;
        }

        public Client(Name name, string id, int priority)
        {
            ClientName = name;
            _id = id;
            _priorityCoefficient = priority;
        }

        public Client(Name name, uint countOfFlights, string id, int priority)
        {
            ClientName = name;
            _id = id;
            _countOfFlights = countOfFlights;
            _priorityCoefficient = priority;
        }


        public string ClientInfo(bool permission)
        {
            if (permission)
                return $"Client {_id} - {ClientName.FullName()} has {_priorityCoefficient} priority, has {_countOfFlights} flight(s)";
            return $"{ClientName} was in air {_countOfFlights} time(s)";
        }

        public void Print(bool permission)
        {
            Console.WriteLine(ClientInfo(permission));
        }

        public int? GetPriority(bool permission)
        {
            if (permission)
                return _priorityCoefficient;
            return null;
        }

        public string GetId(bool permission)
        {
            if (permission)
                return _id;
            return null;
        }

        public uint? GetCountOfFlights(bool permission)
        {
            if (permission)
                return _countOfFlights;
            return null;
        }

        public void SetPriority(bool permission, int newPriority)
        {
            if (permission)
            {
                _priorityCoefficient = newPriority;
            }
        }
    }
}