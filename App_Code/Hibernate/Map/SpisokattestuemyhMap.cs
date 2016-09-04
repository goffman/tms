using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class SpisokattestuemyhMap : ClassMap<Spisokattestuemyh> {
        
        public SpisokattestuemyhMap() {
			Table("SpisokAttestuemyh");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("ID");
			References(x => x.Lkabinet).Column("UserID");
			Map(x => x.F).Column("F").Not.Nullable();
			Map(x => x.I).Column("I").Not.Nullable();
			Map(x => x.O).Column("O").Not.Nullable();
			Map(x => x.Dolzhnostid).Column("DolzhnostID").Not.Nullable();
			Map(x => x.Lpuid).Column("LPUID").Not.Nullable();
        }
    }
}
