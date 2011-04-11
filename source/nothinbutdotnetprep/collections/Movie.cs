using System;

namespace nothinbutdotnetprep.collections
{
    public class Movie
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public bool Equals(Movie movie)
        {
            return (string.IsNullOrEmpty(this.title) || string.IsNullOrEmpty(movie.title)) ? base.Equals(movie) : title.Equals(movie.title);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Movie);
        }
    }
}