using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Users {
        public virtual int Userid { get; set; }
        public virtual Lkabinet Lkabinet { get; set; }
        [NotNullNotEmpty]
        public virtual string Username { get; set; }
        [NotNullNotEmpty]
        public virtual string Password { get; set; }
        public virtual int? Moderacija { get; set; }
        public virtual DateTime? DateReg { get; set; }
        public virtual string ActivationId { get; set; }
    }
}
