using System;
namespace fishingContest
{
	class Club
	{
		public List<Contest> contests = new();

		public List<Angler> members = new();

		//public void Organize(string place)
		//{
		//	contests.Add(new Contest(place, this));
		//}

		public Contest Organize(string place)
		{
			Contest c = new Contest(place, this);
            contests.Add(c);
			return c;
		}


		public void Enter(string name)
		{
			foreach (Angler a in members)
			{
				if (a.name == name) return;
			}
			members.Add(new Angler(name));
		}

		public Tuple<bool,Contest> Best()
		{
			bool l = false;
			Contest con = null;

			double max = 0;

			foreach(Contest c in contests)
			{
				if (!c.AllCatFish()) continue;

				double s = c.Point();

				if(l)
				{
					if(s>max)
					{
						con = c;
						max = s;
					}
				}
				else
				{
					l = true;
					con = c;
					max = s;
				}

			}
			return new Tuple<bool, Contest>(l, con);

			
		}

		public Angler IsMember(string name)
		{
			foreach(Angler a in members)
			{
				if (a.name == name) return a;
			}
			return null;
		}

		public Tuple<int,double> catfishes(string anglerName,string contestName)
		{
			int noCatfish = 0;
			double value = 0;

			foreach(Contest a in contests)
			{
				if(a.location == contestName)
				{
					foreach(Angler b in a.anglers)
					{
						if(b.name == anglerName)
						{
							if (!b.Catfish(a)) return new Tuple<int, double>(noCatfish, value);

							foreach(Catch c in b.Catches)
							{
								if(c.fish.isCatfish() && c.contest == a)
								{
									noCatfish++;
									value += c.Value();
								}
							}
						}
						break;
					}
				}
				break;
			}
			return new Tuple<int, double>(noCatfish, value);
        }

	}
}

