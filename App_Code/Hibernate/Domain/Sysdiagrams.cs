using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Sysdiagrams {
        public virtual int DiagramId { get; set; }
        [NotNullNotEmpty]
        public virtual string Name { get; set; }
        [NotNullNotEmpty]
        public virtual int PrincipalId { get; set; }
        public virtual int? Version { get; set; }
        public virtual byte[] Definition { get; set; }
    }
}
