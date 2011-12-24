using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public interface IMapperTest
    {
        void Create();
        void CreateUsingSP();
        void Read();
        void ReadUsingSP();
        void Update();
        void UpdateUsingSP();
        void Delete();
        void DeleteUsingSP();
    }
}
