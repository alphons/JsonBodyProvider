using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;
using System.Text.Json.Nodes;

namespace JsonBodyProvider;

internal class JsonBodyValueProvider(Dictionary<string, JsonNode?> values) : IValueProvider
{
	public bool ContainsPrefix(string prefix) => values.ContainsKey(prefix);

	public ValueProviderResult GetValue(string key)
	{
		if (!values.TryGetValue(key, out JsonNode? node) || node is null)
		{
			return ValueProviderResult.None;
		}

		if (node is JsonArray array)
		{
			string?[] valuesAsStrings = [.. array.Select(item => item?.ToString())];

			return new ValueProviderResult(valuesAsStrings, CultureInfo.InvariantCulture);
		}

		// Scalar gevallen
		string? rawValue = node switch
		{
			JsonValue valueNode when valueNode.TryGetValue(out object? obj) => obj?.ToString(),
			_ => node.ToJsonString() // object of fallback
		};

		return new ValueProviderResult(
			rawValue ?? string.Empty,
			CultureInfo.InvariantCulture);
	}
}