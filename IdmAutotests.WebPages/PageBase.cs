using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using IdmAutotests.Utilities;
using IdmAutotests.Utilities.WebElement;
using IdmAutotests.WebPages.Properties;

namespace IdmAutotests.WebPages
{
    public abstract class PageBase
    {
        public Uri BaseUrl = new Uri("http://WIN-CV4AVBPAV8A/idsrv");
        
        public void Open()
        {
            Contract.Requires(BaseUrl != null);
            Browser.WaitAjax();  
            Browser.Navigate(BaseUrl);
        }

        public Type PageName()
        {
            return GetType();
        }

        public bool TextExists(string text, bool exactMach = true, int timeout = 5)
        {
            return new WebElement().ByText(text, exactMach).Exists(timeout);
        }

        protected void Navigate(Uri url)
        {
            Contract.Requires(url != null);

            Browser.Navigate(url);
        }

        protected static Uri GetUriByRelativePath(string relativePath)
        {
            return new Uri(string.Format("{0}{1}", Settings.Default.TestEnvironment, relativePath).ToLower());
        }

        private string RelativePath
        {
            get
            {
                const string rootNamespaceName = "Autotests.WebPages.Root";
                var className = GetType().FullName;

                Contract.Assume(className != null);

                var path = className
                    .Replace(rootNamespaceName, string.Empty)
                    .Replace(".", "/");
                
                path = Regex.Replace(path, "/Index$", "");

                return path;
            }
        }
    }
}
