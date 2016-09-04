using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class GruppaDolzhnost {
        public GruppaDolzhnost() { }
        public virtual int Id { get; set; }
        public virtual string Gruppa { get; set; }
    }
}
