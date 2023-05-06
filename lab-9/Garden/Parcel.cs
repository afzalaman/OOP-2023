namespace Garden
{
    class Parcel
    {
        public int Number { get; private set; }

        public Plant Content { get; private set; }

        public int PlantingDate { get; private set; }

        public Parcel() { Content = null; PlantingDate = 0; }

        public void Plant(Plant plant, int date, int no) 
        { 
            if (null == Content) Content = plant; PlantingDate = date; Number = no;
        }

        public void Harvest() { Content = null; }
    }
}
