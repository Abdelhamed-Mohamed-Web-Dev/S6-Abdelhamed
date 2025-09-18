namespace Shared
{
	public record CommentDto
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public int PostId { get; set; }
	}
}
