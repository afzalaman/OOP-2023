using System;
namespace fishingContest
{
	class Catch
	{
		public double weight { get; }

		public Fish fish { get; }

		public Contest contest { get; }

		public Catch(Fish f, double w,Contest c)
		{
			fish = f;
			weight = w;
			contest = c;
		}

		public double Value()
		{
			return weight * fish.Mult();
		}

		
	}
}

