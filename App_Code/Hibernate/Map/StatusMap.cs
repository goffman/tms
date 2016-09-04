using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class StatusMap : ClassMap<Status> {
        
        public StatusMap() {
			Table("status");
			LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            Map(x => x.Idlkabinet).Column("id-l-kabinet").Not.Nullable();
			Map(x => x.Kontrol).Column("kontrol").Not.Nullable();
        }
    }
}
