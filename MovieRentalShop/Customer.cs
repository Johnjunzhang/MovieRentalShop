using System.Collections.Generic;

namespace MovieRentalShop
{
    public class Customer
    {
        private readonly string name;
        private readonly List<Rental> rentals = new List<Rental>();
        public Customer(string name)
        {
            this.name = name;
        }

        public void AddRentals(Rental rental)
        {
            rentals.Add(rental);
        }

        public string Name
        {
            get { return name; }
        }
        
        public string Statement()
        {
            double totalAmount = 0;
            var frequentRenterPoints = 0;
            var result = "Rental Record for " + name + "\n";

            foreach (var each in rentals)
            {
                double thisAmount = 0;
                switch (each.Movie.PriceCode)
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                            thisAmount += (each.DaysRented - 2)*1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.DaysRented*3;
                        break;
                    case Movie.CHILDREN:
                        thisAmount += 1.5;
                        if (each.DaysRented > 3)
                            thisAmount += (each.DaysRented - 3)*1.5;
                        break;
                }

                // add frequent renter points
                frequentRenterPoints++;

                // add bonus for a two day new release rental
                if ((each.Movie.PriceCode == Movie.NEW_RELEASE) && each.DaysRented > 1) frequentRenterPoints++;

                // show figures for the rental
                result += " " + each.Movie.Title + " " + thisAmount + "\n";
                totalAmount += thisAmount;
            }

            // add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }
    }
}