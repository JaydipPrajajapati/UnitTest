using Domain;
using Domain.Interfaces;
using Moq;
using NUnit.Framework;
using WebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using DataAccessEF;

namespace DBTest
{
    public class Tests
    {
        private Mock<IUnitOfWork>? _unitOfWork;
        private IPersonRepository? _personRepository;
        private PersonController? _personController;
        private Mock<PeopleContext>? _peopleContext;
        [SetUp]
        public void Setup()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _personController = new(_unitOfWork.Object);
            _peopleContext = new Mock<PeopleContext>();
        }

        [Test]
        public void GetAllPerson_Return_List()
        {
            // Arrange
            Address objAddress = new Address()
            {
                AddressId = 1,
                City = "Ahmedabad",
                State = "Guj",
                StreetAdress = "Ranip",
                ZipCode = "382480"
            };



            Email objEmail = new Email() { EmailAdress = "jaydip.2051@gmail.com", EmailId = 1 };
            List<Email> list = new List<Email>() { objEmail };
            Person objPerson = new Person()
            {
                Address = objAddress,
                Age = 31,
                Name = "Prahi",
                PersonId = 1,
                Emails = list
            };

            // Act
            _unitOfWork?.Setup(x => x.Person.GetAll()).Returns(new List<Person>() { objPerson });
            var response = _personController?.GetAllPersons();

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response?.ToList<Person>().Count, 1);
        }

        [Test]
        public void GetAdultPerson_Return_List()
        {
            // Arrange
            Address objAddress = new Address()
            {
                AddressId = 1,
                City = "Ahmedabad",
                State = "Guj",
                StreetAdress = "Ranip",
                ZipCode = "382480"
            };



            Email objEmail = new Email() { EmailAdress = "jaydip.2051@gmail.com", EmailId = 1 };
            List<Email> list = new List<Email>() { objEmail };
            List<Person> lstPerson = new List<Person>()
            {
                new Person() { Address = objAddress, Age = 15, Name = "Rudra", Emails = list ,PersonId = 1 },
                new Person() { Address = objAddress, Age = 25, Name = "Nil", Emails = list ,PersonId = 2 }
            };

            // Act

            _unitOfWork?.Setup(x => x.Person.GetAll()).Returns(lstPerson);
            var response = _personController?.GetAdultPersons();

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response?.ToList<Person>().Count, 1);
        }
    }
}