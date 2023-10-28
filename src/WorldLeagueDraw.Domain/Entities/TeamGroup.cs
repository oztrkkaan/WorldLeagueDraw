namespace WorldLeagueDraw.Domain.Entities
{
    public class TeamGroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int TeamId { get; set; }
        public int DrawId { get; set; }

        public Draw Draw { get; set; }
        public Team Team { get; set; }
        public Group Group { get; set; }

    }
}
