using System;
using System.Collections.Generic;

namespace MyConsole
{
    // https://leetcode.com/problems/replace-words/submissions/845907998/
    public class ReplaceWordsTrieNode
    {
        TrieNode root;

        public ReplaceWordsTrieNode()
        {
            root = new TrieNode();
        }

        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            GenerateTrie(dictionary);

            var words = sentence.Split(' ');
            var result = new List<string>();
            foreach (var word in words)
            {
                var temp = root;
                foreach (var ch in word)
                {
                    if (temp.Contains(ch))
                    {
                        temp = temp.GetNode(ch);

                        if (temp.IsWordEnd())
                        {
                            break;
                        }
                    }
                    else
                    {
                        // Console.Write("-"+ch+"-");
                        break;
                    }
                }

                if (temp.IsWordEnd())
                {
                    result.Add(temp.GetWord());
                }
                else
                {
                    result.Add(word);
                }
                //Console.Write("*");
            }

            return string.Join(" ", result);
            ;
        }

        public void GenerateTrie(IList<string> dictionary)
        {
            foreach (var word in dictionary)
            {
                var temp = root;
                foreach (var ch in word)
                {
                    if (!temp.Contains(ch))
                    {
                        temp.SetNode(ch);
                    }

                    temp = temp.GetNode(ch);
                    Console.Write("word: " + temp.GetWord());
                }

                temp.SetWordEnd(word);
            }
        }

        public class TrieNode
        {
            bool isWordEnd;
            string word;
            Dictionary<char, TrieNode> children;

            public TrieNode()
            {
                children = new Dictionary<char, TrieNode>();
            }

            public bool Contains(char ch) => children.ContainsKey(ch);

            public TrieNode GetNode(char ch) => children[ch];

            public void SetNode(char ch) => children[ch] = new TrieNode();

            public void SetWordEnd(string word)
            {
                isWordEnd = true;
                this.word = word;
            }

            public string GetWord() => word;

            public bool IsWordEnd() => isWordEnd;
        }
    }
}