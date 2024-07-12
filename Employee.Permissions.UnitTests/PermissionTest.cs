using Employee.Permissions.Api.Controllers;
using Employee.Permissions.Domain.Dtos.Requests;
using Employee.Permissions.Domain.Interfaces.Repositories;
using MediatR;
using System;

namespace Employee.Permissions.UnitTests
{
    public class PermissionTests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}


        [Test]
        public async Task GetCustomers_ReturnsCustomers()
        {
            // Arrange
            var mockData = new PermissionCreateRequestDto("1", "1", true);

            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var command = new UpdateCustomerCommand();
            var handler = new UpdateCustomerCommandHandler(mediatorMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            // Perform relevant assertions (e.g., verify event publishing)
            // Example: mediatorMock.Verify(x => x.Publish(It.IsAny<CustomersChanged>()));
        }

    }
}