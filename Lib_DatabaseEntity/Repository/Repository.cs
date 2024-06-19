using Lib_DatabaseEntity.DbContext_SQL_Server;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lib_DatabaseEntity.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Db_Context _db;
        public Repository(Db_Context db)
        {
            _db = db;
        }

        public virtual IQueryable<T> Table => _db.Set<T>();

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression = null!)
        {
            try
            {
                IQueryable<T> query = _db.Set<T>();

                if (expression != null)
                {
                    query = query.Where(expression);
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllIncluding(Expression<Func<T, bool>> expression = null!, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _db.Set<T>();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            // Bổ sung các bảng liên quan vào truy vấn
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _db.Set<T>().FindAsync(id) ?? null!;
        }

        public async Task Insert(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
        }

        public async Task Insert(IEnumerable<T> entities)
        {
            await _db.Set<T>().AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            EntityEntry entityEntry = _db.Entry<T>(entity);
            entityEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(T entity)
        {
            EntityEntry entityEntry = _db.Entry<T>(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                _db.Attach(entity); // Đính kèm đối tượng nếu nó không được theo dõi
            }
            _db.Set<T>().Remove(entity); // Xóa đối tượng
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            var entities = _db.Set<T>().Where(expression).ToList();
            if (entities.Count > 0)
            {
                _db.Set<T>().RemoveRange(entities);
            }
        }

        public async Task Commit()
        {
            await _db.SaveChangesAsync();
        }
    }
}
