using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLitePerformanceTest
{
	public class MyDbContext : DbContext
	{
		public MyDbContext()
			: base("sqlitetest")
		{

		}

		public DbSet<Person> Persons { get; set; }
	}

	public class Person
	{
		public long Id { get; set; }
		public string Name { get; set; }
	}
}
