using System;

public interface IRepository<T> where T : BaseEntity
{
	void Insert(T obj);

	void Update(T obj);

	void Remove(T obj);

	T Select(T obj);

	IList<T> SelectAll(T obj);
}
