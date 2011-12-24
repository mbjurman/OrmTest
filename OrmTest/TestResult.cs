using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrmTest
{
    public class TestResult
    {
        public string MapperName;
        public TimeSpan CreateResult;
        public TimeSpan CreateUsingSPResult;
        public TimeSpan ReadResult;
        public TimeSpan ReadUsingSPResult;
        public TimeSpan UpdateResult;
        public TimeSpan UpdateUsingSPResult;
        public TimeSpan DeleteResult;
        public TimeSpan DeleteUsingSPResult;
    }
}
