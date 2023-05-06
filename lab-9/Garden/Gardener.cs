namespace Garden
{
    class Gardener
    {
        public Gardener(Garden k) { garden = k; }

        public void Plant(int i, Plant plant, int date)
        {
            garden[i].Plant(plant, date, i);
        }

        public void Harvest(int i) { garden[i].Harvest(); }

        public Garden garden { get; }
    }
}
