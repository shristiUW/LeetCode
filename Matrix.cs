using System;
namespace PracticeLeetcode
{
	public class Matrix
	{
		public Matrix()
		{
		}
		public static void main()
		{
			List<List<int>> arr = new List<List<int>>() { 
			new List<int> { 1, 0, 1 },
			new List<int> { 1, 1, 1 },
			new List<int> { 0, 1, 1 }};


				List<List<int>> copy= SetZeroesbruteForce(arr);
				for(int i=0;i<copy.Count;i++)
				{
					for(int j = 0; j < copy[0].Count;j++)
					{
						Console.Write(copy[i][j] + " ");
					}
					Console.WriteLine();
				}

			char[][] wordSearch = new char[][]
				{ new char[] { 'A','B','C','E'},
				new char[]{'S','F','C','S' },
				new char[]{'A','D','E','E'}
			};
			string strWordSearch = "ABCCED";

			Exist(wordSearch, strWordSearch);




            }
			static List<List<int>> SetZeroesbruteForce(List<List<int>> matrix)
			{

			List<List<int>> copyArr = new List<List<int>>() {
				new List<int> { 1,1,1},
			new List<int>{1,1,1},
			new List<int>{1,1,1}
			};

			for(int i=0;i<matrix.Count;i++)
			{
				for (int j = 0; j < matrix[0].Count;j++)
				{
					if (matrix[i][j]==0)
					{
						for (int k = 0; k < matrix.Count; k++)
						{
							copyArr[k][j] = 0;
						}
						for(int k = 0; k < matrix[0].Count;k++)
						{
							copyArr[i][k] = 0;
						}
						
					}
				}
			}
			return copyArr;
			}

		public static void setZeroHashSet(List<List<int>> matrix)
		{
			HashSet<int> hash = new HashSet<int>();
			
			for(int i=0;i<matrix.Count;i++)

			{
				for(int j = 0; j < matrix[0].Count;j++)
				{
					if(matrix[i][j]==0)
					{
						hash.Add(i);
						hash.Add(j);
					}
				}
			}
		}

        
            public static List<int> SpiralOrder(List<List<int>> matrix)
            {
                List<int> result = new List<int>();
                int bottom = matrix.Count;
                int top = 0; int left = 0;
                int right = matrix[0].Count;


                while (left < right && top < bottom)
                {
                    for (int i = left; i < right; i++)
                    {
                        result.Add(matrix[top][i]);
                    }
                    top++;
                    for (int i = top; i < bottom; i++)
                    {
                        result.Add(matrix[i][right - 1]);
                    }
                    right--;
               if (left >= right || top >= bottom)
                {
                   break;
                }
                for (int i = right - 1; i >= left; i--)
                    {
                        result.Add(matrix[bottom - 1][i]);
                    }
                    bottom--;
                    for (int i = bottom - 1; i >= top; i--)
                    {
                        result.Add(matrix[i][left]);
                    }
                    left++;
                }
                return result;
          
        }
		public static void makeSpiralMatrix()
		{
			List<List<int>> matrix = new List<List<int>>()
			{
				new List<int>(){1,2,3,4},
				new List<int>(){5,6,7,8},
			new List<int>(){9,10,11,12},
               new List<int>(){13,14,15,16}
			};
			List<int> mat =SpiralOrder(matrix);
			for(int i=0; i<mat.Count; i++)
			{
				Console.WriteLine(mat[i]);
			}
		}

		//Word Search problem
		public static bool Exist(char[][] board, string word)
		{
			int r = board.Length;
			int c = board[0].Length;
			// creating a hashset for keeping already visited row column
			HashSet<(int,int)> visited = new HashSet<(int,int)>();
			for( int m =0; m<r; m++)
			{
				for( int n =0; n<c; n++)
				{
					if (board[m][n] == word[0])
				    {
						if(dfs(m, n, 0))
						{
							return true;
						}
					}

				}
			}
			//creaating recursive function and providing row, col and i is the word's index
			bool dfs(int row, int col, int i)
			{
				bool res = false;
				//base case
				if(i==word.Length)

				{
					return true;
				}
				if (row < 0 || col < 0 || row >= board.Length || col >= board[0].Length || visited.Contains((row,col))
					|| board[row][col] != word[i])
				{
					return false;
				}
				visited.Add((row, col));
				res = dfs(row, col + 1, i + 1) || dfs(row, col - 1, i + 1) || dfs(row + 1, col, i + 1) || dfs(row - 1, col, i + 1);
				visited.Remove((row, col));
				return res;
			}
			return false;
		}



    }
}

