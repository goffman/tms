using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Blockedusers {
        public virtual int ID { get; set; }
        public virtual int? Idusers { get; set; }
        public virtual string Blocked { get; set; }
        public virtual DateTime? Date { get; set; }
    }
}
