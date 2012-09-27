using System;
using System.Collections.Generic;

namespace LinqExercise
{
	public class MyFounderNumberComparer : IEqualityComparer<int>
	{
		public MyFounderNumberComparer ()
		{
		}

		#region IEqualityComparer implementation

		public bool Equals (int x, int y)
		{
			return(isFounder(x) == isFounder(y));
		}

		public bool isFounder (int id)
		{
			return(id < 100);
		}

		public int GetHashCode (int i)
		{
			int f = 1;
			int nf = 100;
			return(isFounder(i) ? f.GetHashCode(): nf.GetHashCode());
		}

		#endregion
	}
}

