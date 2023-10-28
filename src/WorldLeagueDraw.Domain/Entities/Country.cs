namespace WorldLeagueDraw.Domain.Entities
{
    public class Country
    {
        public Country(string name)
        {
            Name = name;
        }

        private Country() { }

        public int Id { get; init; }
        public string Name { get; init; }
        public List<Team> Teams { get; private set; }
    }
}
