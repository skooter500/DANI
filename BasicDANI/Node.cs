using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicDANI
{
    public class Node
    {
        private int index;
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        private string word;
        public string Word
        {
            get { return word; }
            set { word = value; }
        }
        private List<int> follows = new List<int>();
        public List<int> Follows
        {
            get { return follows; }
            set { follows = value; }
        }

        public Node(string word, int index)
        {
            this.word = word;
            this.index = index;
        }
    }
}
