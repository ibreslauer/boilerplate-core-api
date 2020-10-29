using System;

namespace Boilerplate.API.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime? DbSafeValue(this DateTime dt)
        {
            return (dt < DateTime.UnixEpoch || dt > DateTime.MaxValue) ?
                (DateTime?)null :
                dt;
        }
    }
}
