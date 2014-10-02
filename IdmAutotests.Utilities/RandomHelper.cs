using System.IO;

namespace IdmAutotests.Utilities
{
    public static class RandomHelper
    {
        public static string RandomString
        {
            get { return Path.GetRandomFileName().Replace(".", string.Empty); }
        }
    }
}
