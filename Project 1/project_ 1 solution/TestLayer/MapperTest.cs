
using FluentApi.Entities;
using Models;
using NUnit.Compatibility;
using Bussiness_Logic;

namespace TestLayer
{


    [TestFixture]
    public class TestMapper
    {
        [Test]
        public void TestMap()
        {
            FluentApi.Entities.Trainer trainer = new FluentApi.Entities.Trainer();

            var modelData = Mapper.Map(trainer);

            Assert.AreEqual(modelData.GetType(), typeof(Models.Trainer));
        }


        [Test]
        public void MapTest1()
        {

            FluentApi.Entities.Skill skill = new FluentApi.Entities.Skill();
            var skilldata = Mapper.Map(skill);

            Assert.AreEqual(skilldata.GetType(), typeof(Models.Skill));
        }

        [Test]
        public void MapTest2()
        {
            FluentApi.Entities.Company company = new FluentApi.Entities.Company();
            var cmpdata = Mapper.Map(company);
            Assert.AreEqual(cmpdata.GetType(), typeof(Models.Company));

        }
        [Test]
        public void MapTest3()
        {
            FluentApi.Entities.Education education  = new FluentApi.Entities.Education();
            var edudata= Mapper.Map(education);
            Assert.AreEqual(edudata.GetType(),typeof(Models.Education));
        }
        [Test]
        public void MapTest4()
        {
            FluentApi.Entities.Availability availability=new FluentApi.Entities.Availability();
            var avadata= Mapper.Map(availability);  
            Assert.AreEqual(avadata.GetType(),typeof(Models.Availability));
        }
       



    }





}

