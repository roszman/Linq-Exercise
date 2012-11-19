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
            EmptyOperator();
            Console.WriteLine("\nPress any key to close.");
            Console.ReadKey();
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

		#region Reverse operator
		/*public static IEnumerable<T> Reverse<T>(
		 * 	this IEnumerable<T> source);
		 * */
		void ReverseOperator ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray ();

			IEnumerable<string> sequence = presidents.Reverse ();

			foreach (string item in sequence) {
				Console.WriteLine(item);
			}
		}

		#endregion

		#region Join operator
		/*public static IEnumerable<V> Join<T,K,V>(
		 * 	this IEnumerable<T> outer,
		 * 	IEnumerable<U> inner,
		 * 	Func<T, K> outerKeySelector,
		 * 	Func<U, K> innerKeySelector,
		 * 	Func<T, U, V> resultSelector);
		 * */
		void JoinOperator ()
		{
			Employee[] employees = Employee.GetEmployeesArray ();
			EmployeeOptionEntry[] emOptions = EmployeeOptionEntry.GetEmployeeOptionEntries ();

			var employeeOptions = employees
				.Join (
					emOptions,
					e => e.id,
					o => o.id,
					(e, o) => new {
						id = e.id,
						name = string.Format ("{0} {1}", e.firstName, e.lastName),
						options = o.optionsCount
						}
					);
			foreach (var item in employeeOptions) {
				Console.WriteLine(item);
			}
		}

		#endregion

		#region GroupJoin operator

		/*public static IEnumerable<V> GroupJoin<T, U, K, V>(
		 * 	this IEnumerable<T> outer,
		 * 	IEnumerable<U> inner,
		 * 	Func<T, K> outerKeySelector,
		 * 	Func<U, K> innerKeySelector,
		 * 	Func<T, IEnumerable<U>, V> resultSelector
		 * */
		void GroupJoinOperator ()
		{
			Employee[] employees = Employee.GetEmployeesArray ();
			EmployeeOptionEntry[] emOptions = EmployeeOptionEntry.GetEmployeeOptionEntries ();

			//employee options are grouped by e.id and options sequence "os" is passed as argument
			var employesOptions = employees
				.GroupJoin (
					emOptions,
					e => e.id,
					o => o.id,
					(e, os) => new 
						{
						id = e.id,
						name = string.Format ("{0} {1}", e.firstName, e.lastName),
						options = os.Sum (o => o.optionsCount)
						}
			);
			foreach (var item in employesOptions) {
				Console.WriteLine(item);
			}
		}

		#endregion

		#region GroupBy operator

		/*public static IEnumerable<IGrouping<K, T>> GroupBy<T, K>(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, K> keySelector);
		 * */
		void GroupByOperator ()
		{
			EmployeeOptionEntry[] emOptions = EmployeeOptionEntry.GetEmployeeOptionEntries ();
			IEnumerable<IGrouping<int, EmployeeOptionEntry>> outerSequence = emOptions.GroupBy (o => o.id);

			//first eneumerate trough the outer sequence of IGroupings
			foreach (IGrouping<int, EmployeeOptionEntry> keyGroupSequence in outerSequence) {
				Console.WriteLine("Option records for employee: " + keyGroupSequence.Key);

				//now enumerate trough the grouping's sequence of EmployeeOptionEntry elements
				foreach(EmployeeOptionEntry element in keyGroupSequence)
				{
					Console.WriteLine("id={0}, : optionsCount={1} : dateAwarded={2}", element.id, element.optionsCount, element.dateAwarded);
				}

			}
		}

		/*public static IEnumerable<IGrouping<K, T>> GroupBy<T, K>(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, K> keySelector,
		 * 	IEqualityComparer<K> comparer);
		 * */
		void GroupByOperator2nd()
		{
			MyFounderNumberComparer comp = new MyFounderNumberComparer();

			EmployeeOptionEntry[] emOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

			IEnumerable<IGrouping<int, EmployeeOptionEntry>> opts = emOptions
				.GroupBy(o => o.id, comp);

			//First enumerate trough the sequence of IGroupings.
			foreach(IGrouping<int, EmployeeOptionEntry> keyGroup in opts)
			{
				Console.WriteLine("Option records for: " + (comp.isFounder(keyGroup.Key) ? "founder" :"nonfounder"));

				//now enumerate trough the grouping's sequence of EmployeeOptionEntry elements.
				foreach(EmployeeOptionEntry element in keyGroup)
				{
					Console.WriteLine("id={0} : optionsCount= {1} : dateAwarded={2:d}",
					                  element.id, element.optionsCount, element.dateAwarded);
				}
			}
		}

		/*public static IEnumerable<IGrouping<K, T>> GroupBy<T, K, E>(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, K> keySelector,
		 * 	Func<T, E> elementSelector);
		 * */
		void GroupByOperator3rd ()
		{
			EmployeeOptionEntry[] emOptions = EmployeeOptionEntry.GetEmployeeOptionEntries ();
			IEnumerable<IGrouping<int, DateTime>> opts = emOptions
				.GroupBy (key => key.id, element => element.dateAwarded);

			foreach (IGrouping<int, DateTime> keyGroup in opts) {
				Console.WriteLine("Option records for employee: " + keyGroup.Key);

				foreach(DateTime date in keyGroup)
				{
					Console.WriteLine(date.ToShortDateString());
				}
			}
		}

		/*public static IEnumerable<IGrouping<K, T>> GroupBy<T, K, E>(
		 * 	this IEnumerable<T> source,
		 * 	Func<T, K> keySelector,
		 * 	Func<T, E> elementSelector.
		 * 	IEqualityComparer<K> comparer);
		 * */
		void GroupByOperator4th ()
		{
			MyFounderNumberComparer comp = new MyFounderNumberComparer ();
			EmployeeOptionEntry[] emOptions = EmployeeOptionEntry.GetEmployeeOptionEntries ();

			IEnumerable<IGrouping<int, DateTime>> opts = emOptions
				.GroupBy (key => key.id, element => element.dateAwarded, comp);

			foreach (IGrouping<int, DateTime> keyGroup in opts) {
				Console.WriteLine("Option dates for: " + (comp.isFounder(keyGroup.Key) ? "founder" : "nonfounder"));

				foreach(DateTime date in keyGroup)
				{
					Console.WriteLine(date.ToShortDateString());
				}
			}
		}
		#endregion

		#region Distinct operator

		/*public static IEnumerable<T> Distinct<T>(
		 * 	this IEnumerable<T> source);
		 * */
		void DistinctOperator ()
		{
			string[] presidents = Presidents.GetPresidentsStringArray();

			Console.WriteLine("presidents count: " + presidents.Count());

			IEnumerable<string> presidentsWithDupes = presidents.Concat(presidents);

			Console.WriteLine("presidents with dupes count: " + presidentsWithDupes.Count());

			IEnumerable<string> presidentsDistinct = presidentsWithDupes.Distinct();

			Console.WriteLine("distinct president count: " + presidentsDistinct.Count());
		}

		#endregion

		#region Union operator

		/*public static IEnumerable<T> Union<T>(
		 * 	this IEnumerable<T> first,
		 * 	IEnumerable<T> second);*/
		void UnionOperator()
		{
			string[] presidents = Presidents.GetPresidentsStringArray();

			IEnumerable<string> first = presidents.Take(5);
			IEnumerable<string> second = presidents.Skip(4);

			//fifth element should be in both seqences

			IEnumerable<string> concat = first.Concat<string>(second);
			IEnumerable<string> union = first.Union<string>(second);

			Console.WriteLine("The count of the presidents array is: " + presidents.Count());
			Console.WriteLine("The count of the first sequence is: " + first.Count());
			Console.WriteLine("The count of the second sequence is: " + second.Count());
			Console.WriteLine("The count of the concat sequence is: " + concat.Count());
			Console.WriteLine("The count of the union sequence is: " + union.Count());
		}

		#endregion

        #region Intersect operator

        /*public static IEnumerable<T> Intersect<T>(
         *  this IEnumerable<T> first,
         *  IEnumerable<T> second);
         *  */


        void IntersectOperator()
        {
            string[] presidents = Presidents.GetPresidentsStringArray();
            IEnumerable<string> first = presidents.Take(5);
            IEnumerable<string> second = presidents.Skip(4);
            //fifth element is in both sequences

            IEnumerable<string> intersect = first.Intersect(second);

            Console.WriteLine("The count of the president array is: " + presidents.Count());
            Console.WriteLine("The count of first sequence is " + first.Count());
            Console.WriteLine("The count of second sequence is " + second.Count());
            Console.WriteLine("The cout of intersect sequence is " + intersect.Count());

        }

        #endregion

        #region Except operator 

        /*public static IEnumerable<T> Except<T>(
         *  this IEnumerable<T> first,
         *  IEnumerable<T> second);
         *  */

        void ExceptOperator()
        {
            string[] presidents = Presidents.GetPresidentsStringArray();
            IEnumerable<string> processed = presidents.Take(5);

            IEnumerable<string> exceptions = presidents.Except(processed);

            foreach (string name in exceptions)
            {
                Console.WriteLine(name);
            }
        }

        #endregion

        #region Cast operator

        /*public static IEnumerable<T> Cast<T>(
         *  this IEnumerable source);
         *  */

        void CastOPerator()
        {
            ArrayList employees = Employee.GetEmployeesArrayList();
            Console.WriteLine("The data type of employees is: " + employees.GetType());

            var seq = employees.Cast<Employee>();
            Console.WriteLine("The data type of seq is " + seq.GetType());

            var emps = seq.OrderBy(e => e.lastName);

            foreach (Employee emp in emps)
            {
                Console.WriteLine("{0} {1}", emp.firstName, emp.lastName);
            }
        }

        #endregion

        #region OfTypeOperator

        /*public static IEnumerable<T> OfType<T>(
         *  this IEnumerable source);
         *  */

        void OfTypeOperator()
        {
            ArrayList employees = Employee.GetEmployeesArrayList();
            EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

            ArrayList al = new ArrayList();
            al.Add(employees[0]);
            al.Add(employees[1]);
            al.Add(empOptions[0]);
            al.Add(empOptions[1]);
            al.Add(employees[3]);
            al.Add(empOptions[3]);

            var items = al.Cast<Employee>();

            Console.WriteLine("Attemting to use the Cast operator ...");
            try
            {
                foreach (Employee item in items)
                {
                    Console.WriteLine("{0} {1} {2}", item.id, item.firstName, item.lastName);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0} {1}", ex.Message, System.Environment.NewLine);
            }

            Console.WriteLine("Attempting to use the OfType operator...");
            var items2 = al.OfType<Employee>();
            foreach (Employee item in items2)
            {
                Console.WriteLine("{0} {1} {2}", item.id, item.firstName, item.lastName);
            }
        }

        #endregion

        #region AsEnumerable operator

        /*public static IEnumerable<T> AsEnumerable<T>(
         *  this IEnuerable<T> source);
         *  */

        void AsEnumerableOperator()
        {
            //LINQ to SQL example
            //IQuerable<T> to IEnumerable<T>
        }       

        #endregion

        #region DefaultIfEmpty operator

        /*public static IEnumerable<T> DefaultIfEmpty<T>(
         *  this IEnumerable<T> source);
         *  */
        void DefaultIfEnumerableOperator()
        {
            string[] presidents = Presidents.GetPresidentsStringArray();

            string jones = presidents.Where(n => n.Equals("Jones")).DefaultIfEmpty().First();
            if (jones != null)
            {
                Console.WriteLine("Jones was found");
            }
            else
            {
                Console.WriteLine("Jones was not found");
            }
        }

        /*public static DefaultIfEmpty<T>(
         *  this IEnumerable<T> source,
         *  T defaultValue);
         *  */
        void DefaultIfEmptyOperator2nd()
        {
            string[] presidents = Presidents.GetPresidentsStringArray();

            string name = presidents.Where(n => n.Equals("Jones")).DefaultIfEmpty("Missing").First();
            Console.WriteLine(name);
        }

        #endregion

        #region Range operator

        /*public static IEnumerable<int> Range(
         *  int start,
         *  int count);
         *  */
        void RangeOperator()
        {
            IEnumerable<int> ints = Enumerable.Range(1, 10);

            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }
        }

        #endregion

        #region Repeat operator

        /*public static IEnumerable<t> Repeat<T>(
         *  T element,
         *  int count);
         *  */
        void RepeatOperator()
        {
            IEnumerable<int> ints = Enumerable.Repeat(2, 10);

            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }
        }

        #endregion

        #region Empty operator

        //public static IEnumerable<T> Empty<T>();
        void EmptyOperator()
        {
            IEnumerable<string> strings = Enumerable.Empty<string>();
            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine(strings.Count());
        }

        #endregion

    }

}

