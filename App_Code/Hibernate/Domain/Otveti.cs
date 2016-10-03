using System;
using System.Text;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Otveti {
        public virtual int Id { get; set; }
        public virtual string Otvet { get; set; }
        [NotNullNotEmpty]
        public virtual int Vernyj { get; set; }
        public virtual int IdVoprosy { get; set; }
    }

    public class OtvetiMap : ClassMap<Otveti>
    {

        public OtvetiMap()
        {
            Table("otveti");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            Map(x => x.Otvet).Column("otvet");
            Map(x => x.Vernyj).Column("vernyj").Not.Nullable();
            Map(x => x.IdVoprosy).Column("ID_voprosy");
        }
    }
}
