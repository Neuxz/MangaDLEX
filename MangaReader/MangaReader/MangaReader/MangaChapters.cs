﻿using System;
using System.Collections.Generic;
using System.Text;
#if __ANDROID__
using Android.Media;
#endif

namespace MangaReader
{
    class MangaChapters
    {
        public int chapterID = 0;
#if __ANDROID__
        List<Image> pages = new List<Image>();
#endif
    }
}
