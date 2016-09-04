using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Dolzhnost {
        public Dolzhnost() { }
        public virtual int Id { get; set; }
        public virtual GruppaDolzhnost GruppaDolzhnost { get; set; }
        [NotNullNotEmpty]
        public virtual string Dolzhnostval { get; set; }
        public virtual int? Correctly { get; set; }
    }
}
