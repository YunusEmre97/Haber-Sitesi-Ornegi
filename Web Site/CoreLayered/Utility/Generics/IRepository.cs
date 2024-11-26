using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Generics
{
	public interface IRepository<T> where T : class
	{
		Task InsertOneAsync(T entity);
		Task InsertManyAsync(IEnumerable<T> entities);
		Task<T?> FindByKeyAsync(object entityKey);
		Task<T?> FindFirstAsync(Expression<Func<T, bool>>? expression = null);	
		Task<T?> FindLastAsync(Expression<Func<T, bool>>? expression = null);	
		Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>>? expression = null);
		Task UpdateAsync(T entity);
		Task UpdateManyAsync(IEnumerable<T> entities);
		Task DeleteByKeyAsync(object entityKey);
		Task DeleteOneAsync (T entity);
		Task DeleteManyAsync(Expression<Func<T, bool>>? expression = null);
	}
	public abstract class Repository<T> : IRepository<T> where T : class
	{
		protected DbContext _context;
		protected DbSet<T> _set;

		protected Repository(DbContext context)
		{
			_context = context;
			_set = _context.Set<T>(); 
		}
		//Create Entity Section:
		public virtual async Task InsertOneAsync(T entity)
		{
			await _set.AddAsync(entity);
		}
		public virtual async Task InsertManyAsync(IEnumerable<T> entities)
		{
			await _set.AddRangeAsync(entities);
		}

		public virtual async Task<T?> FindByKeyAsync(object entityKey)
		{
			return await _set.FindAsync(entityKey);
		}

		public virtual async Task<T?> FindFirstAsync(Expression<Func<T, bool>>? expression = null)
		{
			return expression != null? await _set.FirstOrDefaultAsync(expression):await
				_set.FirstOrDefaultAsync();
		}

		public virtual async Task<T?> FindLastAsync(Expression<Func<T, bool>>? expression = null)
		{
			return expression != null ? await _set.LastOrDefaultAsync(expression) : await
				_set.LastOrDefaultAsync();
		}

		public virtual async Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>>? expression = null)
		{
			return expression != null ? await _set.Where(expression).ToListAsync() : await
				_set.ToListAsync();
		}

		public virtual async Task UpdateAsync(T entity)
		{
			await Task.Run(() => _set.Update(entity));
		}

		public virtual async Task UpdateManyAsync(IEnumerable<T> entities)
		{
			await Task.Run(() => _set.UpdateRange(entities));
		}

		public virtual async Task DeleteByKeyAsync(object entityKey)
		{
			var entity = await FindByKeyAsync(entityKey);
			if(entity != null)
			{
				await DeleteOneAsync(entity);
			}
		}

		public virtual async Task DeleteOneAsync(T entity)
		{
			await Task.Run(() => _set.Remove(entity));
		}

		public virtual async Task DeleteManyAsync(Expression<Func<T, bool>>? expression = null)
		{
			var entities = await FindManyAsync(expression);
			await Task.Run(()=> _set.RemoveRange(entities));	
		}
	}
}
