using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrieDS
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Trie trie = new Trie();

            for(int i=1;i<=n;i++)
            {
                trie.insert(Console.ReadLine());
            }

            Console.WriteLine("Enter word to determine the existence: ");
            string word = Console.ReadLine();
            if (trie.search(word))
                Console.WriteLine("Yes, word does exist");
            else
                Console.WriteLine("No, word does not exist");

            Console.Read();
        }
    }


    public class Trie
    {
        private class TrieNode
        {
           public Dictionary<char, TrieNode> children; // char as key and it will reference another trie node
           public bool endofWord;
            public TrieNode()
            {
                children = new Dictionary<char, TrieNode>();
                endofWord = false;
            }

        }

        private readonly TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }

        public void insert(string word)
        {
            TrieNode current = root;
            for (int i=0;i<word.Length;i++)
            {
                TrieNode node = null;
                char ch = word[i];
                if (current.children.ContainsKey(ch))
                {
                     node = current.children[ch]; // data in the current level
                }
                if (node == null)
                {
                    node = new TrieNode();
                    current.children[ch]= node; // put the current character as key and reference to new trienode
                }
                 current = node;
                //node = current;
            }

            current.endofWord = true; // finished inserting all the characters of a word
        }

        public bool search(string word)
        {
            TrieNode current = root;
            for (int i = 0; i < word.Length; i++)
            {
                TrieNode node = null;
                char ch = word[i];
                
                if (current.children.ContainsKey(ch))
                {
                    node = current.children[ch];
                }
                if (node==null)
                {
                    return false;
                }
                current = node; // set the recent travelled node as current;
            }

            return current.endofWord; // return true if current's endofWord is true otherwise false;

        }

    }
}
