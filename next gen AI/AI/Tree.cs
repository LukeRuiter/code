 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    class Node
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        private Node next;

        public Node Next
        {
            get { return next; }
            set { next = value; }
        }


        private Node prev;

        public Node Prev
        {
            get { return prev; }
            set { prev = value; }
        }

        private Node child;

        public Node Child

        {
            get { return child; }
            set { child = value; }
        }


        public Node(int id,Node pre,Node nxt,Node chld)
        {
            ID = id;
            Prev = pre;
        }



        void addNode(Node n)
        {
            if (child == null)
            {
                child = n;
            }
            else
            {
                child.addSibling(n);
            }
        }

        void addSibling(Node n)
        {
            if (next == null)
            {
                next = n;
                next.prev = this;
            }
            else 
            {
                next.addSibling(n);
            }
        }

        void DisplayTree()
        {
            Debug.Log(id.ToString());

            if (next != null)
            {
                Debug.Log(id + "*");
                next.DisplayTree();
            }

            if (child != null)
            {
                Debug.Log(id.ToString() + "_");
                child.DisplayTree();
            }
        }
    }
}
