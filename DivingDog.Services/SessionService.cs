using DivingDog.Services.Models;
using DivingDog.Services.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivingDog.Services
{
    public class SessionService
    {
        private List<SessionModel> _sessions;
        public SessionService()
        {
            _sessions = new List<SessionModel>();
        }

        public SessionModel GetSessionById(string id)
        {
            return _sessions.Where(c => c.Id == id).First();
        }

        public SessionModel GetSessionByIdOrCreateNewSession(string sessionId)
        {
            if (Exists(sessionId))
                return GetSessionById(sessionId);
            else
            {
                var session = new SessionModel { Id = sessionId };
                _sessions.Add(session);

                return session;
            }
        }
        public void AddSearch(string sessionId, SearchParameterModel searchParameters)
        {
            var session = GetSessionByIdOrCreateNewSession(sessionId);
            session.Searches.Add(searchParameters);
        }
        public void AddSearch(string sessionId, Guid locationId)
        {
            var searchParameters = new SearchParameterModel(locationId);
            AddSearch(sessionId, searchParameters);
        }

        public void AddSearch(string sessionId, Guid locationId, DateTime fromDate, DateTime toDate)
        {
            var searchParameters = new SearchParameterModel(locationId, fromDate, toDate);
            AddSearch(sessionId, searchParameters);
        }

        public bool Exists(string sessionId)
        {
            return _sessions.Where(c => c.Id == sessionId).Any();
        }
    }
}
