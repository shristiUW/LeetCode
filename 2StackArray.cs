using System;
using System.Drawing;

namespace PracticeLeetcode
{
	public class _StackArray
	{
        int top1Index;
        int top2Index;
		int size;
        int[] stackArray;

        public _StackArray(int size)
		{
			 top1Index = -1;
			top2Index = size;
			this.size = size;
            stackArray = new int[size];
        }
			
		   public int popstack1(int item)
			{
			if (top1Index >= 0)
			{
				int itemstack1 = stackArray[top1Index];
				top1Index--;
				return itemstack1;
			}
			else
			{
				Console.WriteLine("Stack1 Underflow");
				return 0;
			}
			}

			public int popstack2(int item)
			{ if (top2Index < size)
			{
				int itemstack2 = stackArray[top2Index];

				top2Index++;

				return itemstack2;
			}
			else
			{
				Console.WriteLine("Stack2 underflow");
				return 0;
			}
			}

		    void pushStack1(int item)
			{
				if(top1Index<top2Index-1)
				{
                    top1Index++;
					stackArray.SetValue(item, top1Index);
					
				}
				else
				{
					Console.WriteLine("Stack1 is overflowed");
				}
			}
            void pushStack2(int item)
            {
                if (top2Index> top1Index + 1)
                {
                    top2Index--;
                    stackArray.SetValue(item, top2Index);

                }
                else
                {
                    Console.WriteLine("Stack2 is overflowed");
                }
            }

		public void printStack1()
		{
			int index = 0;
			while(stackArray !=null && index<size)
			{
				Console.WriteLine("StackArray" + stackArray[index]);
				index++;
			}
		}
			public static void mainMethod()
			{
			_StackArray ts = new _StackArray(5);
               ts.pushStack1(1);
			ts.pushStack1(2);
			ts.pushStack2(3);
			ts.pushStack2(4);
			ts.pushStack1(5);
			
			ts.printStack1();
			
			}
        
	}
}

