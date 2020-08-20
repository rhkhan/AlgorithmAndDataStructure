using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie_Longestprefixmatching
{
    class TrieNode
    {
        public Dictionary<char, TrieNode> dic;// = new Dictionary<char, TrieNode>();
        public bool isEndofWord;
        public TrieNode()
        {
            dic = new Dictionary<char, TrieNode>();
            isEndofWord = false;
        }
    }

    class Trie
    {
        public TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }

        public void buildTrie(string word)
        {
            TrieNode current = root;
            for(int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                TrieNode node = null;
                if (current.dic.ContainsKey(c))
                {
                    node = current.dic[c]; // if key is found jump to the next node
                }
                if (node == null)
                {
                    node = new TrieNode(); // else create a new trie node
                    current.dic.Add(c, node); // And add new node to the dictionary
                }
                current = node; // set node to the current
            }
            current.isEndofWord = true; // finally set endofWord to true;
        }

        public void searchTrie(string word,string[] resString,int pos)
        {
            TrieNode current = root;
            string str="";
            for(int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                TrieNode node = null;
                if (current.dic.ContainsKey(c))
                {
                    str += c;
                    node = current.dic[c];
                }
                else
                    return;

                current = node;

                if (current.isEndofWord) // if endofword=true in trie then store this prefix word in the result string
                {
                    resString[pos] = str;
                }
            } // end loop
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            string[] dictionaryofWords = { "are", "area", "base", "cat", "cater", "children", "basement" };
            for (int i = 0; i < dictionaryofWords.Length; i++)
                trie.buildTrie(dictionaryofWords[i]); // building Trie using the given words

            string[] inputstriing = { "caterer", "basemexy", "child","basement" };
            string[] resString = new string[inputstriing.Length];

            for(int i = 0; i < inputstriing.Length; i++)
            {
                trie.searchTrie(inputstriing[i], resString, i); // search trie for maximum prefix for the word
            }

            for (int i = 0; i < resString.Length; i++)
            {
                if(resString[i]!=null)
                 Console.WriteLine(resString[i]);
            }

            Console.Read();
        }
    }
}
