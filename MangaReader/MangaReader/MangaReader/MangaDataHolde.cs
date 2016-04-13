using System;
using System.Collections.Generic;
using System.Text;

namespace MangaReader
{
    class MangaDataHolde
    {
        public int Manga_id = 0;
        public string Manga_name = "";
        public int Manga_chapter = 0;
        private List<MangaChapters> Manga_chapter_local = new List<MangaChapters>();
        public int Manga_chapter
        {
            get
            {
                return manga_chapter.Count;
            }
        }
    }

}
