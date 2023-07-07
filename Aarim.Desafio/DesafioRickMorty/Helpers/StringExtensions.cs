using System;
namespace Aarim.Desafio.RickMorty.Helpers
{
	public static class StringExtensions
	{
		public static bool HasValue(this string? value) => !string.IsNullOrWhiteSpace(value);
	}
}

