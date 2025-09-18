namespace Domain.Entities
{
	public class Comment : BaseEntity<int>
	{
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public Post Post { get; set; }
		public int PostId { get; set; }
	}
}