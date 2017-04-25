namespace DataAccess.GenericRepository
{
    using System.Data.Entity;
    using System.Linq;

    public class GenericRepository<T> : DbSet<T> where T : class
    {
        private PhotoGalleryContext _dbContext;

        private DbSet<T> _dbSet;

        public GenericRepository()
        {
            _dbContext = new PhotoGalleryContext();
            _dbSet = _dbContext.Set<T>();
        }

        public GenericRepository(PhotoGalleryContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public IQueryable<T> GetAllRecords()
        {
            return _dbSet.Select(x => x);
        }

        public void InsertRecord(T entity)
        {
            _dbSet.Add(entity);
        }

        public void InsertSaveRecord(T entity)
        {
            this.InsertRecord(entity);
            this.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
