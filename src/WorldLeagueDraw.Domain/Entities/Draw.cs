namespace WorldLeagueDraw.Domain.Entities
{
    public class Draw
    {
        public readonly int[] AcceptableGroupCounts = new int[] { 4, 8 };
        public Draw(string creatorFullName)
        {
            CreatorFullName = creatorFullName;
        }

        private Draw() { }

        public Guid UId { get; init; } = Guid.NewGuid();
        public List<Group> Groups { get; private set; }
        public string CreatorFullName { get; init; }



        public void Make(List<Country> countries, List<Group> groups)
        {
            if (!AcceptableGroupCounts.Any(m => m == groups.Count))
            {
                throw new InvalidOperationException("Unsupported group count.");
            }

            foreach (var country in countries)
            {
                foreach (var group in groups)
                {
                    if (groups.Count == 8 && group.Teams.Count >= 4
                        || groups.Count == 4 && group.Teams.Count >= 8)
                    {
                        continue;
                    }
                   
                    var isTeamAddable = false;
                  
                    while (!isTeamAddable)
                    {
                        var randomTeam = country.Teams.OrderBy(m => Guid.NewGuid()).FirstOrDefault();

                        isTeamAddable = group.IsAddable(randomTeam);

                        if (isTeamAddable)
                        {
                            group.AddTeam(randomTeam);
                        }
                    }
                }
            }
            Groups = groups;
        }
    }
}

