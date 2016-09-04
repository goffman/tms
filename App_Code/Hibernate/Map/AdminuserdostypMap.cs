using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class AdminuserdostypMap : ClassMap<Adminuserdostyp> {
        
        public AdminuserdostypMap() {
			Table("AdminUserDostyp");
			LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            References(x => x.Adminusers).Column("AdminUsers");
			References(x => x.Admindostyp).Column("AdminDostyp");
        }
    }
}
