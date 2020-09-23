using System;
using AutoMapper;
using MySqlDogs.Application.Breeds.Queries.Get;
using MySqlDogs.Application.Common.Mappings;
using MySqlDogs.Application.Dogs.Queries.Get;
using MySqlDogs.Core.Entites;
using NUnit.Framework;

namespace MySqlDogs.Application.UnitTests
{
    public class MappingTests
    {

        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Test]
        [TestCase(typeof(Dog), typeof(DogDto))]
        [TestCase(typeof(Breed), typeof(BreedDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);
            var result =  _mapper.Map(instance, source, destination);
            Assert.AreEqual(destination, result.GetType());
        }
    }
}
