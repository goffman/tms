using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Attestacija {
        public virtual int Id { get; set; }
        public virtual Dolzhnost Dolzhnost { get; set; }
        [NotNullNotEmpty]
        public virtual DateTime Data { get; set; }
    }
}
