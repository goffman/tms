using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Adminusers {
        public Adminusers() { }
        public virtual int Userid { get; set; }
        [NotNullNotEmpty]
        public virtual string Username { get; set; }
        [NotNullNotEmpty]
        public virtual string Password { get; set; }
        public virtual string Fio { get; set; }
        public virtual DateTime? Lastentry { get; set; }
    }
}
