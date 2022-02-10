﻿using System;

namespace Amazonia.eCommerceRazor.Utils
{
    public static class StringUtils
    {
        public static string FirstCharToUpper(this string input) =>
           input switch
           {
               null => throw new ArgumentNullException(nameof(input)),
               "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
               _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
           };
    }
}
