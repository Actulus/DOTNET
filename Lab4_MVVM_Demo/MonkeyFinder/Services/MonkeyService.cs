using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class MonkeyService
{
	List<Monkey> monkeyList = new();
	HttpClient httpClient;

	public async Task<List<Monkey>> GetMonkeys()
	{
		if (monkeyList?.Count > 0)
			return monkeyList;

		var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");
		if (response.IsSuccessStatusCode)
		{
			monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
		}
		else
		{
			using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
			using var reader = new StreamReader(stream);
			var contents = await reader.ReadToEndAsync();
			monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);
		}

		return monkeyList;
	}

	public MonkeyService()
	{
		this.httpClient = new HttpClient();
	}

}
