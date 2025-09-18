namespace Persistence.Repositories
{
	public class GenericRepository<TEntity, TKey>(BlogContext blogContext)
		: IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
	{
		public async Task<TEntity?> GetAsync(TKey Id)
		=> await blogContext.Set<TEntity>().FindAsync(Id);

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		=> await blogContext.Set<TEntity>().ToListAsync();

		public async Task AddAsync(TEntity entity)
		=> await blogContext.Set<TEntity>().AddAsync(entity);

		public void Update(TEntity entity)
		=> blogContext.Set<TEntity>().Update(entity);

		public void Delete(TEntity entity)
		=> blogContext.Set<TEntity>().Remove(entity);

		public Task SaveAsync()
		=> blogContext.SaveChangesAsync();
	}
}
