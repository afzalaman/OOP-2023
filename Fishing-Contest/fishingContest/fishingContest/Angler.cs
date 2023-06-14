using System;
namespace fishingContest
{
	class Angler
	{
		public string name { get; }

		public List<Catch> Catches { get; }

		public Angler(string name)
		{
			this.name = name;
			Catches = new();
		}

		public void Catch(Fish f, double w,Contest c)
		{
			Catches.Add(new Catch(f, w, c));
		}
		public double Points(Contest con)
		{
			double s = 0;
			foreach(Catch c in Catches)
			{
				if(c.contest == con)
				{
					s += c.Value();
				}
			}
			return s;
		}
		public bool Catfish(Contest contest)
		{
			foreach(Catch c in Catches)
			{
				if(c.contest == contest && c.fish.isCatfish())
				{
					return true;
				}
			}
			return false;
		}
	}
}

