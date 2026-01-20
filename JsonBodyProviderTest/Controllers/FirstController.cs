using Microsoft.AspNetCore.Mvc;

namespace JsonBodyProviderTest.Controllers;

[Route("[controller]")]
public class FirstController : ControllerBase
{
	[HttpPost("Test")]
	public IActionResult Test(string name, int age)
	{
		return Ok(new
		{
			Name = $"Your name {name}",
			Age = $"Your age {age}"
		});
	}
}
