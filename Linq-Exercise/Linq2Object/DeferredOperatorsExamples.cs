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
			ConcatOperator();
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

	}

}

