using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using NHibernate;
using NHibernate.Cfg;

namespace NHibernateMapper
{
    public class NHibernateMapperTest : MapperTestBase
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    //configuration.AddClass(typeof(TestObject));
                    configuration.AddAssembly(typeof(TestObject).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        private static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

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
            using (ISession session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    for (int id=0 ; id<ROWS ; id++)
                    {
                        TestEntity entity = CreateTestEntity(id);
                        session.Save(CreateTestObject(entity));
                    }
                    transaction.Commit();
                }
            }
        }

        public override void CreateUsingSP()
        {
            System.Threading.Thread.Sleep(100);
        }

        public override void Read()
        {
            List<TestEntity> list = new List<TestEntity>();

            using (ISession session = OpenSession())
            {
                for (int id = 0; id < ROWS; id++)
                {
                    list.Add(CreateTestEntity(session.Get<TestObject>(id)));
                }
            }
        }

        public override void ReadUsingSP()
        {
            System.Threading.Thread.Sleep(100);
        }

        public override void Update()
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    for (int id = 0; id < ROWS; id++)
                    {
                        TestEntity entity = CreateTestEntity(id);
                        entity.Name += ".";
                        session.Update(CreateTestObject(entity));
                    }
                    transaction.Commit();
                }
            }
        }

        public override void UpdateUsingSP()
        {
            System.Threading.Thread.Sleep(100);
        }

        public override void Delete()
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    for (int id = 0; id < ROWS; id++)
                    {
                        TestEntity entity = CreateTestEntity(id);
                        session.Delete(CreateTestObject(entity));
                    }
                    transaction.Commit();
                }
            }
        }

        public override void DeleteUsingSP()
        {
            System.Threading.Thread.Sleep(100);
        }
    }
}
