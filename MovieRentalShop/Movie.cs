namespace MovieRentalShop
{
    public class Movie
    {
        private readonly string title;
        public const int CHILDREN = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        public Movie(string title, int priceCode)
        {
            PriceCode = priceCode;
            this.title = title;
        }

        public string Title
        {
            get { return title; }
        }

        public int PriceCode { get; set; }
    }
}
