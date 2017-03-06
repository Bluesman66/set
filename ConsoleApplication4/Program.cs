using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
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

	}

	class Program
	{
		static void Main(string[] args)
		{
			int[] array = { 10, 20, 30, 40, 50 };

			Set<int> set1 = new Set<int>();
			Set<int> set2 = new Set<int>(array);
			Set<int> set3 = new Set<int>();

			set1.Add(1);
			set1.Add(2);
			set1.Add(3);
			set1.Add(4);
			set1.Add(5);

			set3 = set1.Union(set2);

			foreach (var item in set3)
			{
				Console.WriteLine(item);
			}

			Console.ReadKey();
		}
	}
}
