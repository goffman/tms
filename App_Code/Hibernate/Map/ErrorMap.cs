using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class ErrorMap : ClassMap<Error> {
        
        public ErrorMap() {
			Table("Error");
			LazyLoad();
			Id(x => x.IdError).GeneratedBy.Identity().Column("ID_error");
			Map(x => x.NameError).Column("name_error");
			Map(x => x.Errorval).Column("error").Not.Nullable();
        }
    }
}
