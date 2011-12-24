using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Linq2Sql;
using EntityFramework;
using SqlReader;
using NHibernateMapper;
using System.Diagnostics;

namespace OrmTest
{
    public class OrmTest
    {
        private List<IMapperTest> tests;

        public OrmTest()
        {
            tests = new List<IMapperTest>()
            {
                //new Linq2SqlMapperTest(),
                //new EntityFrameworkMapperTest(),
                //new SqlReaderMapperTest(),
                new NHibernateMapperTest()
            };
        }

        private TimeSpan TestSingleMethod(Action testMethod)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            testMethod();
            st.Stop();
            return st.Elapsed;
        }

        private TestResult TestSingleMapper(IMapperTest test)
        {
            return new TestResult
            {
                MapperName = test.GetType().Name,
                CreateResult = TestSingleMethod(test.Create),
                //CreateUsingSPResult = TestSingleMethod(test.CreateUsingSP),
                ReadResult = TestSingleMethod(test.Read),
                //ReadUsingSPResult = TestSingleMethod(test.ReadUsingSP),
                UpdateResult = TestSingleMethod(test.Update),
                //UpdateUsingSPResult = TestSingleMethod(test.UpdateUsingSP),
                DeleteResult = TestSingleMethod(test.Delete),
                //DeleteUsingSPResult = TestSingleMethod(test.DeleteUsingSP),
            };
        }

        private List<TestResult> TestAllMappers()
        {
            return tests.Select(test => TestSingleMapper(test)).ToList();
        }

        private string FormatTimeSpan(TimeSpan timeSpan)
        {
            return string.Format("{0} ms", Math.Round(timeSpan.TotalMilliseconds));
        }

        private string FormatMethodResult(string name, TimeSpan result)
        {
            return string.Format("  {0}: {1}", name, FormatTimeSpan(result));
        }

        private void PrintTestResults(List<TestResult> results)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var r in results)
            {
                sb.AppendLine(string.Format("=== {0} ===", r.MapperName));
                sb.AppendLine(FormatMethodResult("Create", r.CreateResult));
                sb.AppendLine(FormatMethodResult("CreateSP", r.CreateUsingSPResult));
                sb.AppendLine(FormatMethodResult("Read", r.ReadResult));
                sb.AppendLine(FormatMethodResult("ReadSP", r.ReadUsingSPResult));
                sb.AppendLine(FormatMethodResult("Update", r.UpdateResult));
                sb.AppendLine(FormatMethodResult("UpdateSP", r.UpdateUsingSPResult));
                sb.AppendLine(FormatMethodResult("Delete", r.DeleteResult));
                sb.AppendLine(FormatMethodResult("DeleteSP", r.DeleteUsingSPResult));
                sb.AppendLine();
            }

            Console.Write(sb.ToString());
        }

        public void PerformTest()
        {
            List<TestResult> results = TestAllMappers();

            PrintTestResults(results);
        }
    }
}
