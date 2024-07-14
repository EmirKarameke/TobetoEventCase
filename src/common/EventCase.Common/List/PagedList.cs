namespace EventCase.Common.List
{
    public class PagedList<T>
    {
        public PagedList()
        {
            DisplayRowCounts = new List<int>() { 10, 20, 50, 100 };
            DisplayPerPage = 10;
            CurrentPage = 1;
            DisplayedResult = new List<T>();
            DisplayedPageNumbers = new List<int>();
        }
        public int CurrentPage { get; set; }

        public int TotalPageCount { get; set; }

        /// <summary>
        /// Bir sayfada gösterilecek kayıt sayısı
        /// </summary>
        public int DisplayPerPage { get; set; }
        /// <summary>
        /// Kullanıcıların bir sayfada göstermek istedikleri kayıt sayılarını seçebilecekleri liste.
        /// </summary>
        public List<int> DisplayRowCounts { get; set; }
        /// <summary>
        /// Görüntülenen sayfa sayıları
        /// </summary>
        public List<int> DisplayedPageNumbers { get; set; }

        public void SetPageNumbers()
        {
            DisplayedPageNumbers = new List<int>();
            DisplayedPageNumbers.Add(CurrentPage);
            if (TotalPageCount != 0)
            {
                int index = 1;
                while (DisplayedPageNumbers.Count != 10)
                {
                    if (CurrentPage - index > 0) DisplayedPageNumbers.Add(CurrentPage - index);
                    if (CurrentPage + index <= TotalPageCount) DisplayedPageNumbers.Add(CurrentPage + index);
                    index++;
                    if (DisplayedPageNumbers.Count == TotalPageCount) break;
                }
            }

            DisplayedPageNumbers = DisplayedPageNumbers.OrderBy(i => i).ToList();
        }

        private int _totalRowCount;
        public int TotalRowCount
        {
            get => _totalRowCount;
            set
            {
                _totalRowCount = value;
                TotalPageCount = (int)Math.Ceiling((decimal)TotalRowCount / DisplayPerPage);
            }
        }

        public string RowMessage
        {
            get
            {
                return
                    $"Toplam {TotalRowCount} kayıt içinden : {(DisplayPerPage * (CurrentPage - 1)) + 1} - {DisplayPerPage * CurrentPage}";
            }
        }

        public List<T> DisplayedResult { get; set; }
    }
}
