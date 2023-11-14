using System;
using System.Text;
using static PracticeLeetcode.LinkedList;

namespace PracticeLeetcode
{
	public class BinaryTree
	{
		public BinaryTree()
		{

		}
		public class TreeNode
		{
			public int val;
			public TreeNode left;
			public TreeNode right;
			public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
			{
				this.val = val;
				this.left = left;
				this.right = right;
			}

		}
		public static int maxDepth(TreeNode root)
		{
			int depth = 0;
			if (root != null)
			{
				/*	int left= maxDepth(root.left);
                    int right= maxDepth(root.right);
                    return (Math.Max(left, right))+1;*/


				depth = Math.Max(maxDepth(root.left), maxDepth(root.right));

				return depth + 1;


			}
			else
			{ return 0; }
		}
		public static void main()
		{
			TreeNode root = new TreeNode(3);
			root.left = new TreeNode(9);
			root.right = new TreeNode(20);
			root.right.left = new TreeNode(15);
			root.right.right = new TreeNode(7);

			//Console.WriteLine("Max Depth : " + maxDepthusingQueue(root));
			Console.WriteLine("Max Depth : " + maxDepth(root));
			//Console.WriteLine(maxDepthUsingStacks(root));

			TreeNode root1 = new TreeNode(5);
			root1.left = new TreeNode(4);
			root1.right = new TreeNode(7);
			root1.right.left = new TreeNode(3);
			root1.right.right = new TreeNode(8);

			if (isValidBinaryTree(root1))
			{
				Console.WriteLine("This is Binary Tree");
			}
			else
			{
				Console.WriteLine("This is not a binary tree");
			}

			levelOrder(root);
			GoodNodes(root1);
			MaxPathSum(root1);
			deserialize(serialize(root1));

		}
		public static int maxDepthUsingStacks(TreeNode root)
		{
			if (root != null)
			{
				var s = new Stack<(TreeNode, int)>();
				s.Push((root, 1));
				var height = 0;
				while (s.Count > 0)
				{
					var (curr, currentDepth) = s.Pop();
					height = Math.Max(height, currentDepth);
					if (curr.left != null) s.Push((curr.left, currentDepth + 1));
					if (curr.right != null) s.Push((curr.right, currentDepth + 1));

				}
				return height;
			}
			return 0;

		}


		public static int maxDepthusingQueue(TreeNode root)
		{
			if (root == null)
			{
				return 0;
			}
			var depth = 0;

			var queue = new Queue<TreeNode>();
			queue.Enqueue(root);
			while (queue.Count != 0)
			{
				int count = queue.Count;

				for (int i = 0; i < count; i++)
				{
					var current = queue.Dequeue();


					if (current.left != null)
					{
						queue.Enqueue(current.left);

					}
					if (current.right != null)
					{
						queue.Enqueue(current.right);
					}
				}
				depth++;
			}
			return depth;

		}
		public static bool isValidBinaryTree(TreeNode root)
		{
			return valid(root, int.MinValue, int.MaxValue);
		}
		public static bool valid(TreeNode root, int min, int max)
		{
			if (root == null)
				return true;
			if (root.val < min || root.val > max)
				return false;
			return valid(root.left, min, root.val) && valid(root.right, root.val, max);


		}
		public static IList<IList<int>> levelOrder(TreeNode root)
		{
			if (root == null)
			{
				return null;
			}
			List<IList<int>> res = new List<IList<int>>();

			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);
			while (queue.Count != 0)
			{
				List<int> level = new List<int>();
				int count = queue.Count;
				for (int i = 0; i < count; i++)
				{
					TreeNode node = queue.Dequeue();
					if (node != null)
					{
						level.Add(node.val);
						queue.Enqueue(node.left);
						queue.Enqueue(node.right);
					}


				}
				if (level != null)
				{ res.Add(level); }


			}
			return res;
		}
		static int res = 0;
		public static int GoodNodes(TreeNode root)
		{

			HelperGoodNodes(root, root.val);
			return res;
		}

		public static void HelperGoodNodes(TreeNode node, int maxValue)
		{
			if (node == null)
				return;

			if (node.val >= maxValue)
			{
				res++;
			}
			maxValue = Math.Max(node.val, maxValue);
			HelperGoodNodes(node.left, maxValue);
			HelperGoodNodes(node.right, maxValue);

		}

		/* https://www.youtube.com/watch?v=TO5zsKtc1Ic */

		public static int MaxPathSum(TreeNode root)
		{
			if(root==null)
			{
				return 0;
			}
			int result = int.MinValue;
			dfs(root);
			int dfs(TreeNode node)
				{
				//basecase
				if(node==null)
				{
					return 0;
				}
				int left =dfs(node.left);
				int right = dfs(node.right);
				int max_straight = Math.Max(Math.Max(left, right)+node.val, node.val); //include one of left or right
				int max_othercase = Math.Max(left + right + node.val, max_straight); //include left and right both
				result = Math.Max(result, max_othercase);
				return max_straight;

			}
			
			return result;
		}
        // Encodes a tree to a single string.
        public static string serialize(TreeNode root)
        {
			if(root==null)
			{
				return "";
			}
			Queue<TreeNode> queue = new Queue<TreeNode>();
			StringBuilder str = new StringBuilder();
			queue.Enqueue(root);
			
			while(queue.Count>0)
			{
				int count = queue.Count;
				for(int i=0; i<count; i++)
				{
					TreeNode node = queue.Dequeue();
                   
					if(node==null)
					{
						str.Append("N");
						str.Append(" ");
					}
					else
					{
						
						str.Append(node.val);
						str.Append(" ");

					}
					if(node!= null)
					{
						queue.Enqueue(node.left);
						queue.Enqueue(node.right);
					}
                }
				

			}

            return str.ToString();

        }

        // Decodes your encoded data to tree.
        public static TreeNode deserialize(string data)
        {

			if(data=="")
			{
				return null;
			}
			string[] str = data.Split(" ");
			Queue<TreeNode> queue = new Queue<TreeNode>();
			TreeNode root = new TreeNode(Convert.ToInt32(str[0]));
			queue.Enqueue(root);
			for(int i=1; i<str.Length-1; i+=2)
			{
				TreeNode node = queue.Dequeue();
				if (str[i] != "N")
				{
					node.left = new TreeNode(Convert.ToInt32(str[i]));
					queue.Enqueue(node.left);
				}
				if (str[i + 1] != "N")
				{
					node.right = new TreeNode(Convert.ToInt32(str[i + 1]));
					queue.Enqueue(node.right);
				}

			}

			return root;

		}

    }

}