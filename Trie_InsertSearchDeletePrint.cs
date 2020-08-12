using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie_InsertSearchDeletePrint
{

    public class TrieNode
    {
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public bool isEndOfWord;
        public Dictionary<char, int> sizeCount = new Dictionary<char, int>(); // additional operation to perform
        public TrieNode()
        {
            children = new Dictionary<char, TrieNode>();
            isEndOfWord = false;
            sizeCount = new Dictionary<char, int>();
        }
    }

    public class Trie
    {
        public TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }

        public void insert(string word)
        {
            TrieNode current = root;

            for(int i = 0; i < word.Length; i++)
            {
                TrieNode node = null;
                char ch = word[i];
                if (current.children.ContainsKey(ch))
                {
                    node = current.children[ch];
                    current.sizeCount[ch]++; // for additional operation
                }
                if (node == null)
                {
                    node = new TrieNode();
                    current.children.Add(ch, node);
                    current.sizeCount.Add(ch, 1);//for additional operation
                }

                current = node;
            }
            current.isEndOfWord = true;
        }

        public bool search(string word)
        {
            TrieNode current = root;
            for(int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                TrieNode node = null;
                if (current.children.ContainsKey(ch))
                {
                    node = current.children[ch];
                }
                if (node == null)
                    return false;

                current = node;
            }

            return current.isEndOfWord;
        }

        public bool deleteWord(TrieNode root,string word,int index)
        {
            if (index == word.Length)
            {
                if (!root.isEndOfWord)
                    return false;
                root.isEndOfWord = false;
                return root.children.Count == 0; // determine if node has any children node
            }

            char ch = word[index];
            TrieNode node = null;
            if (root.children.ContainsKey(ch))
                node = root.children[ch];
            if (node == null)
                return false;

            bool isPossibleDelete = deleteWord(node, word, index + 1);

            if (isPossibleDelete)
            {
                //root.children.Remove(ch);
                return root.children.Count == 0;
            }

            return false;
        }

        public void printAllWords(TrieNode root,string str)
        {
            TrieNode current = root;
            for(int i = 0; i < 26; i++)
            {
                char ch = (char)(i + 'a');
                str = "";
                TrieNode node = null;
                if (current.children.ContainsKey(ch))
                {
                    str += ch;
                    node = current.children[ch];
                    searchWord(node, str);
                }
            }
        }

        public void searchWord(TrieNode current,string str)
        {
            if (current.isEndOfWord)
                Console.WriteLine(str);
            
            for(int i = 0; i < 26; i++)
            {
                char ch = (char)(i + 'a');
                if (current.children.ContainsKey(ch))
                {
                    searchWord(current.children[ch], str + ch);
                }
            }
        }

        public void autoComplete(TrieNode root,string word)
        {
            TrieNode current = root;

            string str = "";
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                TrieNode node=null;
                if (current.children.ContainsKey(ch))
                {
                    str += ch;
                    node = current.children[ch];
                }
                if (node == null)
                    return;
                current = node;
            }

            findWord(current, str);
        }

        public void findWord(TrieNode current,string str)
        {
            if (current.isEndOfWord)
                Console.WriteLine(str);

            foreach (KeyValuePair<char,TrieNode> node in current.children)
            {
                if (current.children.ContainsKey(node.Key))
                {
                    findWord(node.Value, str + node.Key);
                }
             }
        }

        public int searchNumberOfMathedPrefix(TrieNode root, string word)
        {
            TrieNode current = root;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                TrieNode node = null;
                if (current.children.ContainsKey(ch))
                {
                    //str += ch;
                    node = current.children[ch];
                }
                if (node == null)
                    return 0;

                if (i == word.Length - 1)
                    return current.sizeCount[ch];
                current = node;
            }
            return 0;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Trie trie=new Trie();
            string[] arr = { "go", "goal","gost","ghost","dodge", "me", "eat","eatt", "hackerrank", "hack","bwolpyvjgttwgckffbqt","tibilstiitxdxezomtye",
            "tbdbslbkqwzmlljanwdp"};
            for (int i = 0; i < arr.Length; i++)
            {
                trie.insert(arr[i]); // insert/store every word in Trie
            }

            //Console.WriteLine(trie.search("eat") ? "Found" : "Not Found");
            Console.WriteLine("All words stored in Trie before delete: ");
            trie.printAllWords(trie.root, "");

            //bool d= trie.deleteWord(trie.root, "eat", 0); // Delete a word
           // Console.WriteLine(trie.search("eat") ? "Found" : "Not Found");
            //Console.WriteLine(trie.search("eatt") ? "Found" : "Not Found");

            //Console.WriteLine("All words stored in Trie after delete: ");
            //trie.printAllWords(trie.root, "");

            Console.WriteLine("Words constructed with specific characters: (Auto Complete) ");
            trie.autoComplete(trie.root,"do");

            Console.WriteLine(""+trie.searchNumberOfMathedPrefix(trie.root, "t"));

            Console.Read();
        }
    }
}
