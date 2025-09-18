namespace Domain.Entities
{
	public class Category : BaseEntity<int>
	{
        public string Name { get; set; }
        public IEnumerable<Post> Posts { get; set; } = new List<Post>();
    }
}
