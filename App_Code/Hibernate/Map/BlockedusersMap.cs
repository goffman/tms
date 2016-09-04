using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class BlockedusersMap : ClassMap<Blockedusers> {
        
        public BlockedusersMap() {
			Table("BlockedUsers");
			LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            Map(x => x.Idusers).Column("IDUsers");
			Map(x => x.Blocked).Column("Blocked");
			Map(x => x.Date).Column("date");
        }
    }
}
