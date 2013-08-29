using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client.Document;

namespace RibeEsbjergHH.Models
{
    public class ParticipantRepository
    {
        static List<Participant> Participants = new List<Participant>();

        static DocumentStore store = new DocumentStore { ConnectionStringName = "RavenDB" };

        static ParticipantRepository()
        {
            store.Conventions.AllowQueriesOnId = true;
            store.Initialize();

            //Participants.Add( new Participant() { 
            //    Name = "Bjarne Hansen",
            //    Address = "Ribevej 2",
            //    PostalCode = "3456",
            //    City = "Esbjerg",
            //    Sex = "Dreng",
            //    Id = 1,
            //    Club = "Bramming IF",
            //    BornYear = 1998,
            //    HomePhone = "32456789",
            //    PlayerPosition = "Fløj",
            //    ParentName = "Malene Hansen",
            //    ParentEmail = "maleneh@xyz.abc",
            //    ParentMobile = "20202020",
            //    YearsOfHandball = 5 
            //});
            //Participants.Add( new Participant() { 
            //    Name = "Lone Wiig",
            //    Address = "Holstebrovej 234",
            //    PostalCode = "3456",
            //    City = "Esbjerg",
            //    Sex = "Pige",
            //    Id = 2,
            //    Club = "Bramming IF",
            //    BornYear = 2001,
            //    HomePhone = "32456789",
            //    PlayerPosition = "Bagspiller",
            //    ParentName = "Malene Hansen",
            //    ParentEmail = "maleneh@xyz.abc",
            //    ParentMobile = "20202020",
            //    YearsOfHandball = 5 
            //});
        }
  
        public IEnumerable<Participant> GetAll()
        {
            using (var session = store.OpenSession())
            {
                var results = from p in session.Query<Participant>()
                              select p;
                return results;
            }
        }

        public void Add(Participant participant)
        {
            using (var session = store.OpenSession())
            {
                session.Store(participant);
                session.SaveChanges();
            }
        }

        public void Change(int id, Participant participant)
        {
            using (var session = store.OpenSession())
            {
                var results = from p in session.Query<Participant>()
                              where p.Id == id
                              select p;
                var oldParticipant = results.First();
                session.Delete<Participant>(oldParticipant);
                session.Store(participant);
                session.SaveChanges();
            }
        }

        public Participant Get(int id)
        {
            using (var session = store.OpenSession())
            {
                var results = from p in session.Query<Participant>()
                              where p.Id == id
                              select p;
                return results.First();
            }
        }

        public void Delete(int id)
        {
            using (var session = store.OpenSession())
            {
                var results = from p in session.Query<Participant>()
                              where p.Id == id
                              select p;
                if (results != null && results.First() != null)
                {
                    session.Delete(results.First());
                    session.SaveChanges();
                }
            }
        }
   
    }
}