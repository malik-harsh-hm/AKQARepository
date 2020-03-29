using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using AKQA.SharedLogic;
using AKQA.API.Controllers;
using AKQA.Service;
using AKQA.Common;
using AKQA.API.Models;
using System.Web.Http;
using System.Web.Http.Results;

namespace AKQA.xUnit.AKQA.API
{
    public class PersonControllerTest
    {
        private Mock<IServiceFactories> _serviceFactoriesMock;
        private PersonController _sut;

        public PersonControllerTest()
        {
            _serviceFactoriesMock = new Mock<IServiceFactories>();
            _sut = new PersonController(_serviceFactoriesMock.Object);
        }

        [Fact]
        public void ShouldConvertAmountInWords()
        {
            //Arrange
            string testValue = "XUNIT TEST";
            Person person = new Person()
            {
                Name = "TEST",
                DecimalAmount = 1.1M
            };

            Mock<IConvertService> convertServiceMock = new Mock<IConvertService>();
            convertServiceMock.Setup(x => x.GetData(person.DecimalAmount)).Returns(testValue);

            Mock<IServiceFactory<IConvertService>> serviceFactoryMock = new Mock<IServiceFactory<IConvertService>>();
            serviceFactoryMock.Setup(x => x.CreateInstance()).Returns(convertServiceMock.Object);

            _serviceFactoriesMock.Setup(x => x.ConvertServiceFactory).Returns(serviceFactoryMock.Object);

            //Act
            JsonResult<string> result = _sut.Convert(person) as JsonResult<string>;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.Content, testValue);
        }

    }
}
