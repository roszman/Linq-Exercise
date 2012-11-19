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
            FirstOrDefaultOperator2nd();
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
    }
}
