using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using LinqExercise.Helpers;

namespace LinqExercise.Linq2Object
{
	public class DeferredOperatorsExamples : IExample
	{
		public DeferredOperatorsExamples ()
		{

		}

		public void Run ()
		{
			ThenByDescendingOperator2nd();
		}

		#region Where Operator
		/*
		 * public static IEnumerable<T> Where<T>(
		 * this IEnumerable<T> source,
		 * Func<T, bool> predicate);
		 * */
		public void WhereOperator ()
		{
			string[] presidents = Helpers.Presidents.GetPresidentsStringArray ();

			//any element which starts with "J" will be yielded in to the output sequence
			IEnumerable<string> sequence = presidents.Where (p => p.StartsWith ("J"));
			foreach (string s in sequence) {
				Console.WriteLine ("{0}", s);
			}
		}

		/*
		 * public static IEnumerable<T> Where<T>(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, int, bool> predicate);
		 * */
		public void WhereOperator2nd ()
		{
			string[] presidents = Helpers.Presidents.GetPresidentsStringArray ();

			//Second Where prototype specifies that predicate method delegate receives an additional integer input elelemt from the input sequence
			//any other element with an odd index number will be yielded into the output sequence
			IEnumerable<string> sequence = presidents.Where ((p,i) => (i & 1) == 1);
			foreach (string s in sequence) {
				Console.WriteLine ("{0}", s);
			}
		}
		#endregion

		#region Select operator

		/*public static IEnumerable<S> Select<T,S>(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, S> selector);
		 * */
		void SelectOperator ()
		{
			string[] presidents = Helpers.Presidents.GetPresidentsStringArray ();

			//return collection of lenghts
			IEnumerable<int> sequence = presidents.Select (p => p.Length);
			foreach (int i in sequence) {
				Console.WriteLine(i);
			}

			//return new objects
			var newObjects = presidents.Select (p => new { p, p.Length });
			foreach (var o in newObjects) {
				Console.WriteLine(o);
			}
		}

		/*public static IEnumerable<S> Select<T,S>(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, int, S> selector);
		 * */
		void SelectOperator2nd ()
		{
			string[] presidents = Helpers.Presidents.GetPresidentsStringArray ();

			//return new objects
			var newObjects = presidents.Select ((p, i) => new { Index = i, Length = p.Length });
			foreach (var o in newObjects) {
				Console.WriteLine("Index is: {0}, Lenght is: {1}", o.Index, o.Length);
			}
		}

		#endregion

		#region SelectMany operator

		/*public static IEnumerable<s> SelectMany<T, S>(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, IEnumerable<S>> selector);
		 * */
		void SelectManyOperator ()
		{
			string[] presidents = Helpers.Presidents.GetPresidentsStringArray ();

			// put all sub collection in to one collection (collections concatenation) 
			IEnumerable<char> chars = presidents.SelectMany (p => p.ToArray ());

			foreach (char c in chars) {
				Console.WriteLine (c);
			}

			Employee[] employees = Employee.GetEmployeesArray ();
			EmployeeOptionEntry[] emOptions = EmployeeOptionEntry.GetEmployeeOptionEntries ();

			var employeeOptions = employees
				.SelectMany (e => emOptions
				            		.Where (eo => eo.id == e.id)
				            		.Select (eo => new {
														id = eo.id,
														optionsCount = eo.optionsCount}));

			foreach (var eo in employeeOptions) {
				Console.WriteLine(eo);
			}
		}

		/*public static IEnumerable<S> SelectMany<T, S>(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, int, IEnumerable<S>> selector);
		 * */
		void SelectManyOperator2nd ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();

			IEnumerable<char> chars = presidents.SelectMany ((p, i) => i < 5 ? p.ToArray () : new char[] {}); 

			foreach (char ch in chars) {
				Console.WriteLine(ch);
			}
		}
		#endregion

		#region Take operator

		/*public static IEnumerable<T> Take<T>{
		 * 	this IEnumerable<T> source,
		 * 	int count);
		 * */
		void TakeOperator ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();

			IEnumerable<string> items = presidents.Take (5);

			foreach (string item in items) {
				Console.WriteLine (item);
			}

			IEnumerable<char> chars = presidents.Take (5).SelectMany (p => p.ToArray ());

			foreach (char ch in chars) {
				Console.WriteLine(ch);
			}
		}

		#endregion

		#region TakeWhile operator
		/*public static IEnumerable<T> TakeWhile<T>)(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, bool> predicate);
		 * */
		void TakeWhileOperator ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();

			IEnumerable<string> sequence = presidents.TakeWhile (p => p.Length < 10);

			foreach (string item in sequence) {
				Console.WriteLine(item);
			}
		}

		/*public static IEnumerable<T> TakeWhile<T>)(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, int, bool> predicate);
		 * */
		void TakeWhileOperator2nd ()
		{

			string[] presidents = Presidents.GetPresidentsStringArray ();

			IEnumerable<string> sequence = presidents.TakeWhile ((p, i) => p.Length < 10 && i < 5);

			foreach (string item in sequence) {
				Console.WriteLine(item);
			}
		}

		#endregion

		#region Skip operator

		/*public static IEnumerable<T> Skip<T>(
		 * 	this IEnumerable<T> source,
		 * 	int count)
		 * */
		void SkipOperator ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();

			IEnumerable<string> sequence = presidents.Skip (1);

			foreach (string item in sequence) {
				Console.WriteLine(item);
			}
		}

		#endregion

		#region SkipWhile operator
		
		/*public static IEnumerable<T> Skip<T>(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, bool> predicate)
		 * */
		void SkipWhileOperator ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();
			
			IEnumerable<string> sequence = presidents.SkipWhile(p => p.Length < 10);
			
			foreach (string item in sequence) {
				Console.WriteLine(item);
			}
		}

		/*public static IEnumerable<T> Skip<T>(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, i, bool> predicate)
		 * */
		void SkipWhileOperator2nd ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();
			
			IEnumerable<string> sequence = presidents.SkipWhile((p, i) => p.Length < 10 && i < 5);
			
			foreach (string item in sequence) {
				Console.WriteLine(item);
			}
		}

		#endregion

		#region Concat operator

		/*public static IEnumerable<T> Concat<T>(
		 * 	this IEnumerable<T> first,
		 * 	IEnumerable<T> second)
		 * */
		void ConcatOperator ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();

			IEnumerable<string> sequence = presidents.Concat (presidents.Skip (5));

			foreach (string item in sequence) {
				Console.WriteLine(item);
			}

			//alternative concatenation with SelectMany operator
			IEnumerable<string> items = new[] {
				presidents.Take(5),
				presidents.Skip(5)
			}.SelectMany(s => s);
									
		}

		#endregion

		#region OrderBy operator

		/*pubic static IOrderedEnumerable<T> OrderBy<T, K>(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, K> keySelector)
		 * where
		 * 	K : IComparable<K>;
		 * */
		void OrderByOperator ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();

			IOrderedEnumerable<string> sequence = presidents.OrderBy (p => p.Length);

			foreach (string item in sequence) {
				Console.WriteLine(item);
			}
		}

		/*pubic static IOrderedEnumerable<T> OrderBy<T, K>(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, K> keySelector,
		 * IComparer<K> comparer);
		 * */
		void OrderByOperator2nd ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();
			MyVowelToConsonantRatioComparer myComparer = new MyVowelToConsonantRatioComparer ();
			IOrderedEnumerable<string> sequence = presidents.OrderBy ((p => p), myComparer);

			foreach (string item in sequence) {
				int vCount = 0;
				int cCount = 0;

				myComparer.GetVowelConsonantCount(item, ref vCount, ref cCount);
				double dRatio = (double)vCount/(double)cCount;

				Console.WriteLine("{0} - {1} - {2}:{3}", item, dRatio, vCount, cCount );
			}
		}
		#endregion

		#region OrderByDescending operator

		/*public static IOrderedEnumerable<T> OrderByDescending<T, K>(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, K> keySelector)
		 * where 
		 * 	K : IComparable<K>;
		 * */
		void OrderByDescendingOperator ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();

			IOrderedEnumerable<string> sequence = presidents.OrderByDescending (p => p.Length);

			foreach (string item in sequence) {
				Console.WriteLine(item);
			}
		}

		/*public static IOrderedEnumerable<T> OrderByDescending<T, K>(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, K> keySelector,
		 * 	IComparer<K> comparer);
		 * */
		void OrderByDescendingOperator2nd ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();
			MyVowelToConsonantRatioComparer myComparer = new MyVowelToConsonantRatioComparer ();

			IOrderedEnumerable<string> sequence = presidents.OrderByDescending ((p => p), myComparer);

			foreach (string item in sequence) {
				int vCount = 0;
				int cCount = 0;
				
				myComparer.GetVowelConsonantCount(item, ref vCount, ref cCount);
				double dRatio = (double)vCount/(double)cCount;
				
				Console.WriteLine("{0} - {1} - {2}:{3}", item, dRatio, vCount, cCount );
			}
		}

		#endregion

		/*Unlike OrderBy and OrderByDescending, ThenBy and ThenByDescending are stable sorts. 
		 * This means it will preserve the input order of the elements of equal keys. 
		 * If we two input elements come into the ThenBy operator in particual order and the key value for both elements is the same, 
		 * the order of the output elements is guaranteed to be maintained.
		 * */

		#region ThenBy operator
		/*public static IOrderedEnumerable<T> ThenBy<T, K>(
		 * 	this IOrderedEnumerable<T> source,
		 * 	Func<T,K> keySelector)
		 * where
		 * 	K : IComparable<K>;
		 * */
		void ThenByOperator ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();

			IOrderedEnumerable<string> sequence = presidents.OrderBy(p => p.Length).ThenBy (p => p);

			foreach (string item in sequence) {
				Console.WriteLine(item);
			}
		}

		/*public static IOrderedEnumerable<T> ThenBy<T, K>(
		 * 	this IOrderedEnumerable<T> source,
		 * 	Func<T,K> keySelector,
		 * 	IComparer<K> comparer);
		 * */
		void ThenByOperator2nd ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();
			MyVowelToConsonantRatioComparer myComparer = new MyVowelToConsonantRatioComparer();

			IOrderedEnumerable<string> sequence = presidents.OrderBy(p => p.Length).ThenBy ((p => p),myComparer);
			
			foreach (string item in sequence) {
				Console.WriteLine(item);
			}
		}

		#endregion

		#region ThenByDescending operator
		/*public static IOrderedEnumerable<T> ThenByDescending<T, K>(
		 * 	this IOrderedEnumerable<T> source,
		 * 	Func<T,K> keySelector)
		 * where
		 * 	K : IComparable<K>;
		 * */
		void ThenByDescendingOperator ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();
			
			IOrderedEnumerable<string> sequence = presidents.OrderBy(p => p.Length).ThenByDescending (p => p);
			
			foreach (string item in sequence) {
				Console.WriteLine(item);
			}
		}
		
		/*public static IOrderedEnumerable<T> ThenByDescending<T, K>(
		 * 	this IOrderedEnumerable<T> source,
		 * 	Func<T,K> keySelector,
		 * 	IComparer<K> comparer);
		 * */
		void ThenByDescendingOperator2nd ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();
			MyVowelToConsonantRatioComparer myComparer = new MyVowelToConsonantRatioComparer();
			
			IOrderedEnumerable<string> sequence = presidents.OrderBy(p => p.Length).ThenByDescending ((p => p),myComparer);
			
			foreach (string item in sequence) {
				Console.WriteLine(item);
			}
		}
		
		#endregion
	}

}

