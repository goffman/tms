using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class AdmindostypMap : ClassMap<Admindostyp> {
        
        public AdmindostypMap() {
			Table("AdminDostyp");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id");
			Map(x => x.Dostyp).Column("Dostyp").Not.Nullable();
			Map(x => x.Opisanie).Column("opisanie");
			Map(x => x.Tip).Column("tip");
        }
    }
}
