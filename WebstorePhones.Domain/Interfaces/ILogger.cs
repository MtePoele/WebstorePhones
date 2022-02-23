using System.Threading.Tasks;

namespace WebstorePhones.Domain.Interfaces
{
    /// <summary>
    /// Logs type (Search, Exception, PhoneAdded or PhoneDeleted)  at that moment using what value.
    /// </summary>
    public interface ILogger
    {
        Task LogAsync(WhatHappened whatHappened, string message);
    }

    /// <summary>
    /// Names for kinds of things to log.
    /// </summary>
    public enum WhatHappened
    {
        Exception,
        PhoneAdded,
        PhoneDeleted,
        Search
    }
}
