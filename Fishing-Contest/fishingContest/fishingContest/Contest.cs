using System;
namespace fishingContest
{
	class Contest
	{
		public string location { get; }

		public Club cl;

		public List<Angler> anglers = new();
		public Contest(string place, Club c)
		{
			location = place;
			cl = c;
		}

		public void Register(string anglerName)
		{
			foreach(Angler a in anglers)
			{
				if(a.name == anglerName)
				{
					return;
				}
			}

			Angler ang = cl.IsMember(anglerName);

			if(ang != null)
			{ 
				anglers.Add(ang);
			}
		}

		public bool AllCatFish()
		{
			foreach(Angler a in anglers)
			{
				if(!a.Catfish(this))
				{
					return false;
				}
			}
			return true;
		}

		public double Point()
		{
			double s = 0;
			foreach(Angler a in anglers)
			{
				s += a.Points(this);
			}
			return s;
		}
	}
}

