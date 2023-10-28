namespace WorldLeagueDraw.Domain.Entities
{
    public class Team
    {
        public Team(string name, Country country)
        {
            Name = name;
            Country = country;
        }

        //EF için
        private Team() { }

        public int Id { get; init; }
        public string Name { get; init; }
        public int CountryId { get; init; }
        public Country Country { get; init; }
        public List<Group> Groups { get; private set; }
    }
}
