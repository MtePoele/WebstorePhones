namespace WebstorePhones.Domain.Interfaces
{
    /// <summary>
    /// Logs type (Search, Exception, PhoneAdded or PhoneDeleted)  at that moment using what value.
    /// </summary>
    public interface ILogger
    {
        void Log(WhatHappened whatHappened, string value);
    }

    public enum WhatHappened
    {
        Exception,
        PhoneAdded,
        PhoneDeleted,
        Search
    }
}
