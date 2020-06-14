using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentBoats.Models.Filters
{
    public class HttpContext
    {
        private static Microsoft.AspNetCore.Http.IHttpContextAccessor m_httpContextAccessor;

        public static void Configure(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
        {
            m_httpContextAccessor = httpContextAccessor;
        }

        public static Microsoft.AspNetCore.Http.HttpContext Current
        {
            get
            {
                return m_httpContextAccessor.HttpContext;
            }
        }

        public static int GetInt(string key)
        {
            int? a = null;
            a = m_httpContextAccessor.HttpContext.Session.GetInt32(key);
            int b = a != null ? Convert.ToInt32(a) : 0;
            return b;
        }

        public static void SetInt(string key, int value)
        {
            m_httpContextAccessor.HttpContext.Session.SetInt32(key, value);
        }
        public static void SetString(string key, string value)
        {
            m_httpContextAccessor.HttpContext.Session.SetString(key, value);
        }
        public static string GetString(string key)
        {
            string value = null;
            value = m_httpContextAccessor.HttpContext.Session.GetString(key);
            return value;
        }
        public static void SetObject(string key, object value)
        {
            m_httpContextAccessor.HttpContext.Session.SetObject(key, value);
        }
        public static T GetObject<T>(string key)
        {
            T value = default(T);
            value = m_httpContextAccessor.HttpContext.Session.GetObject<T>(key);
            return value;
        }
        public static void SetGuid(string key, Guid value)
        {
            m_httpContextAccessor.HttpContext.Session.SetGuid(key, value);
        }
        public static Guid GetGuid(string key)
        {
            Guid value = m_httpContextAccessor.HttpContext.Session.GetGuid(key);
            return value;
        }
    }

    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static void SetGuid(this ISession session, string key, Guid Value)
        {
            session.SetString(key, Convert.ToString(Value));
        }
        public static Guid GetGuid(this ISession session, string key)
        {
            var data = session.GetString(key);
            return string.IsNullOrEmpty(data) ? Guid.Empty : Guid.Parse(data);
        }
    }
}
