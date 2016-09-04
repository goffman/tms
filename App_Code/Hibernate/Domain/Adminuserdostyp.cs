using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Adminuserdostyp {
        public virtual int ID { get; set; }
        public virtual Adminusers Adminusers { get; set; }
        public virtual Admindostyp Admindostyp { get; set; }
    }
}
