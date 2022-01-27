using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebstorePhones.Domain.Interfaces
{
    /// <summary>
    /// Logs what happened at that moment using what value.
    /// </summary>
    public interface ILogger
    {
        void Log(string whatHappened, string value);
    }
}
