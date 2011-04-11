using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            foreach (Movie m in movies)
            {
                yield return m;
            }
        }


        public void add(Movie movie)
        {
            if (!movies.Contains(movie))
            {
                movies.Add(movie);
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<Movie> all_movies_by(List<ProductionStudio> productionStudios)
        {
            foreach (Movie m in this.movies)
            {
                if (productionStudios.Contains(m.production_studio))
                {
                    yield return m;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return all_movies_by(new List<ProductionStudio> {ProductionStudio.Pixar});
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return all_movies_by(new List<ProductionStudio> { ProductionStudio.Pixar, ProductionStudio.Disney });
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (Movie m in this.movies)
            {
                if (m.production_studio != ProductionStudio.Pixar)
                {
                    yield return m;
                }
            }
        }

        public IEnumerable<Movie> all_movies_of_genre(Genre g)
        {
            foreach (Movie m in this.movies)
            {
                if (m.genre == g)
                {
                    yield return m;
                }
            }   
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return all_movies_published_between_years(year + 1, int.MaxValue);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (Movie m in this.movies)
            {
                if (m.date_published.Year >= startingYear && m.date_published.Year <= endingYear)
                {
                    yield return m;
                }
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return all_movies_of_genre(Genre.kids);
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return all_movies_of_genre(Genre.action);
        }


        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            throw new NotImplementedException();
        }
    }
}