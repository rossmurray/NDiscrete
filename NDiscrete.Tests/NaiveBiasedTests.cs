using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDiscrete.Distributions;

namespace NDiscrete.Tests
{
	[TestClass]
	public class NaiveBiasedTests
	{
		[TestMethod]
		public void Sample_DoesNotThrow()
		{
			var probs = new[] { 0.2, 0.1, 0.1, 0.3, 0.2, 0.1 };
			var dist = new NaiveBiased<int>(probs.Select(x => Tuple.Create(1, x)).ToArray());
			for (int i = 0; i < 100; i++)
			{
				var r = dist.Sample();
				//should not throw
			}
		}

		[TestMethod]
		public void Sample_ReturnsAllPossibilities()
		{
			var probs = new[]
			{
				Tuple.Create(1, 0.1),
				Tuple.Create(2, 0.3),
				Tuple.Create(3, 0.6)
			};
			var dist = new NaiveBiased<int>(probs);
			var samples = Enumerable.Range(1, 10000).Select(x => dist.Sample()).ToArray();
			Assert.IsTrue(samples.Any(x => x == 1));
			Assert.IsTrue(samples.Any(x => x == 2));
			Assert.IsTrue(samples.Any(x => x == 3));
		}
	}
}
