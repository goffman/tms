using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Moderationaccount {
        [NotNullNotEmpty]
        public virtual int Id { get; set; }
        public virtual int? Userid { get; set; }
        public virtual string Answer { get; set; }
    }
}
