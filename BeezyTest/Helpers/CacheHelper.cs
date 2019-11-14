using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeezyTest.Helpers
{
    public static class CacheHelper
    {
        public static void Add<T>(T o, string key)
        {
            HttpRuntime.Cache.Insert(key, o, null, DateTime.Now.AddMinutes(1440), System.Web.Caching.Cache.NoSlidingExpiration);
        }

        public static void Clear(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }

        public static bool Exists(string key)
        {
            return HttpRuntime.Cache[key] != null;
        }

        public static bool Get<T>(string key, out T value)
        {
            try
            {
                if (!Exists(key))
                {
                    value = default(T);
                    return false;
                }

                value = (T)HttpRuntime.Cache[key];
            }
            catch
            {
                value = default(T);
                return false;
            }

            return true;
        }
    }
}