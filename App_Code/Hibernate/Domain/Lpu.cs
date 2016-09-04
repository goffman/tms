using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Lpu {
        public Lpu() { }
        public virtual int Id { get; set; }
        public virtual string Lpuval { get; set; }
    }
}
