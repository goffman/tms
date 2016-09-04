using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class SNews {
        [NotNullNotEmpty]
        public virtual int Id { get; set; }
        public virtual string News { get; set; }
        public virtual DateTime? Data { get; set; }
    }
}
