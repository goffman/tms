using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class SNewsMap : ClassMap<SNews> {
        
        public SNewsMap() {
			Table("s_news");
			LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            //Map(x => x.Id).Column("ID").Not.Nullable();
			Map(x => x.News).Column("news");
			Map(x => x.Data).Column("data");
        }
    }
}
