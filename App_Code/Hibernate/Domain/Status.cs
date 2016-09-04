using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Status {
        public virtual int ID { get; set; }
        [NotNullNotEmpty]
        public virtual int Idlkabinet { get; set; }
        [NotNullNotEmpty]
        public virtual int Kontrol { get; set; }
    }
}
