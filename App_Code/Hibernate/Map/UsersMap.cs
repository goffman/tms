using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class UsersMap : ClassMap<Users> {
        
        public UsersMap() {
			Table("users");
			LazyLoad();
			Id(x => x.Userid).GeneratedBy.Identity().Column("UserID");
			References(x => x.Lkabinet).Column("ID_l_kabinet");
			Map(x => x.Username).Column("UserName").Not.Nullable();
			Map(x => x.Password).Column("Password").Not.Nullable();
			Map(x => x.Moderacija).Column("Moderacija");
			Map(x => x.DateReg).Column("date_reg");
			Map(x => x.ActivationId).Column("activation_id");
        }
    }
}
