using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Generic
{
    public static class Utilities
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source != null)
            {
                foreach (T obj in source)
                {
                    return false;
                }
            }
            return true;
        }
    }
}