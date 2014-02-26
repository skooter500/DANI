using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicDANI
{
    class Program
    {
        static void Main(string[] args)
        {
            Brain brain = new Brain();

            Console.WriteLine("Hello. I am DANI");
            while (true)
            {
                Console.Write("Speak human: ");
                string sentence = Console.ReadLine();
                if (sentence.ToLower() == "braindump")
                {
                    brain.Dump();
                    continue;
                }
                brain.ParseSentence(sentence);
                string response = brain.GenerateResponse();
                Console.WriteLine("DANI Says: {0}", response);                
            }
        }
    }
}
