using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Lkabinet {
        public Lkabinet() { }
        public virtual int Id { get; set; }
        public virtual Lpu Lpu { get; set; }
        public virtual string F { get; set; }
        public virtual string I { get; set; }
        public virtual string O { get; set; }
        public virtual int? IdDolzhnost { get; set; }
        [NotNullNotEmpty]
        public virtual int Stazh { get; set; }
        public virtual string Email { get; set; }
        public virtual int? Kategoria { get; set; }
        public virtual int? ProbaTest { get; set; }
        public virtual string Telefon { get; set; }
        public virtual int? OnDelete { get; set; }
        public virtual string Sessionid { get; set; }
    }
}
