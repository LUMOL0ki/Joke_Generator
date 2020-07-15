using Jokes.Core.Controllers;
using Jokes.Core.Models;
using System;

namespace Jokes.UI.App
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            JokeManager manager = new JokeManager();
            Joke joke = await manager.GetGeneralJoke();
            Console.WriteLine(joke.Setup);
            Console.WriteLine(joke.Punchline);
        }
    }
}
