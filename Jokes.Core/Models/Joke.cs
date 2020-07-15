using System;

namespace Jokes.Core.Models
{
    public enum CategoryType
    {
        None,
        General,
        Programming
    }

    public class Joke
    {
        public int Id { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; }
        public string Type { get; set; }
    }
}