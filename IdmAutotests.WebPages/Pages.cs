﻿using IdmAutotests.WebPages.Root;

namespace IdmAutotests.WebPages
{
    public static class Pages
    {
        public static Index Index = new Index();

        public static class Manager
        {
            public static class Websites
            {
                public static Root.Manager.Website.Index Index = new Root.Manager.Website.Index();
            }
        }
    }
}
