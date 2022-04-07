using Moq;
using System.Threading.Tasks;
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
        public async Task Should_CallCreateOnce()
        {
            await _dBLogger.LogAsync(WhatHappened.Search, "test");

            _mockLogRepository.Verify(x => x.CreateAsync(It.IsAny<Log>()), Times.Once);
        }

    }
}
