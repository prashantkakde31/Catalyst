using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace Interpidians.Catalyst.Client.Web.Common
{
    public class SessionStore : ISessionStore
    {
        private const string SESSION_KEY = "SessionItemTracker";
        public event SessionChangeDelegate SessionChange;

        private void OnSessionChange(EventArgs e)
        {
            SessionChangeDelegate sessionHandler = SessionChange;
            if (sessionHandler != null)
            {
                sessionHandler(this, e);
            }
        }

        private HttpSessionState GetSessionState()
        {
            return HttpContext.Current.Session;
        }

        public bool ItemExists(string key)
        {
            if (GetSessionState()[key] != null)
            {
                return true;
            }
            return false;
        }

        public T GetItemFromSession<T>(string key)
        {

            T item = (T)GetSessionState()[key];
            return item;
        }

        public TimeSpan GetSessionItemTimeSpan(string key)
        {
            TimeSpan span = new TimeSpan(0);

            if (ItemExists(key))
            {
                var tracker = GetSessionTracker();

                if (tracker.ContainsKey(key))
                {
                    DateTime dateAdded = tracker[key];
                    DateTime current = DateTime.UtcNow;
                    span = current.Subtract(dateAdded);

                }

            }


            return span;
        }

        private Dictionary<string, DateTime> GetSessionTracker()
        {

            if (!ItemExists(SESSION_KEY))
            {
                GetSessionState().Add(SESSION_KEY, new Dictionary<string, DateTime>());
            }

            Dictionary<string, DateTime> tracker = GetItemFromSession<Dictionary<string, DateTime>>(SESSION_KEY);

            return tracker;
        }

        public void SaveItemToSession<T>(string key, T item)
        {
            GetSessionState()[key] = item;


            Dictionary<string, DateTime> tracker = GetSessionTracker();
            if (tracker.ContainsKey(key))
            {
                tracker[key] = DateTime.UtcNow;
            }
            else
            {
                tracker.Add(key, DateTime.UtcNow);
            }
            GetSessionState()[SESSION_KEY] = tracker;


            OnSessionChange(new EventArgs());
        }

        public void RemoveItemFromSession(string key)
        {
            if (ItemExists(key))
            {
                GetSessionState().Remove(key);
                OnSessionChange(new EventArgs());
            }
        }

        public void KillSession()
        {
            GetSessionState().Clear();
            OnSessionChange(new EventArgs());
        }

    }
}