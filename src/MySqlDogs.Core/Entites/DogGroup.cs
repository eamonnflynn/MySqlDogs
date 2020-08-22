namespace MySqlDogs.Core.Entites
{
    public enum DogGroupId :int
    {
            Unknown = 0,
            Hound =1,
            Terrier = 2,
            GunDog = 3,
            Toy = 4,
            Utility,
            Pastoral,
            Working
    }

    public class DogGroup
    {
        public DogGroupId DogGroupId { get; set; }
        public string Name { get; set; }
    }
}
