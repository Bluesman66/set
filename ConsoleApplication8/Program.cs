using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsSubset
{

	public class Set<T> : IEnumerable<T> where T : IComparable<T>
	{
		// Создание экземпляра класса List<T>

		private readonly List<T> _items = new List<T>();

		public Set()
		{
		}

		public Set(IEnumerable<T> items)
		{
			AddRange(items);
		}

		#region Добавление элементов в множество

		public void Add(T item)
		{
			// Если такой элемент уже существует в множестве, выдать исключение
			if (Contains(item))
			{
				throw new InvalidOperationException("Такое значение уже содержится в множестве");
			}

			_items.Add(item);
		}

		#endregion

		#region Добавление нового множества элементов

		public void AddRange(IEnumerable<T> items)
		{
			foreach (T item in items)
			{
				Add(item);
			}
		}

		#endregion

		#region Удаление элементов из множества

		public bool Remove(T item)
		{
			return _items.Remove(item);
		}

		#endregion

		#region Проверка наличия элемента в множестве
		public bool Contains(T item)
		{
			return _items.Contains(item);
		}
		#endregion

		#region Количество элементов в множестве
		public int Count
		{
			get
			{
				return _items.Count;
			}
		}
		#endregion

		#region Нумератор
		public IEnumerator<T> GetEnumerator()
		{
			return _items.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return _items.GetEnumerator();
		}
		#endregion

		#region Объедиение множеств

		public Set<T> Union(Set<T> other)
		{
			Set<T> result = new Set<T>(_items);

			foreach (T item in other)
			{
				if (!Contains(item))
				{
					result.Add(item);
				}
			}
			return result;
		}

		#endregion

		#region Разность множеств

		public Set<T> Difference(Set<T> other)
		{
			Set<T> result = new Set<T>(_items);
			foreach (T item in other)
			{
				result.Remove(item);
			}

			return result;
		}

		#endregion

		#region Пересечение множеств

		public Set<T> Intersection(Set<T> other)
		{
			Set<T> result = new Set<T>();

			foreach (T item in _items)
			{
				if (other.Contains(item))
				{
					result.Add(item);
				}
			}
			return result;
		}

		#endregion

		#region Подмножество 

		public bool IsSubset(Set<T> other)
		{

			Set<T> result = new Set<T>(_items);

			foreach (T item in other)
			{
				result.Remove(item);
			}

			if (result.Count == 0)
			{
				return true;
			}

			return false;
		}

		#endregion

	}

	class Program
	{
		static void Main(string[] args)
		{
			bool rez;

			int[] array = { 1, 2, 3, 4, 5, 6 };

			Set<int> set1 = new Set<int>();
			Set<int> set2 = new Set<int>(array);

			set1.Add(1);
			set1.Add(2);
			set1.Add(3);
			set1.Add(4);
			// set1.Add(7); //Расскоментировать!

			rez = set1.IsSubset(set2);

			Console.WriteLine("Множество set1 является подмножеством множества set2: {0} ", rez);

			Console.ReadKey();
		}
	}
}
