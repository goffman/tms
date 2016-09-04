using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class TestirovanieMap : ClassMap<Testirovanie> {
        
        public TestirovanieMap() {
			Table("testirovanie");
			LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            References(x => x.Lkabinet).Column("ID_testiruemyj");
			Map(x => x.IdVopros).Column("ID_vopros").Not.Nullable();
			Map(x => x.IdOtvet).Column("ID_otvet");
			Map(x => x.IdTest).Column("ID_test").Not.Nullable();
        }
    }
}
