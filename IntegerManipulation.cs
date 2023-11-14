using System;
namespace PracticeLeetcode
{
	public static class IntegerManipulation
	{
		

		public static string removeX(string N, char X)
		{
			string res=N;
			for(int i=0;i<N.Length-1;i++)
			{
				if (N[i] ==X && (N[i]-'0' < N[i+1]-'0'))
				{
					res= N.Remove(i, 1);
				}
			}
			if(res==N)
			{
				for(int i=N.Length-1;i>=0;i--)
				{
					if (N[i]==X)
					{
						res = N.Remove(i, 1);
						break;
					}
				}
			}
			return res;

		}
            //Driver Code
            public static void Main()
		{
			string N = "2142";
			char X = '2';
			string res = removeX(N, X);
		}
	}
}

