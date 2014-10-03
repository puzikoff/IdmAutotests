using System;

namespace IdmAutotests.Utilities.WebElement
{
    public class WebElementNotFoundException : Exception
    {
        public WebElementNotFoundException(string message) : base(message)
        {
        }
    }
}
