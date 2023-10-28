namespace WorldLeagueDraw.Domain.Entities
{
    public class DrawGroup
    {
        public int Id { get; set; }
        public int DrawId { get; set; }
        public int GroupId { get; set; }
        public Draw Draw { get; set; }
        public Group Group { get; set; }
    }
}
