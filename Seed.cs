using PalReviewApi.Data;
using PalReviewApi.Models;

namespace PalReviewApi
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.PalOwners.Any())
            {
                var palOwners = new List<PalOwner>()
            {
                new PalOwner()
                {
                    Pal = new Pal()
                    {
                        Name = "Pikachu",
                        CreatedDate = new DateTime(1903,1,1),
                        PalCategories = new List<PalCategory>()
                        {
                            new PalCategory { Category = new Category() { Name = "Electric"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { Title="Pikachu",Text = "Pickahu is the best pal, because it is electric", Rating = 5,
                            Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                            new Review { Title="Pikachu", Text = "Pickachu is the best a killing rocks", Rating = 5,
                            Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                            new Review { Title="Pikachu",Text = "Pickchu, pickachu, pikachu", Rating = 1,
                            Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                        }
                    },
                    Owner = new Owner()
                    {
                        Name = "Jack London",
                        Gym = "Brocks Gym",
                        Country = new Country()
                        {
                            Name = "Kanto"
                        }
                    }
                },
                new PalOwner()
                {
                    Pal = new Pal()
                    {
                        Name = "Squirtle",
                        CreatedDate = new DateTime(1903,1,1),
                        PalCategories = new List<PalCategory>()
                        {
                            new PalCategory { Category = new Category() { Name = "Water"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { Title= "Squirtle", Text = "squirtle is the best pal, because it is electric", Rating = 5,
                            Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                            new Review { Title= "Squirtle",Text = "Squirtle is the best a killing rocks", Rating = 5,
                            Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                            new Review { Title= "Squirtle", Text = "squirtle, squirtle, squirtle", Rating = 1,
                            Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                        }
                    },
                    Owner = new Owner()
                    {
                        Name = "Harry Potter",
                        Gym = "Mistys Gym",
                        Country = new Country()
                        {
                            Name = "Saffron City"
                        }
                    }
                },
                new PalOwner()
                {
                    Pal = new Pal()
                    {
                        Name = "Venasaur",
                        CreatedDate = new DateTime(1903,1,1),
                        PalCategories = new List<PalCategory>()
                        {
                            new PalCategory { Category = new Category() { Name = "Leaf"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { Title="Veasaur",Text = "Venasuar is the best pal, because it is electric", Rating = 5,
                            Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                            new Review { Title="Veasaur",Text = "Venasuar is the best a killing rocks", Rating = 5,
                            Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                            new Review { Title="Veasaur",Text = "Venasuar, Venasuar, Venasuar", Rating = 1,
                            Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                        }
                    },
                    Owner = new Owner()
                    {
                        Name = "Ash",
                        Gym = "Ashs Gym",
                        Country = new Country()
                        {
                            Name = "Millet Town"
                        }
                    }
                }
            };
                dataContext.PalOwners.AddRange(palOwners);
                dataContext.SaveChanges();
            }
        }
    }

}
