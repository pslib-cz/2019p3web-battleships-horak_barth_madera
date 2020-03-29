using Battleships.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Services
{
    public class SessionStorage<T>
    {
        private ISession _session;

        public SessionStorage(IHttpContextAccessor hca)
        {
            _session = hca.HttpContext.Session;
        }

        public T Load(string key)
        {
            T result = _session.Get<T>(key);
            if (result == null)
            {
                result = default(T);
            }
            return result;
        }


        public void Save(string key, T data)
        {
            _session.Set(key, data);
        }
    }
}
