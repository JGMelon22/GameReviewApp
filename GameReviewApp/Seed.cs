// Will populate the tables on un run time

using GameReviewApp.Models;

namespace GameReviewApp;

public class Seed
{
    private readonly DataContext _dataContext;

    public Seed(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void SeedDataContext()
    {
        if (!_dataContext.GamesPublishers.Any())
        {
            var gamePublishers = new List<GamePublisher>
            {
                new()
                {
                    Game = new Game
                    {
                        Name = "Resident Evil Village",
                        ReleaseDate = new DateTime(2021, 5, 7),
                        GameCategories = new List<GameCategory>
                        {
                            new() {Category = new Category {Name = "Horror"}}
                        },

                        Reviews = new List<Review>
                        {
                            new()
                            {
                                Title = "Resident Evil Village",
                                Text = "Even better than RE VII! Really gorgeous and spooky game. A must have!",
                                Rating = 5,
                                Reviewer = new Reviewer {FirstName = "Antonio", LastName = "Carlos"}
                            },

                            new()
                            {
                                Title = "Resident Evil Village",
                                Text = "A very good game, but could be better! Really gorgeous, but kinda buggy.",
                                Rating = 4,
                                Reviewer = new Reviewer {FirstName = "Pedro", LastName = "Enrique"}
                            },

                            new()
                            {
                                Title = "Resident Evil Village",
                                Text = "Big tits vampire lady. YES!",
                                Rating = 5,
                                Reviewer = new Reviewer {FirstName = "Mike", LastName = "Loks"}
                            }
                        }
                    },

                    Publisher = new Publisher
                    {
                        Name = "Capcom",
                        Country = new Country
                        {
                            Name = "Japan"
                        }
                    }
                },

                new()
                {
                    Game = new Game
                    {
                        Name = "Horizon Zero Dawn",
                        ReleaseDate = new DateTime(2017, 2, 28),
                        GameCategories = new List<GameCategory>
                        {
                            new() {Category = new Category {Name = "Action"}}
                        },

                        Reviews = new List<Review>
                        {
                            new()
                            {
                                Title = "Horizon Zero Dawn",
                                Text = "A pretty game, but runs quit bad on base PS4.",
                                Rating = 3,
                                Reviewer = new Reviewer {FirstName = "Antonio", LastName = "Carlos"}
                            },

                            new()
                            {
                                Title = "Horizon Zero Dawn",
                                Text = "Runs fine on PS4 Pro and PS5.",
                                Rating = 4,
                                Reviewer = new Reviewer {FirstName = "Pedro", LastName = "Enrique"}
                            },

                            new()
                            {
                                Title = "Horizon Zero Dawn",
                                Text = "Hats off to Sony. 100 FPS on Pc with a Radeon 6800 Non Xt",
                                Rating = 5,
                                Reviewer = new Reviewer {FirstName = "Mike", LastName = "Loks"}
                            }
                        }
                    },

                    Publisher = new Publisher
                    {
                        Name = "Sony",
                        Country = new Country
                        {
                            Name = "Japan"
                        }
                    }
                },
                new()
                {
                    Game = new Game
                    {
                        Name = "Forza Horizon 5",
                        ReleaseDate = new DateTime(2021, 11, 5),
                        GameCategories = new List<GameCategory>
                        {
                            new() {Category = new Category {Name = "Racing"}}
                        },

                        Reviews = new List<Review>
                        {
                            new()
                            {
                                Title = "Forza Horizon 5",
                                Text = "Same game, fun and stuff, but could be bold on new features...",
                                Rating = 2,
                                Reviewer = new Reviewer {FirstName = "Antonio", LastName = "Carlos"}
                            },

                            new()
                            {
                                Title = "Forza Horizon 5",
                                Text = "A beautiful game, runs butter smooth on Xbox Series S",
                                Rating = 5,
                                Reviewer = new Reviewer {FirstName = "Pedro", LastName = "Enrique"}
                            },

                            new()
                            {
                                Title = "Forza Horizon 5",
                                Text = "Great casual driving mechanics and land scape. TY Playground games :)",
                                Rating = 5,
                                Reviewer = new Reviewer {FirstName = "Mike", LastName = "Loks"}
                            }
                        }
                    },

                    Publisher = new Publisher
                    {
                        Name = "Microsoft",
                        Country = new Country
                        {
                            Name = "USA"
                        }
                    }
                }
            };

            _dataContext.GamesPublishers.AddRange(gamePublishers);
            _dataContext.SaveChanges();
        }
    }
}