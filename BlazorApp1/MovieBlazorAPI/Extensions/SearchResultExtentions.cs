using BlazorApp1.Api;
using BlazorApp1.Models;

namespace BlazorApp1.Extensions
{
	public static class SearchResultExtentions
	{
		public static List<Movie> ToMovies(this SearchResult searchResult)
		{
			var movie = new List<Movie>();

			return searchResult.results.Select(x => new Movie()
			{
				Id = x.id,
				Title = x.title,
				Poster = x.poster_path
			}).ToList();
		}
	}
}
