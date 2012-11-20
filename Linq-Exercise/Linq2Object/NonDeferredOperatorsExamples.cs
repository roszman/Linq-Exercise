using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using LinqExercise.Helpers;

namespace LinqExercise.Linq2Object
{
    public class NonDeferredOperatorsExamples : IExample
    {
        public void Run()
        {
            SumOperator2nd();
            Console.WriteLine("\nPress any key to close.");
            Console.ReadKey();
        }

        #region ToArray operator

        /*public static T[] ToArray(
         *  this IEnumerable<T> source);
         *  */

        void ToArrayOperator()
        {
            string[] presidents = Presidents.GetPresidentsStringArray();
            string[] names = presidents.OfType<string>().ToArray();

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

        #endregion

        #region ToList operator

        /*public static List<T> ToList<T>(
         *  this IEnumerable<T> source);
         *  */
        void ToListOperator()
        {
            string[] presidents = Presidents.GetPresidentsStringArray();

            List<string> list = presidents.ToList();

            foreach (string name in list)
            {
                Console.WriteLine(name);
            }
        }


        #endregion

        #region ToDictionary operator

        /*public static Dictionary<K, T> ToDictionary<T, K>(
         *  this IEnumerable<T> source,
         *  Func<T, K> keySelector);
         *  */
        void ToDictionaryOperator()
        {
            Dictionary<int, Employee> eDictionary = Employee.GetEmployeesArray().ToDictionary(k => k.id);

            Employee e = eDictionary[2];

            Console.WriteLine("Employee whose id == 2 is {0} {1}", e.firstName, e.lastName);
        }

        /*public static Dictionary<K, T> ToDictionary<T, K>(
         *  this IEnumerable<T> source,
         *  Func<T, K> keySelector,
         *  IEqualityComaprer<K> comparer);
         *  */
        void ToDictionaryOperator2nd()
        {
            Dictionary<string, Employee2> eDictionary = Employee2.GetEmployeesArray().ToDictionary(k => k.id, new MyStringifiedNumberComparer());

            Employee2 e = eDictionary["2"];
            Console.WriteLine("Employee whose id == \"2\" : {0} {1}", e.firstName, e.lastName);

            Employee2 e2 = eDictionary["0002"];
            Console.WriteLine("Employee whose id == \"0002\" : {0} {1}", e.firstName, e.lastName);
        }

        /*public static Dictionary<K, E> ToDictionary<T, K, E>(
         *  this IEnumerable<T>  source,
         *  Func<T, K> keySelector,
         *  Func<T, E> elementSelector);
         *  */
        void ToDictionaryOperator3rd()
        {
            Dictionary<int, string> eDictionary = Employee.GetEmployeesArray()
                .ToDictionary(k => k .id,
                                i => string.Format("{0} {1}", i.firstName, i.lastName));

            string name = eDictionary[2];
            Console.WriteLine("Employee whose id == 2 is {0}", name);
        }

        /*public static Dictionary<K, E> ToDictionary<T, K, E>(
         *  this IEnumerable<T> source,
         *  Func<T, K> keySelector,
         *  Func<T, E> elementSelector,
         *  IEqualityComparer<K> comparer);
         *  */
        void ToDictionaryOperator4th()
        {
            Dictionary<string, string> eDictionary = Employee2.GetEmployeesArray()
                .ToDictionary(k => k.id,
                                i => string.Format("{0} {1}", i.firstName, i.lastName),
                                new MyStringifiedNumberComparer());

            string name = eDictionary["2"];
            Console.WriteLine("Employee whose id is == \"2\" : {0} ", name);

            name = eDictionary["0002"];
            Console.WriteLine("Employee whose id is == \"0002\" : {0} ", name);
        }

        #endregion

        #region ToLookup operator

        /*public static ILookup<K, T> ToLookup<T, K>(
         *  this IEnumerable<T> source,
         *  Func<T, K> keySelector);
         *  */
        void ToLookupOperator()
        {
            ILookup<int, Actor> lookup = Actor.GetActors().ToLookup(K => K.birthYear);

            IEnumerable<Actor> actors = lookup[1964];
            foreach (Actor actor in actors)
            {
                Console.WriteLine("{0} {1}", actor.firstName, actor.lastName);
            }
        }

        /*public static ILookup<K, T> ToLookaup<T, K>(
         *  this IEnumerable<T> source,
         *  Func<T, K> keySelector,
         *  IEqualityComparer<K> comparer);
         *  */
        void ToLookupOperator2nd()
        {
            ILookup<string, Actor2> lookup = Actor2.GetActors().ToLookup(k => k.birthYear, new MyStringifiedNumberComparer());

            IEnumerable<Actor2> actors = lookup["0001964"];
            foreach (Actor2 actor in actors)
            {
                Console.WriteLine("{0} {1}", actor.firstName, actor.lastName);
            }
        }

        /*public static ILookup<K, t> ToLookup<T, K, E>(
         *  this IEnumerable<t> source,
         *  Func<T, K> keySelector,
         *  Func<T, E> elementSelcetor);
         *  */
        void ToLookupOperator3rd()
        {
            ILookup<int, string> lookup = Actor.GetActors()
                .ToLookup(k => k.birthYear,
                            a => string.Format("{0} {1}", a.firstName, a.lastName));

            IEnumerable<string> actors = lookup[1964];
            foreach (string actor in actors)
            {
                Console.WriteLine("{0}", actor);
            }
        }

        /*public static ILookup<K, T> ToLookup<T, K, E>(
         *  this IEnumerable<T> source,
         *  Func<T, K> keySelcetor,
         *  Func<T, E> elementSelcetor,
         *  IEqualirtyComparer<K> comparer);
         *  */
        void ToLookupOperator4th()
        {
            ILookup<string, string> lookup = Actor2.GetActors()
                .ToLookup(k => k.birthYear,
                            a => string.Format("{0} {1}", a.firstName, a.lastName),
                            new MyStringifiedNumberComparer());

            IEnumerable<string> actors = lookup["0001964"];
            foreach (string actor in actors)
            {
                Console.WriteLine("{0}", actor);
            }
        }

        #endregion

        #region SequenceEqual operator

        /*public static bool SequenceEqual<T>(
         *  this IEnumerable<T> first
         *  IEnumerable<T> second);
         *  */
        void SequenceEqualOperator()
        {
            string[] presidents = Presidents.GetPresidentsStringArray();

            bool eq = presidents.SequenceEqual(presidents);
            Console.WriteLine(string.Format("Eq = {0}",eq));

            bool eq2 = presidents.SequenceEqual(presidents.Take(presidents.Count()));
            Console.WriteLine(string.Format("Eq2 = {0}",eq2));

            bool eq3 = presidents.SequenceEqual(presidents.Take(presidents.Count() -1 ));
            Console.WriteLine(string.Format("Eq3 = {0}", eq3));

            bool eq4 = presidents.SequenceEqual(presidents.Take(presidents.Count()).OrderByDescending(p => p));
            Console.WriteLine(string.Format("Eq4 = {0}", eq4));

            bool eq5 = presidents.SequenceEqual(presidents.Take(5).Concat(presidents.Skip(5)));
            Console.WriteLine(string.Format("Eq5 = {0}", eq5));
        }
        
        /*public static bool SequenceEqual<T>(
         *  this IENumerable<T> first,
         *  IEnumerable<T> second,
         *  IEqualityCOmparer comparer);
         *  */
        void SequenceEqualOperator2nd()
        {
            string[] stringifiedNums1 = { "001", "49", "017", "0080", "00027", "2" };
            string[] stringifiedNums2 = { "1", "0049", "17", "80", "27", "0002" };

            bool eq = stringifiedNums1.SequenceEqual(stringifiedNums2, new MyStringifiedNumberComparer());

            Console.WriteLine("Eq: {0}", eq);
        }

        #endregion

        #region First operator

        /*public static T First<T>(
         *  this IEnumerable<T> source);
         *  */
        void FirstOperator()
        {
            string[] presidents = Presidents.GetPresidentsStringArray();

            string name = presidents.First();
            Console.WriteLine(name);
        }

        /*public static T First<T>9
         *  this iEnumerable<T> source,
         *  Func<T, bool> predicate);
         *  */
        void FirstOperator2nd()
        {
            string[] presidents = Presidents.GetPresidentsStringArray();

            string name = presidents.First(p => p.StartsWith("H"));

            Console.WriteLine(name);
        }

        #endregion

        #region FirstOrDefault operator

        /*public static T FirstOrDefault<T>(
         *  this IEnumerable<T> source);
         *  */
        void FirstOrDefaultOperator()
        {
            string[] presidents = Presidents.GetPresidentsStringArray();

            string name = presidents.Take(0).FirstOrDefault();
            Console.WriteLine(name == null ? "NULL" : name);

            name = presidents.FirstOrDefault();
            Console.WriteLine(name == null ? "NULL" : name);
        }

        /*public static T FirstOrDefault<T>(
         *  this IEnumerable<T> source,
         *  Func<T, bool> predicate);
         *  */
        void FirstOrDefaultOperator2nd()
        {
            string[] presidents = Presidents.GetPresidentsStringArray();

            string name = presidents.FirstOrDefault(p => p.StartsWith("B"));
            Console.WriteLine(name == null ? "NULL" : name);

            name = presidents.FirstOrDefault(p => p.StartsWith("Z"));
            Console.WriteLine(name == null ? "NULL" : name);
        }

        #endregion

        #region Last operator

        /*public static T Last<T>(
         *  this IEnumerable<T> source)
         *  */
        void LastOperator()
        {
            string[] presidents = Presidents.GetPresidentsStringArray();

            string name = presidents.Last();
            Console.WriteLine(name);
        }

        /*public static T Last<T>(
         *  this IEnumerable<T> source,
         *  Func<T, bool> predicate);
         *  */
        void LastOperator2nd()
        {
            string[] presidents = Presidents.GetPresidentsStringArray();

            string name = presidents.Last(p => p.StartsWith("H"));
            Console.WriteLine(name);
        }

        #endregion

        #region LastOrDefault operator

        /*public statsic T LastOrDefault<T>(
         *  this IENumerable<T> source);
         *  */
        void LastOrDefaultOperator()
        {
            string[] presidents = Presidents.GetPresidentsStringArray();

            string name = presidents.Take(0).LastOrDefault();
            Console.WriteLine(name == null ? "NULL" : name);

            name = presidents.LastOrDefault();
            Console.WriteLine(name == null ? "NULL" : name);
        }

        /*public static T LastOrDefault(
         *  this IEnumerable<T> source,
         *  Func<T, bool> predicate);
         *  */
        void LastOrDefaultOperator2nd()
        {
            string[] presidents = Presidents.GetPresidentsStringArray();

            string name = presidents.LastOrDefault(p => p.StartsWith("Z"));
            Console.WriteLine(name == null ? "NULL" : name);

        }
        #endregion

        #region Single operator

        /*public static T Single<T>(
         *  this IEnumerable<T> source);
         *  */
        void SingleOperator()
        {
            Employee emp = Employee.GetEmployeesArray()
                .Where(e => e.id == 3).Single();

            Console.WriteLine("{0} {1}", emp.firstName, emp.lastName);
        }

        /*public static T Single<T>(
         *  this IEnumerable<T> source,
         *  Func<T, bool> predicate);
         *  */
        void SingleOperator2nd()
        {
            Employee emp = Employee.GetEmployeesArray()
                .Single(e => e.id == 3);

            Console.WriteLine("{0} {1}", emp.firstName, emp.lastName);
        }
        #endregion

        #region SingleOrDefault opeartor

        /*public static T SingleOrDefault(
         *  this IEnumerable<T> source);
         *  */
        void SingleOrDefaultOperator()
        {
            Employee emp = Employee.GetEmployeesArray()
                .Where(e => e.id == 5).SingleOrDefault();

            Console.WriteLine(emp == null ? "NULL": string.Format("{0} {1}",emp.firstName, emp.lastName));

            emp = Employee.GetEmployeesArray()
                .Where(e => e.id == 4).SingleOrDefault();

            Console.WriteLine(emp == null ? "NULL" : string.Format("{0} {1}", emp.firstName, emp.lastName));
        }

        /*public static T SingleOrDefault(
         *  this IEnumerable<T> source,
         *  Func<T, bool> predicate);
         *  */
        void SingleOrDefaultOperator2nd()
        {
            Employee emp = Employee.GetEmployeesArray()
                .SingleOrDefault(e => e.id == 4);

            Console.WriteLine(emp == null ? "NULL" : string.Format("{0} {1}", emp.firstName, emp.lastName));

            emp = Employee.GetEmployeesArray()
                .SingleOrDefault(e => e.id == 5);

            Console.WriteLine(emp == null ? "NULL" : string.Format("{0} {1}", emp.firstName, emp.lastName));
        }

        #endregion

        #region ElementAt operator

        /*public static T ElementAt<T>(
         *  this IEnumerable<T> source,
         *  int index);
         *  */
        void ElementAtOperator()
        {
            Employee emp = Employee.GetEmployeesArray()
                .ElementAt(3);

            Console.WriteLine("{0} {1}", emp.firstName, emp.lastName);
        }

        #endregion

        #region ElementAtOrDefault operator

        /*public static T ElementAtOrDefault(
         *  this IEnumerable<T> source
         *  int index);
         *  */
        void ElementAtOrDefaultOperator()
        {
            Employee emp = Employee.GetEmployeesArray()
                .ElementAtOrDefault(3);

            Console.WriteLine(emp == null ? "NULL" : string.Format("{0} {1}", emp.firstName, emp.lastName));
        }

        #endregion

        #region Any operator

        /*public static bool Any<T>(
         *  this IEnuemrable<T> source);
         *  */
        void AnyOpeartor()
        {
            bool any = Enumerable.Empty<string>().Any();

            Console.WriteLine(any);

            any = Presidents.GetPresidentsStringArray().Any();
            Console.WriteLine(any);
        }

        /*public static bool Any<T>(
         *  this IENuemrable<T> source,
         *  Func<T, bool> predicate);
         *  */
        void AnyOperator2nd()
        {
            bool any = Presidents.GetPresidentsStringArray().Any(p => p.StartsWith("Z"));
            Console.WriteLine(any);

            any = Presidents.GetPresidentsStringArray().Any(p => p.StartsWith("A"));
            Console.WriteLine(any);
        }

        #endregion

        #region All operator

        /*public static bool All<T>(
         *  this IEnumerable<T> source,
         *  Func<T, bool> predicate);
         *  */
        void AnyOperator()
        {
            bool all = Presidents.GetPresidentsStringArray()
                .All(s => s.Length > 5);
            Console.WriteLine(all);

            all = Presidents.GetPresidentsStringArray()
                .All(s => s.Length > 3);
            Console.WriteLine(all);
        }

        #endregion

        #region Contains operator

        /*public static bool Contains<T>(
         *  IEnumerbale<T> source,
         *  T value);
         *  */
        void ContainsOperator()
        {
            bool contains = Presidents.GetPresidentsStringArray()
                .Contains("Rattz");

            Console.WriteLine(contains);

            contains = Presidents.GetPresidentsStringArray()
               .Contains("Hayes");

            Console.WriteLine(contains);
        }

        /*public static bool Contains<T>(
         *  this IEnumerable<T> source,
         *  T value,
         *  IEqualityComparer<T> comparer);
         *  */
        void ContainsOperator2nd()
        {
            string[] stringifiedNums = { "001", "49", "017", "0080", "00027", "2" };

            bool contains = stringifiedNums.Contains("000000002", new MyStringifiedNumberComparer());
            Console.WriteLine(contains);

            contains = stringifiedNums.Contains("0002657", new MyStringifiedNumberComparer());
            Console.WriteLine(contains);
        }

        #endregion

        #region Count operator

        /*public static int Count<T>(
         *  this IEnuemrable<T> source);
         *  */
        void CountOperator()
        {
            int count = Presidents.GetPresidentsStringArray()
                .Count();
            Console.WriteLine(count);
        }

        /*public static int Cunt<T>(
         *  this IEnumerable<T> source,
         *  Func<T, bool> predicate);
         *  */
        void CountOperator2nd()
        {
            int count = Presidents.GetPresidentsStringArray()
                .Count(p => p.StartsWith("J"));
            Console.WriteLine(count);
        }

        #endregion

        #region LongCount operator

        /*public static long LongCount<T>(
         *  this IEnumerable<T> source);
         *  */
        void LongCountOperator()
        {
            long count = Enumerable.Range(0, int.MaxValue)
                .Concat(Enumerable.Range(0, int.MaxValue))
                .LongCount();
            Console.WriteLine(count);
        }

        /*public static long LongCount(
         *  this IEnuemarble<T> source,
         *  Func<T, bool> predicate);
         *  */
        void LongCountOperator2nd()
        {
            long count = Enumerable.Range(0, int.MaxValue)
                .Concat(Enumerable.Range(0, int.MaxValue))
                .LongCount(i => i > 1 && i < 4);
            Console.WriteLine(count);
        }

        #endregion

        #region Sum operator

        /*public static Numeric Sum(
         *  this IEnumerable<Numeric> source);
         *  */
        void SumOperator()
        {
            IEnumerable<int> ints = Enumerable.Range(1, 10);

            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("--");

            int sum = ints.Sum();
            Console.WriteLine(sum);
        }

        /*public static Numeric Sum<T>(
         *  this IEnumerable<T> source,
         *  Func<T, numeric>);
         *  */
        void SumOperator2nd()
        {
            IEnumerable<EmployeeOptionEntry> options = EmployeeOptionEntry.GetEmployeeOptionEntries();

            long optionSum = options.Sum(o => o.optionsCount);
            Console.WriteLine("The sum of the employee options is: {0}", optionSum);
        }


        #endregion

        #region Min operator

        /*public static Numeric Min(
         *  this IEnumerable<Numeric> source);
         *  */
        void MinOperator()
        {

        }

        /*public ststic T Min<T>(
         *  this IEnumerable<T> source);
         *  */
        void MinOperator2nd()
        {

        }

        /*public static Numeric Min<T>(
         *  this IEnumerable<T> source,
         *  Func<T, Numeric> selector);
         *  */
        void MinOperator3rd()
        {

        }

        /*public static S Min<T, S>(
         *  this IEnuemrable<T> source,
         *  Func<T, S> selector);
         *  */
        void MinOperator4th()
        {

        }

        #endregion

    }
}
