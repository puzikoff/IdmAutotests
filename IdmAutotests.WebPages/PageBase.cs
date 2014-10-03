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
        public Uri BaseUrl = new Uri(Settings.Default.TestEnvironment);
        
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
    }
}
