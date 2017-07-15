using System;

namespace Interpidians.Catalyst.Client.Web.Common
{
    public interface ISessionStore
    {
        event SessionChangeDelegate SessionChange;

        T GetItemFromSession<T>(string key);

        void SaveItemToSession<T>(string key, T item);

        void RemoveItemFromSession(string key);

        bool ItemExists(string key);

        void KillSession();

        TimeSpan GetSessionItemTimeSpan(string key);
    }

    public delegate void SessionChangeDelegate(object sender, EventArgs e);
}
