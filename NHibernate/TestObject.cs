using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernateMapper
{
    public class TestObject
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Shortname { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime Updated { get; set; }
        public virtual string UpdatedBy { get; set; }
    }
}
