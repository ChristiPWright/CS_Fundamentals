// Stats: 
// Guarantee: Search(N), Insert(N), Delete(n)
//Worst-Case: Search(N), Insert(N), Delete(n) 
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

public class BST<Key, Value> where Key : IComparable<Key>{

    private Node root { get; set; }
    class Node
    {
        public Node left;
        public Node right;
        public Key key { get; set; }
        public Value val { get; set; }
        public int count;
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
    
    // public Value get(Key key){
    //     Node x = root;
    //     while (x != null){
    //         int cmp = key.CompareTo(x.key);
    //         if(cmp < 0){x = x.left;}
    //         else if (cmp > 0){x = x.right;}
    //         else if (cmp == 0){return x.val;}
    //     }
    //     return null;
    // }

    public void put(Key key, Value val){
        root = put(root, key, val);
    }
    private Node put(Node x, Key key, Value val){
        if(x==null){
            Node root = new Node(key, val);
            // root.val = val;
            // root.key = key;
            return root;
            
            }
        int cmp = key.CompareTo(x.key);
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
        int cmp = key.CompareTo(x.key);
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

    //Inorder Traversal
    public Iterable<Key> keys(){
        Queue<Key> q = new Queue<Key>();
       inorder(root, q);
       return q;
    }
    private void inorder(Node x, Queue<Key> q){
        if (x ==null){ return; }
        inorder(x.left, q);
        q.Enqueue(x.key);
        inorder(x.right, q)

    }

    static void Main()
    {
        BST bst = new BST(0,0);
 
        bst.put(1);
        bst.put(2);
        bst.put(7);
        bst.put(3);
        bst.put(10);
        bst.put(5);
        bst.put(8);
        Console.WriteLine();
        
        Node node = bst.get(5);
        Console.WriteLine(node);
        
        Console.WriteLine("Delete:");
        bst.delete(7);
        Console.WriteLine();
        bst.delete(8);
        Console.WriteLine();
        
        Console.ReadLine();
    }

    }
    

}