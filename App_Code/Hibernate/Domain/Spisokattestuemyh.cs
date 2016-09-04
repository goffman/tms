using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Spisokattestuemyh {
        public virtual int Id { get; set; }
        public virtual Lkabinet Lkabinet { get; set; }
        [NotNullNotEmpty]
        public virtual string F { get; set; }
        [NotNullNotEmpty]
        public virtual string I { get; set; }
        [NotNullNotEmpty]
        public virtual string O { get; set; }
        [NotNullNotEmpty]
        public virtual int Dolzhnostid { get; set; }
        [NotNullNotEmpty]
        public virtual int Lpuid { get; set; }
    }
}
