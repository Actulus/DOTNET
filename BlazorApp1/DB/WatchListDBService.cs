using DB;

namespace BlazorApp1
{
	public class WatchListDBService
	{
		public bool InWatchList(int movieId)
		{
			using (var db = new SQLiteDBContext())
			{
				return db.WatchLists.Any(m => m.MovieId == movieId);
			}
		}

		public bool TryAdd(WatchList watchList)
		{
			if (InWatchList(watchList.MovieId))
			{
				return false;
			}

			using (var db = new SQLiteDBContext())
			{
				db.WatchLists.Add(watchList);
				db.SaveChanges();
				return true;
			}
		}

		public List<WatchList> Get()
		{
			using (var db = new SQLiteDBContext())
			{
				return db.WatchLists.ToList();
			}
		}

		public bool Remove(int movieId)
		{
			using(var db = new SQLiteDBContext())
			{
				var watchList = db.WatchLists.FirstOrDefault(m => m.MovieId == movieId);
				if (watchList != null)
				{
					db.WatchLists.Remove(watchList);
					db.SaveChanges();
					return true;
				}

				return false;
			}
		}
	}
}
