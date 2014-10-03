using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdmAutotests.Utilities.WebElement;
using IdmAutotests.Utilities;
using IdmAutotests.Utilities.Tags;
using System.Diagnostics.Contracts;

namespace IdmAutotests.WebPages
{
    public class LogOn : PageBase
    {
        #region Elements

        private static readonly WebElement LoginEdit = new WebElement().ById("UserName");
        private static readonly WebElement PasswordEdit = new WebElement().ById("Password");
        private static readonly WebElement SubmitBtn = new WebElement().ByName("submit.Save");
        private static readonly WebElement ValidationSummary = new WebElement().ByClass("validation-summary-errors");

        #endregion

        public void DoLogOn(string UserName, string Password)
        {
            LoginEdit.Text = UserName;
            PasswordEdit.Text = Password;
            SubmitBtn.Click();           
        }

        public void Open()
        {
            Navigate(BaseUrl);
        }
    }
}
