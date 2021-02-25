using Next.Steps.Domain.Interfaces;

namespace Next.Steps.Domain.Entities
{
    public class Hobby : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}