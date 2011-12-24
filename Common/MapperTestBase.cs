using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public abstract class MapperTestBase : IMapperTest
    {
        protected const int ROWS = 1000;
        DateTime now = DateTime.Now;

        protected TestEntity CreateTestEntity(int id)
        {
            return new TestEntity
            {
                ID = id,
                Name = "Name",
                Shortname = "Shortname",
                Description = "Description",
                Created = now,
                CreatedBy = "CreatedBy",
                Updated = now,
                UpdatedBy = "UpdatedBy"
            };
        }

        public abstract void Create();
        public abstract void CreateUsingSP();
        public abstract void Read();
        public abstract void ReadUsingSP();
        public abstract void Update();
        public abstract void UpdateUsingSP();
        public abstract void Delete();
        public abstract void DeleteUsingSP();
    }
}
