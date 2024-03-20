using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieBlazorAPI
{
	public class ApiClientBase
	{
		protected string Get(string searchUrl)
		{
			HttpClient client = new HttpClient();
			var apiResult = client.GetStringAsync(searchUrl).GetAwaiter().GetResult();
			return apiResult;
		}

		protected T Get<T>(string searchUrl)
		{
			string apiResult = Get(searchUrl);

			T result = JsonSerializer.Deserialize<T>(apiResult);
			return result;
		}
	}
}
