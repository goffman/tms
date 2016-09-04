using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class RecoveryPasswordMap : ClassMap<RecoveryPassword> {
        
        public RecoveryPasswordMap() {
			Table("recovery_password");
			LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            Map(x => x.IdUser).Column("ID_user");
			Map(x => x.Hash).Column("hash");
			Map(x => x.DateRecovery).Column("date_recovery");
        }
    }
}
