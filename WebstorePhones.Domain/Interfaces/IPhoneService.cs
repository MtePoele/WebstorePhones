﻿using System.Collections.Generic;
using WebstorePhones.Domain.Entities;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IPhoneService
    {
        /// <summary>
        /// Returns an IEnumerable<Phone>.
        /// </summary>
        /// <returns>IEnumerable<Phone></returns>
        IEnumerable<Phone> Get();
        /// <summary>
        /// Returns an IEnumerable<Phone> where Name, Brand or Description contains "query".
        /// </summary>
        /// <param name="query"></param>
        /// <returns>IEnumerable<Phone></returns>
        IEnumerable<Phone> Search(string query);
        /// <summary>
        /// Checks if phones are missing.
        /// Calls AddToDatabase foreach missing phone.
        /// Returns number of new phones added.
        /// </summary>
        /// <param name="phones"></param>
        /// <returns>int</returns>
        int AddMissingPhones(List<Phone> phones);
        /// <summary>
        /// Deletes a phone based on its "id"
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        /// <summary>
        /// Logs the message of the exception.
        /// </summary>
        /// <param name="exceptionMessage"></param>
        void LoggingException(string exceptionMessage);
    }
}
