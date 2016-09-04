using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class LkabinetMap : ClassMap<Lkabinet> {
        
        public LkabinetMap() {
			Table("l-kabinet");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("ID");
			References(x => x.Lpu).Column("ID_lpu");
			Map(x => x.F).Column("F");
			Map(x => x.I).Column("I");
			Map(x => x.O).Column("O");
			Map(x => x.IdDolzhnost).Column("ID_dolzhnost");
			Map(x => x.Stazh).Column("stazh").Not.Nullable();
			Map(x => x.Email).Column("email");
			Map(x => x.Kategoria).Column("kategoria");
			Map(x => x.ProbaTest).Column("proba_test");
			Map(x => x.Telefon).Column("telefon");
			Map(x => x.OnDelete).Column("on_delete");
			Map(x => x.Sessionid).Column("SessionID");
        }
    }
}
