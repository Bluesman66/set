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

	}

	class Program
	{
		static void Main(string[] args)
		{

			Set<int> instance = new Set<int>();

			instance.Add(1);
			instance.Add(2);
			instance.Add(3);
			instance.Add(4);
			instance.Add(5);

			instance.Remove(10);
			
			foreach (var item in instance)
			{
				Console.WriteLine(item);
			}

			Console.ReadKey();
		}
	}
}
