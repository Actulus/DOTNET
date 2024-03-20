using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBlazorAPI.Api
{

	public class MovieTrailerResult
	{
		public int id { get; set; }
		public Video[] results { get; set; }
	}

	public class Video
	{
		public string iso_639_1 { get; set; }
		public string iso_3166_1 { get; set; }
		public string name { get; set; }
		public string key { get; set; }
		public DateTime published_at { get; set; }
		public string site { get; set; }
		public int size { get; set; }
		public string type { get; set; }
		public bool official { get; set; }
		public string id { get; set; }
	}

}
