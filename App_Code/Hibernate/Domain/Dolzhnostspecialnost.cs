using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Dolzhnostspecialnost {
        public virtual int ID { get; set; }
        public virtual int? Dolzhnost { get; set; }
        public virtual int? Specialnost { get; set; }
    }
}
