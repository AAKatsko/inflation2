using System.Net;

class Program
{
    static void Main()
    {
        var s = Console.ReadLine().Split();
        string country = s[0];
        DateTime start = DateTime.Parse(s[1]);
        DateTime end = DateTime.Parse(s[2]);
        var link = CalculateInflationRate(country, start, end);
        WebClient client = new WebClient();
        using (Stream response = client.OpenRead(link))
        {
            using (StreamReader reader = new StreamReader(response))
            {
                Console.WriteLine(reader.ReadLine());
            }
        }
        Console.ReadKey();
    }
    public static Uri CalculateInflationRate(string country, DateTime start, DateTime end)
    {
        return new Uri($"https://www.statbureau.org/calculate-inflation-rate-json?country={country}&start={start}&end={end}");
    }

}
