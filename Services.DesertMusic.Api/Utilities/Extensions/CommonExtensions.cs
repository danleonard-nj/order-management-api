using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Utilities.Extensions
{
		public static class CommonExtensions
		{
				public static string AppendLine(this string value, string toAppend)
				{
						return value + Environment.NewLine + toAppend;
				}
		}
}
