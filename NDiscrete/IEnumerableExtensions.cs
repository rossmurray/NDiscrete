using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDiscrete
{
	public static class IEnumerableExtensions
	{
		public static IEnumerable<T> Scan<T>(this IEnumerable<T> source, Func<T, T, T> accumulator)
		{
			var last = source.First();
			yield return last;
			foreach (var current in source.Skip(1))
			{
				var next = accumulator(last, current);
				yield return next;
				last = next;
			}
		}
	}
}
