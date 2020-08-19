namespace MySqlDogs.Core
{
    public class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DogGroupId GroupId { get; set; }
        public virtual DogGroup  Group { get; set; }
       
    }
}
