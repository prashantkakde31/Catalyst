using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.Core.ApplicationService
{
    public interface ICacheService
    {
        TValue Get<TValue>(string cacheKey, int durationInMinutes, Func<TValue> getItemCallback) where TValue : class;
        TValue Get<TValue, TId>(string cacheKeyFormat, TId id, int durationInMinutes,Func<TId, TValue> getItemCallback) where TValue : class;
    }
}
