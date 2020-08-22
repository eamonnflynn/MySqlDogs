namespace MySqlDogs.Core.Entites
{
    public class Dog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BreedId { get; set; }
        public virtual Breed Breed
        {
            get;
            set;
        }

        public string Colour { get; set; }

        public int Age { get; set; }

    }
}
