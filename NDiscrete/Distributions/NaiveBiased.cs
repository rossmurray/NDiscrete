using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDiscrete.Distributions
{
    public class NaiveBiased<T>
    {
		private Tuple<T, double>[] valuesByMass;
		private Random rand;

		/// <summary>
		/// Construct a discrete distribution
		/// </summary>
		/// <param name="valueProbabilities">
		/// Values and their probability to be sampled.
		/// Probabilities should sum to 1.0
		/// </param>
		public NaiveBiased(ICollection<Tuple<T, double>> valueProbabilities)
		{
			this.valuesByMass = valueProbabilities.Scan((a, b) => Tuple.Create(b.Item1, a.Item2 + b.Item2)).ToArray();
			this.rand = new Random();
		}

		/// <summary>
		/// Construct a discrete distribution
		/// </summary>
		/// <param name="valueProbabilities">
		/// Values and their probability to be sampled.
		/// Probabilities should sum to 1.0
		/// </param>
		/// <param name="random">
		/// A provided source of random numbers. interface later
		/// </param>
		public NaiveBiased(ICollection<Tuple<T, double>> valueProbabilities, Random random)
		{
			this.valuesByMass = valueProbabilities.Scan((a, b) => Tuple.Create(b.Item1, a.Item2 + b.Item2)).ToArray();
			this.rand = random;
		}

		/// <summary>
		/// Returns an element from the distribution, according to the provided probabilities.
		/// </summary>
		public T Sample()
		{
			foreach(var pair in this.valuesByMass)
			{
				var i = rand.NextDouble();
				if(i < pair.Item2)
				{
					return pair.Item1;
				}
			}
			return this.valuesByMass[this.valuesByMass.Length - 1].Item1;
		}
    }
}
