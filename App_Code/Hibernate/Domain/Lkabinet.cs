using System;
using System.Text;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Lkabinet {
        public Lkabinet() { }
        public virtual int Id { get; set; }
        public virtual Lpu Lpu { get; set; }
        public virtual string F { get; set; }
        public virtual string I { get; set; }
        public virtual string O { get; set; }
        public virtual int? IdDolzhnost { get; set; }
        [NotNullNotEmpty]
        public virtual int Stazh { get; set; }
        public virtual string Email { get; set; }
        public virtual int? Kategoria { get; set; }
        public virtual int? ProbaTest { get; set; }
        public virtual string Telefon { get; set; }
        public virtual int? OnDelete { get; set; }
        public virtual string Sessionid { get; set; }

        public static Lkabinet GetById(int id)
        {
            var result = (Lkabinet)DataBase.Execute.GetObject(typeof(Lkabinet), id);
            return result ?? new Lkabinet();
        }
    }

    public class LkabinetMap : ClassMap<Lkabinet>
    {

        public LkabinetMap()
        {
            Table("[l-kabinet]");
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
