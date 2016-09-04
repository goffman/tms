using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Admindostyp {
        public Admindostyp() { }
        public virtual int Id { get; set; }
        [NotNullNotEmpty]
        public virtual int Dostyp { get; set; }
        public virtual string Opisanie { get; set; }
        public virtual string Tip { get; set; }
    }
}
