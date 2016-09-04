using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class KategoriaMap : ClassMap<Kategoria> {
        
        public KategoriaMap() {
			Table("kategoria");
			LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
			Map(x => x.Kategoriaval).Column("kategoria").Not.Nullable();
        }
    }
}
