using Microsoft.EntityFrameworkCore;
using NHibernate.Cfg;
using NHibernateVsEFcoreQuerys.Models;
using System;
using System.Linq;
using System.Transactions;

namespace NHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var db = new SampleContext())
            //{
            //    db.Database.EnsureCreated();

            //    var x = db.Database.GenerateCreateScript();
            //    var y = db.Database.GetMigrations();
            //    var o = db.Database.GetPendingMigrations();

            //    db.Eventos.Add(new Evento
            //    {
            //        Cidade = "Sao Paulo",
            //        Nome = "MVPCOnf"
            //    });

            //    db.SaveChanges();
            //}

            var configuration = new Configuration()
                .Configure("hibernate.cfg.xml")
                ;//.Configure("Mapping.hbm.xml"); 

            var SessionFactory = configuration.BuildSessionFactory();
            ISession session = SessionFactory.OpenSession();

            var eventos = session.CreateQuery("SELECT e.Id FROM Eventos e").List<Evento>();//.Query<Evento>().ToList(); 

            Console.WriteLine("Hello World!");
        }
    }
}
