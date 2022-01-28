using Moq;
using System;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;
using Xunit;

namespace WebstorePhones.Testing.DBLogger
{
    public class LogTests
    {
        private readonly Mock<IRepository<Log>> _mockLogRepository;
        private readonly Business.Loggers.DBLogger _dBLogger;

        public LogTests()
        {
            _mockLogRepository = new Mock<IRepository<Log>>();
            _dBLogger = new Business.Loggers.DBLogger(_mockLogRepository.Object);
        }

        [Fact]
        public void Should_CallCreateOnce()
        {
            _dBLogger.Log(WhatHappened.Search, "test");

            _mockLogRepository.Verify(x => x.Create(It.IsAny<Log>()));
        }

    }
}
