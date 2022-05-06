using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Services
{
    public interface IGenericService<T>
    {
		Task<List<T>> GetAll();
		Task GetById(int id);
		Task<T> Insert(T entity);
		Task<T> Update(T entity);
		Task Delete(int id);
	}
}
