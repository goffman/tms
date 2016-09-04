using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Guideblockreasons {
        public virtual int ID { get; set; }
        public virtual string Reasons { get; set; }
    }
}
