using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classs_Set
{
	class Program
	{
		static void show (HashSet<int> set )
		{
			foreach (var item in set)
			{
				Console.Write(item);
			}        
		}

		static void Main(string[] args)
		{
		   int[] array = { 3, 4, 5, 6, 7, 8, 9 };
		   int[] arr = { 1, 3, 5, 7, 9};

		   HashSet<int> set1 = new HashSet<int> ();
		   HashSet<int> set2 = new HashSet<int> (array);
		   HashSet<int> set3 = new HashSet<int> (arr);

		   #region Добавление нового элемента в множество
		   
		   set1.Add(1);
		   set1.Add(2);
		   set1.Add(3);
		   set1.Add(4);
		   set1.Add(5);
		   
		   #endregion

		   #region Объединение множеств

		   Console.Write("set1:" );
		   show(set1);
		   
		   Console.Write(" UnionWith set2:");
		   show(set2);

		   Console.Write(" = set1: ");
		   set1.UnionWith(set2);
		   show(set1);

		   Console.WriteLine("\n\n");

		   #endregion
					
		   #region Разность множеств

		   Console.Write("set1:");
		   show(set1);

		   Console.Write(" ExceptWith set2:");
		   show(set2);

		   Console.Write(" = set1: ");
		   set1.ExceptWith(set2);
		   show(set1);

		   Console.WriteLine("\n\n");

		   #endregion
		   
		   #region Пересечение двух множеств

		   Console.Write("set1:");
		   show(set1);

		   Console.Write(" IntersectWith set3:");
		   show(set3);

		   Console.Write(" = set1: ");
		   set1.IntersectWith(set3);
		   show(set1);

		   Console.WriteLine("\n\n");

		   #endregion

		   #region Симметрическая разность множеств

		   Console.Write("set2:");
		   show(set2);

		   Console.Write(" IntersectWith set3:");
		   show(set3);

		   Console.Write(" = set2: ");
		   set2.SymmetricExceptWith(set3);
		   show(set2);

		   Console.WriteLine("\n\n");

		   #endregion

		   #region Подмножество

			Console.Write("set1: ");
			show(set1);

			Console.Write(" set3: ");
			show(set3);

			Console.WriteLine("\n\n");
			
			Console.Write("Множество set1 являелся подмножеством set3 = ");

			Console.Write(set1.IsSubsetOf(set3));

			Console.WriteLine("\n\n");
			
			#endregion

		   #region Копирование множества в массив
						
			int[] mass = new int[10];

			set3.CopyTo(mass);

			Console.WriteLine("Копирование множества в массив: ");

			for (int i = 0; i < mass.Length; i++)
			{
				Console.WriteLine(mass[i]); 
			}
			
			#endregion

		   #region Удаление множества

			Console.WriteLine(" \n Удаление множества set3 \n");

			Console.Write("Множество set3: ");
			show(set3);

			set3.Clear();

			show(set3);

			Console.WriteLine(" Множество удалено");
			Console.Write(" \n \n");

			#endregion

			Console.ReadKey();
		}
	}
}
