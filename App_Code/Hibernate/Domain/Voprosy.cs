using System;
using System.Text;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Voprosy {
        public virtual int IdVoprosy { get; set; }
        public virtual int? Specialnost { get; set; }
        public virtual string Vopros { get; set; }
        public virtual int? Kategoria { get; set; }
    }

    public class VoprosyMap : ClassMap<Voprosy>
    {

        public VoprosyMap()
        {
            Table("voprosy");
            LazyLoad();
            Id(x => x.IdVoprosy).GeneratedBy.Identity().Column("id_voprosy");
            Map(x => x.Specialnost).Column("specialnost");
            Map(x => x.Vopros).Column("vopros");
            Map(x => x.Kategoria).Column("kategoria");
        }
    }
}
