using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Data.SqlClient;

namespace SqlReader
{
    public class SqlReaderMapperTest : MapperTestBase
    {
        const string ConnectionString = "Data Source=MARCUSHOME;Initial Catalog=TestDatabase;Integrated Security=True";

        public override void Create()
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();

                for (int id=0 ; id<ROWS ; id++ )
                {
                    TestEntity entity = CreateTestEntity(id);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = string.Format(
                        @"INSERT INTO TestObject (ID,Name,Shortname,[Description],Created,CreatedBy,Updated,UpdatedBy) VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                        entity.ID, entity.Name, entity.Shortname, entity.Description, entity.Created, entity.CreatedBy, entity.Updated, entity.UpdatedBy);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void CreateUsingSP()
        {
            System.Threading.Thread.Sleep(100);
        }

        public override void Read()
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                List<TestEntity> list = new List<TestEntity>();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT ID,Name,Shortname,[Description],Created,CreatedBy,Updated,UpdatedBy FROM TestObject WHERE ID < 1000";
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new TestEntity
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Shortname = reader.GetString(2),
                        Description = reader.GetString(3),
                        Created = reader.GetDateTime(4),
                        CreatedBy = reader.GetString(5),
                        Updated = reader.GetDateTime(6),
                        UpdatedBy = reader.GetString(7)
                    });
                }
                reader.Close();
            }
        }

        public override void ReadUsingSP()
        {
            Read();
        }

        public override void Update()
        {
            System.Threading.Thread.Sleep(100);
        }

        public override void UpdateUsingSP()
        {
            System.Threading.Thread.Sleep(100);
        }

        public override void Delete()
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();

                for (int id = 0; id < ROWS; id++)
                {
                    TestEntity entity = CreateTestEntity(id);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = string.Format(
                        @"DELETE FROM TestObject WHERE ID = {0}", entity.ID);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void DeleteUsingSP()
        {
            System.Threading.Thread.Sleep(100);
        }
    }
}
