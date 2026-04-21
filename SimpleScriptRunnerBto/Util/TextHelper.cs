using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleScriptRunnerBto.Util;

public static class TextHelper
{
    public static Tuple<String, String> splitAt(this String input, String token, StringComparison comparison = StringComparison.Ordinal)
    {
        if (string.IsNullOrEmpty(input))
            return null;

        int index = input.IndexOf(token, comparison);
        if (index < 0)
            return new Tuple<string, string>(input, "");

        return new Tuple<string, string>(input.Substring(0, index), input.Substring(index + token.Length));
    }

    public static bool startsWithIgnoreCase(this String value, String toFind)
    {
        if (value == null || toFind == null)
            return false;

        return value.IndexOf(toFind, StringComparison.CurrentCultureIgnoreCase) == 0;
    }

    public static bool startsWithAny(String text, IEnumerable<String> toFind, bool ignoreCase = true)
    {
            if (ignoreCase)
                return toFind.Any(x => startsWithIgnoreCase(text, x));

            return toFind.Any(text.StartsWith);
        }

    public static int? parseIntNullable(String source)
    {
            if (String.IsNullOrEmpty(source))
                return null;

            try
            {
                return int.Parse(source);
            }
            catch
            {
                return null;
            }
        }

    public static long? parseLongNullable(String source)
    {
            if (String.IsNullOrEmpty(source))
                return null;

            try
            {
                return long.Parse(source);
            }
            catch
            {
                return null;
            }
        }

    public static double? parseDoubleNullable(String source)
    {
            if (String.IsNullOrEmpty(source))
                return null;

            try
            {
                return double.Parse(source);
            }
            catch
            {
                return null;
            }
        }

    public static bool isEqualsIgnoreCase(String a, String b)
    {
            if (a == null)
                return b == null;

            if (b == null)
                return false;

            return a.Equals(b, StringComparison.CurrentCultureIgnoreCase);
        }

    public static bool parseBool(String value, bool defaultValue = false)
    {
            if (isEqualsIgnoreCase(value, "true")) return true;
            if (isEqualsIgnoreCase(value, "false")) return false;
            return defaultValue;
        }        
}