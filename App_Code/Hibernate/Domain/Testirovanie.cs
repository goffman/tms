using System;
using System.Text;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain
{

    public class Testirovanie
    {
        public virtual int ID { get; set; }
        public virtual Lkabinet Lkabinet { get; set; }
        [NotNullNotEmpty]
        public virtual Voprosy IdVopros { get; set; }
        public virtual int? IdOtvet { get; set; }
        [NotNullNotEmpty]
        public virtual int IdTest { get; set; }
    }

    public class TestirovanieMap : ClassMap<Testirovanie>
    {

        public TestirovanieMap()
        {
            Table("[testirovanie]");
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            References(x => x.Lkabinet).Column("ID_testiruemyj");
            References(x => x.IdVopros).Column("ID_vopros");
            Map(x => x.IdOtvet).Column("ID_otvet");
            Map(x => x.IdTest).Column("ID_test").Not.Nullable();
        }
    }
}
