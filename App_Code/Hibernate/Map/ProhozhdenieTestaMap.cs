using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class ProhozhdenieTestaMap : ClassMap<ProhozhdenieTesta> {
        
        public ProhozhdenieTestaMap() {
			Table("prohozhdenie_testa");
			LazyLoad();
			References(x => x.Lkabinet).Column("ID_testiruemyj");
			References(x => x.Dolzhnost).Column("ID_dolzhnost");
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
           // Map(x => x.Id).Column("ID").Not.Nullable();
			Map(x => x.Rezultat).Column("rezultat");
			Map(x => x.Data).Column("data");
			Map(x => x.Status).Column("status").Not.Nullable();
			Map(x => x.NaimenovanieTesta).Column("naimenovanie_testa").Not.Nullable();
			Map(x => x.Otpravlen).Column("otpravlen");
			Map(x => x.Time).Column("time");
        }
    }
}
