namespace Models
{
    public class Tag
    {
        public Tag()
        {
            Properties= new HashSet<Property>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Property> Properties { get; set; }

    }
}