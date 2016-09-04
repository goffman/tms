using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class System {
        public virtual int ID { get; set; }
        public virtual string Param { get; set; }
        public virtual string Zn { get; set; }
    }
}
