using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace EZakaz.Dao
{
	public interface IDao<T, IdT>
	{
		T GetById(IdT id, bool shouldLock);
		T FindById(IdT id);
		List<T> FindAll();
	    IList<T> FindAllPaged(int start, int size);
		List<T> FindByExample(T exampleInstance, params string[] propertiesToExclude);
		T FindUniqueByExample(T exampleInstance, params string[] propertiesToExclude);
		T Save(T entity);
		T SaveOrUpdate(T entity);
		void Delete(T entity);
	    
		void CommitChanges();
		int GetTotalRecordCount();
        IEnumerable<T> FindAllPagedSorted(int start, int size, SortDirection sortDirection, string sortField);
        IList<T> FindAllSorted(SortDirection sortDirection, string sortField);
	}
}