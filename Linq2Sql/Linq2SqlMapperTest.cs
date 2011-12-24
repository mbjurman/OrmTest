using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Linq2Sql
{
    public class Linq2SqlMapperTest : MapperTestBase
    {
        private TestObject CreateTestObject(TestEntity entity)
        {
            return new TestObject
            {
                ID = entity.ID,
                Name = entity.Name,
                Shortname = entity.Shortname,
                Description = entity.Description,
                Created = entity.Created,
                CreatedBy = entity.CreatedBy,
                Updated = entity.Updated,
                UpdatedBy = entity.UpdatedBy
            };
        }

        private TestEntity CreateTestEntity(TestObject obj)
        {
            return new TestEntity
            {
                ID = obj.ID,
                Name = obj.Name,
                Shortname = obj.Shortname,
                Description = obj.Description,
                Created = obj.Created,
                CreatedBy = obj.CreatedBy,
                Updated = obj.Updated,
                UpdatedBy = obj.UpdatedBy
            };
        }

        public override void Create()
        {
            using (var context = new DataClasses1DataContext())
            {
                for (int id = 0; id < ROWS; id++)
                {
                    TestEntity entity = CreateTestEntity(id);
                    context.TestObjects.InsertOnSubmit(CreateTestObject(entity));
                }
                context.SubmitChanges();
            }
        }

        public override void CreateUsingSP()
        {
        }

        public override void Read()
        {
            using (var context = new DataClasses1DataContext())
            {
                List<TestEntity> list = context.TestObjects.Where(to =>
                    to.ID < ROWS).Select(to => CreateTestEntity(to)).ToList();
            }
        }

        public override void ReadUsingSP()
        {
            Read();
        }

        public override void Update()
        {
            using (var context = new DataClasses1DataContext())
            {
                for (int id = 0; id < ROWS; id++)
                {
                    TestEntity entity = CreateTestEntity(id);
                    TestObject obj = context.TestObjects.Single(to => to.ID == entity.ID);
                    obj.Name = entity.Name + ".";
                }
                context.SubmitChanges();
            }
        }

        public override void UpdateUsingSP()
        {
            System.Threading.Thread.Sleep(100);
        }

        public override void Delete()
        {
            using (var context = new DataClasses1DataContext())
            {
                for (int id = 0; id < ROWS; id++)
                {
                    TestEntity entity = CreateTestEntity(id);
                    TestObject obj = context.TestObjects.Single(to => to.ID == entity.ID);
                    context.TestObjects.DeleteOnSubmit(obj);
                }
                context.SubmitChanges();
            }
        }

        public override void DeleteUsingSP()
        {
            System.Threading.Thread.Sleep(100);
        }
    }
}
