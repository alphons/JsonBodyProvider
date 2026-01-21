using Microsoft.AspNetCore.Mvc;

namespace JsonBodyProviderTest.Controllers;

[Route("[controller]")]
public class FirstController : ControllerBase
{
	[HttpPost("Test")]
	public IActionResult Test(
		string EventName,
		string UserId,
		DateTime Timestamp,
		int Value,
		double Weight,
		List<int> IntList,
		Dictionary<string, string> Properties,
		bool isConversion,
		Guid? campaignId)
	{
		return Ok(new
		{
			EventName,
			UserId,
			Timestamp,
			Value,
			Weight,
			IntList,
			Properties,
			isConversion,
			campaignId
		});
	}
}
