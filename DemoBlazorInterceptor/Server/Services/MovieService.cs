using DemoBlazorInterceptor.Shared;

namespace DemoBlazorInterceptor.Server.Services
{
    public class MovieService
    {
        private List<Movie> _movieList;
        private int _counter = 0;
        public MovieService()
        {
            _movieList = new List<Movie>
            {
                new Movie
                {
                    Id = ++_counter,
                    Title = "Star wars : New Hope",
                    ReleaseYear = 1977,
                    MainActor = "Mark Hammil",
                    Genre = "Sci-fi"
                },
                new Movie
                {
                    Id = ++_counter,
                    Title = "Lotr : La communauté de l'anneau",
                    ReleaseYear = 1999,
                    MainActor = "Elijah Wood",
                    Genre = "Med-fan"
                }
            };
        }

        public List<Movie> GetAll() { return _movieList; }
        public void Add(Movie m)
        {
            m.Id = ++_counter;
            _movieList.Add(m);
        }
    }
}
