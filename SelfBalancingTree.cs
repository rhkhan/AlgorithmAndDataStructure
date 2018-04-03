using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfBalancingTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node n = new Node();
            insert(n, 2);
            insert(n, 4);
            insert(n, 3);
        }

        static Node insert(Node root, int val)
        {
            if (root == null)
            {
                root = new Node();
                root.val = val;
                root.ht = setHeight(root);
                return root;
            }
            if (val <= root.val)
            {
                root.left = insert(root.left, val);
            }
            else if(val>root.val)
            {
                root.right = insert(root.right, val);
            }
            int balanceFactor = height(root.left) - height(root.right);

            if (balanceFactor > 1)
            {
                if (height(root.left.left) >= height(root.left.right))
                {
                    root = rightRotation(root);
                }
                else
                {
                    root.left = leftRotation(root.left);
                    root = rightRotation(root);
                }
            }
            else if (balanceFactor < -1)
            {
                if (height(root.right.right) >= height(root.right.left))
                {
                    root = leftRotation(root);
                }
                else
                {
                    root.right = rightRotation(root.right);
                    root = leftRotation(root);
                }
            }
            else
                root.ht = setHeight(root);

            return root;
        }

        static Node leftRotation(Node root)
        {
            Node newRoot = root.right;
            root.right = newRoot.left;
            newRoot.left = root;
            root.ht = setHeight(root);
            newRoot.ht = setHeight(newRoot);
            return newRoot;
        }

        static Node rightRotation(Node root)
        {
            Node newRoot = root.left;
            root.left = newRoot.right;
            newRoot.right = root;
            root.ht = setHeight(root);
            newRoot.ht = setHeight(newRoot);
            return newRoot;
        }

        static int setHeight(Node root)
        {
            if (root == null)
                return -1;
            else
                return 1 + Math.Max(height(root.left), height(root.right));
        }

        static int height(Node root)
        {
            if (root == null)
                return -1;
            else
                return root.ht;
        }
    }

    class Node
    {
        public int val;
        public int ht;
        public Node left;
        public Node right;
    }
}
