using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class AdminusersMap : ClassMap<Adminusers> {
        
        public AdminusersMap() {
			Table("AdminUsers");
			LazyLoad();
			Id(x => x.Userid).GeneratedBy.Identity().Column("UserID");
			Map(x => x.Username).Column("UserName").Not.Nullable();
			Map(x => x.Password).Column("Password").Not.Nullable();
			Map(x => x.Fio).Column("FIO");
			Map(x => x.Lastentry).Column("LastEntry");
        }
    }
}
