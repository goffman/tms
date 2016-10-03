using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Hibernate.Domain;
using Hibernate.Map;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Hibernate
{
    /// <summary>
    /// Сводное описание для DataBase
    /// </summary>
    public static class DataBase
    {
        private static ISessionFactory _sessionFactory = null;

        private static void OpenConnection()
        {
            ISessionFactory factory = Fluently.Configure()
.Database(MsSqlConfiguration.MsSql2012.ConnectionString(builder =>
builder.Database("tms").
Password("123").
Server("SERVERBD\\SQLSERVER2014").
Username("sa")).ShowSql())
 .Mappings(configuration => configuration.FluentMappings.Add<TestirovanieMap>())
 .Mappings(configuration => configuration.FluentMappings.Add<LkabinetMap>())
 .Mappings(configuration => configuration.FluentMappings.Add<LpuMap>())
 .Mappings(configuration => configuration.FluentMappings.Add<VoprosyMap>())
 .Mappings(configuration => configuration.FluentMappings.Add<OtvetiMap>())
 .Mappings(configuration => configuration.FluentMappings.Add<ProhozhdenieTestaMap>())
 .Mappings(configuration => configuration.FluentMappings.Add<DolzhnostMap>())
 .Mappings(configuration => configuration.FluentMappings.Add<GruppaDolzhnostMap>())
       .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
       .BuildSessionFactory();
            _sessionFactory = factory;
        }

        private static ISession _currentSession = null;
        public static ISession GetSession()
        {
            if (_currentSession==null)
            {
                if (_sessionFactory == null) OpenConnection();
                if (_sessionFactory != null) _currentSession = _sessionFactory.OpenSession();
                //if (_sessionFactory != null) return _sessionFactory.OpenSession();
            }
            else
            {
                _currentSession.Flush();
                if (_currentSession.IsOpen==false) _currentSession = _sessionFactory.OpenSession();
            }


            return _currentSession;
            //if (_sessionFactory == null)
            //{
            //    OpenConnection();
            //    if (_sessionFactory != null) return _sessionFactory.OpenSession();
            //}
            //else
            //{
            //    return _sessionFactory.OpenSession();
            //}
            //return null;

        }
        public static class Execute 
        {
            public static object GetObject(Type type, int id)
            {

                var session = GetSession();
                if (session != null)
                {
                    using (var tx = session.BeginTransaction())
                    {
                        var t2 = session.Get(type, id);
                        tx.Commit();
                        return t2;
                    }
                }
                return null;
            }

            public static object TransactionCommit(Object obj)
            {

                var session = GetSession();
                ITransaction transaction = session.BeginTransaction();
                try
                {
                    var s = obj.GetType().GetProperty("Id");
                    var id = (int)(s.GetValue(obj, null));
                    if (id != 0)
                    {
                        session.Merge(obj);
                    }
                    else
                    {
                        session.SaveOrUpdate(obj);
                    }

                    transaction.Commit();
                    session.Flush();
                    session.Evict(obj);
                    session.Clear();

                    //session.Delete(obj);
                    //  status.FreeParameter=Convert.ToString(GetObjectID(dataBase,obj));
                    //  session.Dispose();
                    //session.Flush();
                    //session.Clear();
                    //  status.Execute=ResultExecute.StatusExecute.Success;
                }
                catch (Exception ex)
                {
                   // Logger.Logger.Write(MsgType.Error, ex);
                    //try {
                    //    session.Merge(obj);
                    //    transaction.Commit();
                    //} catch (Exception e) {

                    //    Logger.Write(MsgType.Error,"TransactionCommit: " + e);
                    //    status.Execute = ResultExecute.StatusExecute.Error;
                    //    status.ErrorExecuteMessage = ex.Message + " \n" + ex.InnerException;
                    //}
                    //  Logger.Write(MsgType.Error,"TransactionCommit: "+ex);
                    //  status.Execute=ResultExecute.StatusExecute.Error;
                    // status.ErrorExecuteMessage=ex.Message+" \n"+ex.InnerException;
                    // session.Dispose();
                }

                return obj;
            }
        }
    }
}