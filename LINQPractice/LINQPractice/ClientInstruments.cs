namespace LINQPractice
{
    public static class ClientInstruments
    {
        public static string Concat(this Client a, Client b)
        {
            return
                $"{a.ClientName.FirtsName} {a.ClientName.LastName} - {b.ClientName.FirtsName} {b.ClientName.LastName}";
        }
    }
}