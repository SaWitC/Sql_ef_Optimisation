using Microsoft.Identity.Client;
using sql_ef_optimisation;

class Progrm
{
    public static async Task Main(string[] args)
    {

        await SampleData.Initialise();
        using (var context = new AppDbContext())
        {
            Console.WriteLine("users count "+context.Users.Count());
            Console.WriteLine("games count"+context.Games.Count());
        }

    }
}



