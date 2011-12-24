using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace EntityFramework
{
    public class EntityFrameworkMapperTest : MapperTestBase
    {
        public override void Create()
        {
            System.Threading.Thread.Sleep(1000);
        }

        public override void CreateUsingSP()
        {
            System.Threading.Thread.Sleep(1000);
        }

        public override void Read()
        {
            System.Threading.Thread.Sleep(1000);
        }

        public override void ReadUsingSP()
        {
            System.Threading.Thread.Sleep(1000);
        }

        public override void Update()
        {
            System.Threading.Thread.Sleep(1000);
        }

        public override void UpdateUsingSP()
        {
            System.Threading.Thread.Sleep(1000);
        }

        public override void Delete()
        {
            System.Threading.Thread.Sleep(1000);
        }

        public override void DeleteUsingSP()
        {
            System.Threading.Thread.Sleep(1000);
        }
    }
}
