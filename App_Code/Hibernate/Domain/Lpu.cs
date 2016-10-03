using System;
using System.Text;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Lpu {
        public Lpu() { }
        public virtual int Id { get; set; }
        public virtual string Lpuval { get; set; }
    }

    public class LpuMap : ClassMap<Lpu>
    {
        public LpuMap()
        {
            Table("lpu");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Map(x => x.Lpuval).Column("lpu");
        }
    }
}
