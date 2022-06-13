using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocApi.DataLayer
{
    internal static class UtilityDL
    {
        internal static T CheckNull<T>(object obj)
        {
            return (obj == DBNull.Value ? default(T) : (T)obj);
        }
    }
}