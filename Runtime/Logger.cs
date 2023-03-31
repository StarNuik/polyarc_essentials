using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArcana.Utilities;
using SF = UnityEngine.SerializeField;
using System.Runtime.CompilerServices;
using System.IO;
using System.Linq;
using System.Globalization;

namespace PolygonArcana.Utilities
{
	public static class Logger
	{
		public static LogFluent Log(
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string filePath = null,
			[CallerLineNumber] int lineNumber = -1
		)
		{
			return new LogFluent(memberName, filePath, lineNumber);
		}
	}

	public class LogFluent
	{
		private string memberName;
		private string filePath;
		private int lineNumber;
		
		public LogFluent(string memberName, string filePath, int lineNumber)
		{
			this.memberName = memberName;
			this.filePath = filePath;
			this.lineNumber = lineNumber;
		}

		public void Message(params object[] args)
		{
			var expr = GetExpr(filePath, lineNumber);
			var exprs = ExprToArgs(expr);

			string result = "";
			result += Path.GetFileName(filePath) + "::" + memberName + "()\n";
			for (int i = 0; i < exprs.Length; i++)
			{
				result += ToString(exprs[i], args[i]) + "\n";
			}

			if (args.Length > exprs.Length)
			{
				result += "Args lost: " + (args.Length - exprs.Length) + "\n";
			}
			
			Debug.Log(result);
		}

		private static string ToString(string expr, object arg)
		{
			bool isLiteral = !IsValidIdentifier(expr[0], true);

			string name = isLiteral ? "literal" : expr;
			string line = name + ": " + arg.ToString();
			return line;
		}

		private static string[] ExprToArgs(string expr)
		{
			var from = expr.IndexOf(".Message(") + (".Message(").Length;
			var to = expr.IndexOf(");");
			expr = expr.Substring(from, to - from);

			var args = expr.Split(",");
			return args;
		}

		private static string GetExpr(string filePath, int lineNumber)
		{
			var lines = File.ReadLines(filePath);
			lines = lines.Skip(lineNumber - 1);
			
			string expr = "";
			foreach (var line in lines)
			{
				expr += line;
				if (line.Contains(");")) break;
			}
			expr = expr.Replace("\n", "");
			expr = expr.Replace(" ", "");

			return expr;
		}

		//? https://stackoverflow.com/a/60820647
		private static bool IsValidIdentifier(char c, bool firstChar = false)
		{
			switch (char.GetUnicodeCategory(c))
			{
				case UnicodeCategory.UppercaseLetter:
				case UnicodeCategory.LowercaseLetter:
				case UnicodeCategory.TitlecaseLetter:
				case UnicodeCategory.ModifierLetter:
				case UnicodeCategory.OtherLetter:
					// Always allowed in C# identifiers
					return true;

				case UnicodeCategory.LetterNumber:
				case UnicodeCategory.NonSpacingMark:
				case UnicodeCategory.SpacingCombiningMark:
				case UnicodeCategory.DecimalDigitNumber:
				case UnicodeCategory.ConnectorPunctuation:
				case UnicodeCategory.Format:
					// Only allowed after first char
					return !firstChar;
				default:
					return false;
			}
		}
	}
}