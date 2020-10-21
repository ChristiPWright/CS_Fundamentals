// Stats: 
// Guarantee: Search(N), Insert(N), Delete(n)
// Average  : SearchHit(1.39 lg N), Insert(1.39 lg N), Delete(square root of N)
// Ordered Iteration? Yes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
 
namespace BinarySearchTree
{

public class BinarySearchTree<Key>{

    private Node root;
    class Node
    {
        private Key key;
        private Value val;
        private Node left;
        private Node right;
        private int count;

        public Node(Key key, Value val){
            this.key = key;
            this.val = val;
        }
    }

    public int size(){return size(root);}
    private int size(Node x){
        if(x==null){return 0;}
        return x.count;
    }
    
    public void put(Key key, Value val){
        root = put(root, key, val);
    }
    private Node put(Node x, Key key, Value val){
        if(x==null){return new Node(key, val);}
        int cmp = key.compareTo(x.key);
        if (cmp < 0){
            x.left = put(x.left, key, val);
        }
        else if (cmp>0){
            x.right = put(x.right, key, val);
        } else {
            x.val=val;
        };
        x.count = 1 + size(x.left) + size(x.right);
        return x;
    }

    public Value get(Key key){
        Node x = root;
        while (x != null){
            int cmp = key.compareTo(x.key);
            if(cmp < 0){x = x.left;}
            else if (cmp > 0){x = x.right;}
            else if (cmp == 0){return x.val;}
        }
        return null;
    }

    // Delete Min
    public void deleteMin(){root = deleteMin(root);}
    private Node deleteMin(Node x){
        if(x.left == null){return x.right;}
        x.left = deleteMin(x.left);
        x.count = 1 + size(x.left) + size(x.right);
        return x;
    }

    // Hibbard deletion
    public void delete(Key key){
        root = delete(root, key);
    }
    private Node delete(Node x, Key key){
        if (x==null){return null;}
        int cmp = key.compareTo(x.key);
        if (cmp<0){x.left = delete(x.left, key);}
        else if(cmp>0){x.right = delete(x.right, key);}
        else {
            if(x.right == null){return x.left;}
            if(x.left == null){return x.right;}

            Node t=x;
            x = min(t.right);
            x.right = deleteMin(t.right);
            x.left = t.left;

        }
        x.count = size(x.left) + size(x.right) + 1;
        return x;
    }
    static void Main()
    {
        BinarySearchTree binarySearchTree = new BinarySearchTree();
 
        binarySearchTree.put(1);
        binarySearchTree.put(2);
        binarySearchTree.put(7);
        binarySearchTree.put(3);
        binarySearchTree.put(10);
        binarySearchTree.put(5);
        binarySearchTree.put(8);
        Console.WriteLine();
        
        Node node = binarySearchTree.get(5);
        Console.WriteLine(node);
        
        Console.WriteLine("Delete:");
        binarySearchTree.Remove(7);
        Console.WriteLine();
        binarySearchTree.Remove(8);
        Console.WriteLine();
        
        Console.ReadLine();
    }
}
}