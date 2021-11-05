using System;
using System.Collections.Generic;
using System.Linq;

namespace Rent.Client.Services
{
    public class PageHistoryState
    {
        private List<string> previousPages;

        public PageHistoryState()
        {
            previousPages = new List<string>();
        }
        public void AddPage(string pageName)
        {
            previousPages.Add(pageName);
        }

        public string PreviousPage()
        {
            if (previousPages.Count > 1)
            {
                return previousPages.ElementAt(previousPages.Count - 2);
            }

            return previousPages.FirstOrDefault();
        }

        public bool CanGoBack()
        {
            return previousPages.Count > 1;
        }
    }
}
