using System.Collections.Generic;
using System.Text;

namespace NICE.Identity.Authentication.Sdk.Services
{
	public class Auth0QueryBuilder
	{
		private readonly StringBuilder stringBuilder;
		private readonly List<Parameter> parameters;

		public Auth0QueryBuilder(
			string parameter,
			string value,
			bool searchRawField = false,
			bool searchMetatdata = false,
			bool lowercaseSearchTerm = false,
			bool exactMatch = false)
		{
			stringBuilder = new StringBuilder();
			parameters = new List<Parameter>();

			AddParameter(parameter,
				value,
				null,
				searchRawField,
				searchMetatdata,
				lowercaseSearchTerm,
				exactMatch);
		}

		public Auth0QueryBuilder AndParameter(
			string parameter,
			string value,
			bool searchRawField = false,
			bool searchMetatdata = false,
			bool lowercaseSearchTerm = false,
			bool exactMatch = false)
		{
			AddParameter(parameter,
				value,
				SearchOperation.AND,
				searchRawField,
				searchMetatdata,
				lowercaseSearchTerm,
				exactMatch);

			return this;
		}

		public Auth0QueryBuilder OrParameter(
			string parameter,
			string value,
			bool searchRawField = false,
			bool searchMetatdata = false,
			bool lowercaseSearchTerm = false,
			bool exactMatch = false)
		{
			AddParameter(parameter,
				value,
				SearchOperation.OR,
				searchRawField,
				searchMetatdata,
				lowercaseSearchTerm,
				exactMatch);

			return this;
		}

		public Auth0QueryBuilder AddParameter(
			string parameter,
			string value,
			bool searchRawField = false,
			bool searchMetatdata = false,
			bool lowercaseSearchTerm = false,
			bool exactMatch = false)
		{
			AddParameter(parameter,
				value,
				null,
				searchRawField,
				searchMetatdata,
				lowercaseSearchTerm,
				exactMatch);

			return this;
		}

		private void AddParameter(
			string parameter,
			string value,
			SearchOperation? operation,
			bool searchRawField,
			bool searchMetatdata,
			bool lowercaseSearchTerm,
			bool exactMatch)
		{
			parameters.Add(
				new Parameter(
					parameter,
					value,
					operation,
					searchRawField,
					searchMetatdata,
					lowercaseSearchTerm,
					exactMatch));
		}

		public string Build()
		{
			foreach (var parameter in parameters)
				AppendParameter(parameter);

			return stringBuilder.ToString();
		}

		private void AppendParameter(Parameter parameter)
		{
			if (!parameter.HasValue)
				return;

			var operation = GetOperation(parameter.Operation);

			stringBuilder.Append($"{operation}" + parameter);
		}

		private string GetOperation(SearchOperation? operation)
		{
			var value = string.Empty;

			if (stringBuilder.Length == 0)
				return value;

			if (operation != null)
				return $" {operation} ";

			return " ";
		}

		private class Parameter
		{
			private readonly string formattedString;

			public Parameter(string name,
				string value,
				SearchOperation? operation,
				bool searchRawField = false,
				bool searchMetadata = false,
				bool lowercaseSearchTerm = false,
				bool exactMatch = false)
			{
				Operation = operation;
				HasValue = !string.IsNullOrWhiteSpace(value);

				name = searchRawField ? $"{name}.raw" : name;

				if (lowercaseSearchTerm)
					value = value?.ToLowerInvariant();

				if (exactMatch)
					formattedString = $"{name}: (\"{value}\")";
				else
					formattedString = $"{name}: ({value}*)";

				if (searchMetadata)
					formattedString = $"({formattedString} OR user_metadata.{formattedString})";
			}

			public SearchOperation? Operation { get; }

			public bool HasValue { get; }

			public override string ToString() => formattedString;
		}

		private enum SearchOperation
		{
			AND,
			OR
		}
	}
}
