using System;
namespace PracticeLeetcode
{
	public class ReverseLinkedList
	{
		public ReverseLinkedList()
		{ }
			public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int val = 0,ListNode? next =null)
			{
				this.val = val;
				this.next = next;

			}
		}

		public static ListNode ReverseList(ListNode head)
		{
			ListNode prev = null;
			ListNode curr = head;
			ListNode next = null;

			while(curr!=null)
			{
				next = curr.next;
				curr.next = prev;
				prev = curr;
				curr = next;
				
			}
			return prev;

		}
		public static ListNode ReverseListRecursion(ListNode head)
		{
			if(head==null||head.next==null)
			{
				return head;
			}
			ListNode revnode=ReverseListRecursion(head.next);
			if (head.next != null)
			{
                head.next.next = head;
			}
            head.next = null;	
			return revnode;
		}

			public static void createlinkedlist()
			{
			ListNode head = new ListNode(1);
			head.next = new ListNode(2);
			head.next.next = new ListNode(3);
			/*while (head != null)
			{
				Console.WriteLine("Original Linked List" + head.val);
				head = head.next;
			}*/
		ListNode revHead= ReverseListRecursion(head);

            while (revHead != null)
            {
                Console.WriteLine("reversed Linked List" + revHead.val);
                revHead = revHead.next;
            }

        }
		}
	}



