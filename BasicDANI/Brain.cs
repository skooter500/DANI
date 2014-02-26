using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicDANI
{
    public class Brain
    {
        List<Node> nodes = new List<Node>();
        Random random = new Random();

        public Brain(string seed)
        {
            ParseSentence(seed);
        }

        public Brain()
        {
        }

        public Node FindNode(string word)
        {
            foreach (Node node in nodes)
            {
                if (node.Word == word)
                {
                    return node;
                }
            }
            return null;
        }

        public void ParseSentence(string sentence)
        {
            string[] words = sentence.Split(' ');
            for (int i = 0; i < words.Length; i ++)
            {
                // Find the node or create it if necessary
                Node node = FindNode(words[i]);
                if (node == null)
                {
                    node = new Node(words[i], nodes.Count);
                    nodes.Add(node);
                }
                // Now add the following word to the node if there is a following word
                // Better to check to see if the word already exists!
                if (i < (words.Length - 1))
                {
                    Node followNode = FindNode(words[i + 1]);
                    if (followNode == null)
                    {
                        // Use the count if the word is not found because the follow word will be the next word added
                        node.Follows.Add(nodes.Count);
                    }
                    else
                    {
                        node.Follows.Add(followNode.Index);
                    }
                }
            }
        }

        public string GenerateResponse()
        {
            List<string> sentenceWords = new List<string>(); ;

            // Pick a random word to start at
            int current = random.Next(0, nodes.Count);

            do 
            {
                sentenceWords.Add(nodes[current].Word);
                if (nodes[current].Follows.Count == 0)
                {
                    break;
                }
                else
                {

                }
                current = nodes[current].Follows[random.Next(0, nodes[current].Follows.Count - 1)];
            } while (true);

            return string.Join(" ", sentenceWords);

        }

        public void Dump()
        {
            Console.WriteLine("\nDANI's Brain");
            for (int i = 0; i < nodes.Count; i++)
            {
                Console.Write("{0}: {1}: ", nodes[i].Index, nodes[i].Word);
                for (int j = 0; j < nodes[i].Follows.Count; j++)
                {
                    Console.Write(nodes[nodes[i].Follows[j]].Word + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

    }
}
