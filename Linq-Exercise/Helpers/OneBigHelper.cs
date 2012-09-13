using System;
using System.Collections;
namespace LinqExercise.Helpers
{
	public static class Presidents
	{

		public static string[] GetPresidentsStringArray ()
		{
			return new string[]{ "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
				"Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
				"Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
				"Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
				"Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
				"Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};
		}
	}

	public class Employee
	{
		public int id;
		public string firstName;
		public string lastName;
	
		public static ArrayList GetEmployeesArrayList ()
		{
			ArrayList al = new ArrayList ();
		
			al.Add (new Employee { id = 1, firstName = "Joe", lastName = "Rattz" });
			al.Add (new Employee { id = 2, firstName = "William", lastName = "Gates" });
			al.Add (new Employee { id = 3, firstName = "Anders", lastName = "Hejlsberg" });
			al.Add (new Employee { id = 4, firstName = "David", lastName = "Lightman" });
			al.Add (new Employee { id = 101, firstName = "Kevin", lastName = "Flynn" });
			return (al);
		}
	
		public static Employee[] GetEmployeesArray ()
		{
			return ((Employee[])GetEmployeesArrayList ().ToArray (typeof(Employee)));
		}
	}

//  This class will be used by several examples.
	public class EmployeeOptionEntry
	{
		public int id;
		public long optionsCount;
		public DateTime dateAwarded;
	
		public static EmployeeOptionEntry[] GetEmployeeOptionEntries ()
		{
			EmployeeOptionEntry[] empOptions = new EmployeeOptionEntry[] {
			new EmployeeOptionEntry { 
				id = 1, 
				optionsCount = 2, 
				dateAwarded = DateTime.Parse("1999/12/31") },
			new EmployeeOptionEntry { 
				id = 2, 
				optionsCount = 10000, 
				dateAwarded = DateTime.Parse("1992/06/30")  },
			new EmployeeOptionEntry { 
				id = 2, 
				optionsCount = 10000, 
				dateAwarded = DateTime.Parse("1994/01/01")  },
			new EmployeeOptionEntry { 
				id = 3, 
				optionsCount = 5000, 
				dateAwarded = DateTime.Parse("1997/09/30") },
			new EmployeeOptionEntry { 
				id = 2, 
				optionsCount = 10000, 
				dateAwarded = DateTime.Parse("2003/04/01")  },
			new EmployeeOptionEntry { 
				id = 3, 
				optionsCount = 7500, 
				dateAwarded = DateTime.Parse("1998/09/30") },
			new EmployeeOptionEntry { 
				id = 3, 
				optionsCount = 7500, 
				dateAwarded = DateTime.Parse("1998/09/30") },
			new EmployeeOptionEntry { 
				id = 4, 
				optionsCount = 1500, 
				dateAwarded = DateTime.Parse("1997/12/31") },
			new EmployeeOptionEntry { 
				id = 101, 
				optionsCount = 2, 
				dateAwarded = DateTime.Parse("1998/12/31") }
		};
		
			return (empOptions);
		}
	}
}