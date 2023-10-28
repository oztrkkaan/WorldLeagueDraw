namespace WorldLeagueDraw.Domain.Entities
{
    public class Group
    {
        public Group(string groupName)
        {
            GroupName = groupName;
        }

        private Group() { }

        public int Id { get; init; }
        public List<Team> Teams { get; private set; } = new();
        public string GroupName { get; init; }

        public List<Draw> Draws { get; private set; } = new();


        public void AddTeam(Team team)
        {
            if (!IsAddebleByTeam(team))
            {
                //TODO: Bu case için custom exception oluşturulmalı.
                throw new InvalidOperationException("This team already exists in this group.");
            }

            if (!IsAddebleByCountry(team))
            {
                //TODO: Bu case için custom exception oluşturulmalı.
                throw new InvalidOperationException("This country is already exists in this group.");
            }

            Teams.Add(team);
        }

        public bool IsAddable(Team team)
        {
            return IsAddebleByTeam(team) && IsAddebleByCountry(team);
        }

        public bool IsAddebleByCountry(Team team)
        {
            return !Teams.Any(m => m.CountryId == team.CountryId);
        }

        public bool IsAddebleByTeam(Team team)
        {
            return !Teams.Any(m => m.Id == team.Id);
        }
    }
}
