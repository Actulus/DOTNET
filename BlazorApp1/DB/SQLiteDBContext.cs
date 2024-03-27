using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	public class SQLiteDBContext: DbContext
	{
		public DbSet<WatchList> WatchLists { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder options) =>  options.UseSqlite("Data Source=sqlitedemo.db");
		
		
	}
}
