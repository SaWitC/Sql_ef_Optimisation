using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;
using Microsoft.Identity.Client;
using sql_ef_optimisation.Models;

namespace sql_ef_optimisation
{
    public class SampleData
    {
        public static async Task Initialise()
        {
            using (AppDbContext dbContext = new AppDbContext())
            {

                var games = new List<Game>();
                if (!dbContext.Games.Any())
                {
                    for (int i = 0; i < 20; i++)
                    {
                        var game = GenerateGame();
                        games.Add(game);
                    }

                    await dbContext.Games.AddRangeAsync(games);
                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.Users.Any())
                {
                    var users = new List<User>();
                    for (int i = 0; i < 1500; i++)
                    {
                        users.Add(GenerateUser(games));
                    }

                    await dbContext.Users.AddRangeAsync(users);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private static User GenerateUser()
        {
            var userGenerator = new Faker<User>()

                .RuleFor(u => u.Id, Guid.NewGuid().ToString())
                .RuleFor(u => u.UserName, f => f.PickRandom(names))
                .RuleFor(u => u.Email, f => f.PickRandom(names) + f.Random.Int() + f.PickRandom(emails));
            
            return userGenerator.Generate();
        }

        private static User GenerateUser(List<Game> games)
        {
            Random rand = new Random();
            var userGenerator = new Faker<User>()

                .RuleFor(u => u.Id, Guid.NewGuid().ToString())
                .RuleFor(u=>u.Games,f=>f.Random.ListItems(games,rand.Next(1,5)))
                .RuleFor(u => u.UserName, f => f.PickRandom(names))
                .RuleFor(u => u.Email, f => f.PickRandom(names) + f.Random.Int() + f.PickRandom(emails));

            return userGenerator.Generate();
        }


        private static Game GenerateGame()
        {
            var gameGenerator = new Faker<Game>()

                .RuleFor(u => u.Id, Guid.NewGuid().ToString())
                .RuleFor(u => u.Title, f => f.PickRandom(gameTitles))
                .RuleFor(u => u.Cost, f => f.Random.Double())
                .RuleFor(u => u.IsAction, f => f.Random.Bool())
                .RuleFor(u => u.IsDeleted, f => f.Random.Bool())
                .RuleFor(u => u.Updated, DateTime.Now)
                .RuleFor(u => u.Created, DateTime.Now)
                .RuleFor(u => u.ActionPercent, f=>f.Random.Int(0,100))

                .RuleFor(u => u.Description, f => f.Random.String());
            return gameGenerator.Generate();
        }

        //data arrays

        private static string[] names = new[] { "nick", "user", "ivan", "oleg", "nika", "kiril" };
        private static string[] emails = new[] { "@gmail.com", "@email.com", "yandex.com"};

        private static string[] gameTitles = new[] { "mario", "balance", "minecraft", "redball", "pockemon" };


        //@gmail.com
    }
}
