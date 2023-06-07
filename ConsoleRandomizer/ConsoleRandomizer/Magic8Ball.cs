using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{
    internal class Magic8Ball
    {
        private Random random = new Random();

        // List of possible answers
        private List<string> answers = new List<string>() {
            "It is certain.",
            "It is decidedly so.",
            "Cannot predict now.",
            "Without a doubt.",
            "Yes definitely",
            "You may rely on it.",
            "As I see it, yes.",
            "Most likely.",
            "Outlook good",
            "Yes.",
            "Signs point to yes.",
            "Reply hazy, try again.",
            "Ask again later.",
            "Better not tell you now.",
            "Cannot predict now.",
            "Concentrate and ask again.",
            "Don't count on it.",
            "My reply is no.",
            "My sources say no.",
            "Outlook not so good.",
            "Very doubtful."
        };

        public Magic8Ball()
        {
        }

        // Display a random answer from the list
        public void Display()
        {
            string randomAnswer = GenerateAnswer();
            Console.WriteLine("The Magic 8 Ball says: " + randomAnswer);
        }

        // Get a random answer from the list
        private string GenerateAnswer()
        {
            int index = random.Next(0, answers.Count);
            return answers[index];
        }
    }
}
