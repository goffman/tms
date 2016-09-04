using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Error {
        public virtual int IdError { get; set; }
        public virtual string NameError { get; set; }
        [NotNullNotEmpty]
        public virtual string Errorval { get; set; }
    }
}
