namespace _02.ArticleStorage
{
    using System;
    public class Article : IComparable
    {
        public Article(string barcode, string vendor, string title, decimal price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public string Barcode { get; private set; }

        public string Vendor { get; private set; }

        public string Title { get; private set; }

        public decimal Price { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", this.Barcode, this.Vendor, this.Title, this.Price);
        }

        public int CompareTo(object obj)
        {
            Article other = obj as Article;
            return this.CompareTo(other);
        }
    }
}
