using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Specialnost {
        public virtual int IdSpecialnost { get; set; }
        public virtual string Naimenovanie { get; set; }
    }
}
