using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class ProbaTestStatus {
        public virtual int ID { get; set; }
        public virtual int? IdLKabinet { get; set; }
        public virtual int? ProbaTest { get; set; }
    }
}
