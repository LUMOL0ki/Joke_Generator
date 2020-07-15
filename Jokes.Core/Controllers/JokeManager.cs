using Jokes.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Jokes.Core.Controllers
{
    public class JokeCollection
    {
        public List<Joke> MyArray { get; set; }
    }

    public class MyArray
    {
        public int id { get; set; }
        public string type { get; set; }
        public string setup { get; set; }
        public string punchline { get; set; }

    }

    public class Root
    {
        public List<MyArray> MyArray { get; set; }

    }

    public class JokeManager
    {
        private readonly HttpClient Client;

        public JokeManager()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://official-joke-api.appspot.com/");
        }

        public async Task<Joke> GetRandomJoke()
        {
            Joke joke = null;

            HttpResponseMessage response = await Client.GetAsync("random_joke");

            if (response.IsSuccessStatusCode)
            {
                joke = await response.Content.ReadAsAsync<Joke>();
            }

            return joke;
        }

        public async Task<Joke> GetGeneralJoke()
        {
            Joke joke = null;

            HttpResponseMessage response = await Client.GetAsync("jokes/general/random");

            if (response.IsSuccessStatusCode)
            {
                joke = (await response.Content.ReadAsAsync<List<Joke>>()).First();
            }

            return joke;
        }

        public async Task<Joke> GetProgrammingJoke()
        {
            Joke joke = null;

            HttpResponseMessage response = await Client.GetAsync("jokes/programming/random");

            if (response.IsSuccessStatusCode)
            {
                joke = (await response.Content.ReadAsAsync<List<Joke>>()).First();
            }

            return joke;
        }
    }
}
