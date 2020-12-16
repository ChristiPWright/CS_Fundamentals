// Stats: 
// Worst-Case: Search(2 log N), Insert(2 log N), Delete(2 log N)
// Average  : SearchHit(1.00 lg N), Insert(1.00 lg N), Delete(1.00 log N)
// Ordered Iteration? Yes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
 
namespace RedBlackBinarySearchTree
{
    public class RedBlackBST<Key, Value> where Key : IComparable<Key>{
        private static Boolean RED = true;
        private static Boolean BLACK = true;
        public class Node {
            public Key key;
            public Value val;
            public Node left;
            public Node right;
            public Boolean color;
        }
        public Boolean isRed(Node x){
            if (x==null){return false;}
            return x.color == RED;
        }

        //Search
        public Value get(Key key){
            Node x=root;
            while(x != null){
                int cmp = key.CompareTo(x.key);
                if (cmp< 0){x = x.left;}
                else if (cmp > 0){x =x.right;}
                else {return x.val;}
            }
            return null;
        }

        private Node rotateLeft(Node h){
            assert isRed(h.right);
            Node x = h.right;
            h.right = x.left;
            x.left = h;
            x.color = h.color;
            h.color = RED;
            return x;
        }
        private Node rotateRight(Node h){
            assert isRed(h.left);
            Node x = h.left;
            h.left = x.right;
            x.right = h;
            x.color = h.color;
            h.color = RED;
            return x;
        }
        private void flipColors(Node h){
            assert !isRed(h); 
            assert isRed(h.left);
            assert isRed(h.right);
            h.color = RED;
            h.left.color = BLACK;
            h.right.color = BLACK;
        }

        //Insert
        private Node put(Node h, Key key, Value val){
            if (h == null){return new Node(key, val, RED);}
            int cmp = key.CompareTo(h.key);
            if (cmp < 0) {h.left = put(h.left, key, val);}
            else if (cmp > 0){h.right = put(h.right, key, val);}
            else h.val = val;

            if(isRed(h.right) && !isRed(h.left)){h= rotateLeft(h);}
            if(isRed(h.left) && isRed(h.left.left)){h=rotateRight(h);}
            if(isRed(h.left) && isRed(h.right)) {flipColors(h);}

            return h;
        }
    }
}