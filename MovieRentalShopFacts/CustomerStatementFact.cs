using MovieRentalShop;
using Xunit;

namespace MovieRentalShopFacts
{
    public class CustomerStatementFact
    {
        [Fact]
        public void should_get_right_statement_for_rental_two_regular_movie()
        {
            const string expectedStatement = "Rental Record for Kent Back\n The Shawshank Redemption 2\n Braveheart 3.5\nAmount owed is 5.5\nYou earned 2 frequent renter points";
            var customer = new Customer("Kent Back");
            AddRental(customer, "The Shawshank Redemption", Movie.REGULAR, 2);
            AddRental(customer, "Braveheart", Movie.REGULAR, 3);

            Assert.Equal(expectedStatement, customer.Statement());
        }

        [Fact]
        public void should_get_right_statement_for_rental_two_children_movie()
        {
            const string expectedStatement = "Rental Record for Martin Fowler\n Mickey's Great Clubhouse House 1.5\n Xi YangYang 3\nAmount owed is 4.5\nYou earned 2 frequent renter points";
            var customer = new Customer("Martin Fowler");
            AddRental(customer, "Mickey's Great Clubhouse House", Movie.CHILDREN, 2);
            AddRental(customer, "Xi YangYang", Movie.CHILDREN, 4); 

            Assert.Equal(expectedStatement, customer.Statement());
        }

        [Fact]
        public void should_get_right_statement_for_rental_two_new_release_movie()
        {
            const string expectedStatement = "Rental Record for Jim HighSmith\n The Lord of the Rings 2\n Harry Potter 3.5\nAmount owed is 5.5\nYou earned 2 frequent renter points";
            var customer = new Customer("Jim HighSmith");
            AddRental(customer, "The Lord of the Rings", Movie.REGULAR, 2);
            AddRental(customer, "Harry Potter", Movie.REGULAR, 3); 

            Assert.Equal(expectedStatement, customer.Statement());
        }

        private static void AddRental(Customer customer, string moiveName, int priceCode, int daysRented)
        {
            var movie = new Movie(moiveName, priceCode);
            var rental = new Rental(movie, daysRented);
            customer.AddRentals(rental);
        }
    }
}
