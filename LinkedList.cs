using System;
namespace PracticeLeetcode
{
	public class LinkedList
	{
		public class node
		{ public node next;
	      public int val;
		public node(int val)
			{
				this.val = val;
			}
		}
		public LinkedList()
		{
			

		}
		static node getMiddle(node head)
		{
			if (head == null || head.next==null) 
			{
				return head;
			}
			node slow = head;
			node fast = head.next;
			while(fast!=null)
			{
				fast = fast.next;
				if (fast != null)
				fast = fast.next;
				slow = slow.next;
			}
			return slow;
			
		}
		static int getLength(node head)
		{
            int length = 0;
            while (head != null)
            {
                length++;
                head = head.next;

            }
            int midlength = length / 2;
			return midlength;

        }
        static node getMiddleDifferentSol(node head)
        {
			int midlength = getLength(head);
			

			int count = 0;
			node middleNode = head;
			while(count< midlength)
			{
                middleNode = middleNode.next;
				count++;
			}
			return middleNode;

        }
        static void removeDuplicates(node head)
		{
			HashSet<int> hs = new HashSet<int>();
			//pick element one by one
			node current = head;
			node previous = null;
			while (current != null)
			{
				if (hs.Contains(current.val))
				{ previous.next = current.next; }
				else
				{ hs.Add(current.val);
					previous = current;

				}
                current = current.next;
            }
		}
		//print linkedlist
		static void printList(node head)
		{
			while(head != null)
			{
				Console.Write(head.val +" ");
				head = head.next;
			}
		}


        //the linked list
        //	10->12->11->11->12->11->10
        public static void linkedlist()
        {

            node start = new node(10);
            start.next = new node(12);
            start.next.next = new node(11);
            start.next.next.next = new node(11);
            start.next.next.next.next = new node(12);
            start.next.next.next.next.next = new node(11);
            start.next.next.next.next.next.next = new node(10);
            Console.WriteLine("Linkedlist before removing duplicates");

		node middle=	getMiddle(start);
			Console.WriteLine("Middle node " + middle.val);
            printList(start);
            removeDuplicates(start);
			
            Console.WriteLine("\nLinked list after removing duplicates");
			node mid =getMiddleDifferentSol(start);
            Console.WriteLine("Middle node " + mid.val);
            printList(start);

			ListNode list1 = new ListNode(1);
			list1.next = new ListNode(2);
			list1.next.next = new ListNode(3);
			ListNode list2 = new ListNode(1);
			list2.next = new ListNode(4);
			list2.next.next = new ListNode(5);
			ListNode[] lists = new ListNode[]{ list1, list2,list1 };
			MergeKLists(lists);
        }
		public class ListNode
		{
			public int val;
			public ListNode? next;
			public ListNode(int val=0, ListNode? next =null)
			{
				this.val = val;
				this.next = next;
			}
			
		}

		//Merge K sorted List
		public static ListNode MergeKLists(ListNode[] lists)
		{
			//base conditions
			if(lists ==null || lists.Length==0)
			{ return null; }
			if(lists.Length==1)
			{
				return lists[0];
			}
			ListNode merged = lists[0];
			for(int i=1; i<lists.Length; i++)
			{
				merged = MergeTwoList(merged, lists[i]);
				
			}
			return merged;
		}

		static ListNode  MergeTwoList(ListNode list1, ListNode list2)
		{
			ListNode res = new ListNode();
			ListNode currentNode =res;
			//basecase
			if(list1==null)
			{
				return list2;
			}
			if(list2 ==null)
			{
				return list1;
			}
			while (list1 != null && list2 != null)
				{
				if (list1.val <= list2.val)
				{
					currentNode.next = list1;
					list1 = list1.next;
				}
				else
				{
					currentNode.next = list2;
					list2 = list2.next;
				}
				currentNode = currentNode.next;
			}
			if(list1==null)
			{
				currentNode.next = list2;
			}
			if(list2==null)
			{
				currentNode.next = list1;
			}
			return res.next;
		}


    }
}

