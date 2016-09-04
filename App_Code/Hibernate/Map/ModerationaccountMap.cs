using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class ModerationaccountMap : ClassMap<Moderationaccount> {
        
        public ModerationaccountMap() {
			Table("ModerationAccount");
			LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
           // Map(x => x.Id).Column("ID").Not.Nullable();
			Map(x => x.Userid).Column("UserID");
			Map(x => x.Answer).Column("Answer");
        }
    }
}
