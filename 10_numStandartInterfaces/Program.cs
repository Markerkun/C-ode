using System.Collections;

namespace _10_numStandartInterfaces
{
    enum genres
    {
        Action,
        Adventure,
        Comedy,
        Drama,
        Horror,
        SciFi
    }

    class Cinema : IEnumerable
    {
        Movie[] movies;
        string address;
        public Cinema(string address, Movie[] movies)
        {
            this.address = address;
            this.movies = movies;
        }
        public void Sort()
        {
            Array.Sort(movies);
        }
        public void Sort(IComparer<Movie> comparer)
        {
            Array.Sort(movies, comparer);
        }
        public IEnumerator<genres> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return movies.GetEnumerator();
        }
        public string ToString()
        {
            string result = $"Cinema at {address}:\n";
            foreach (var movie in movies)
            {
                result += movie.ToString() + "\n\n";
            }
            return result;
        }
    }
    class Movie : IComparable, ICloneable
    {
        public string Title { get; set; }
        public Director Director { get; set; }
        public string Description { get; set; }
        public genres Genre { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public short Rating { get; set; }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        string ToString()
        {
            return $"{Title} ({Year}) - {Genre}\n" +
                   $"Director: {Director.Name} {Director.Surname}, Age: {Director.Age}\n" +
                   $"Country: {Country}, Rating: {Rating}/10\n" +
                   $"{Description}";
        }
    }
    class CompareByRating : IComparer<Movie>
    {

        public int Compare(Movie? x, Movie? y)
        {
            if (x == null || y == null) return 0;
            return x.Rating.CompareTo(y.Rating);
        }

    }
    class CompareByYear : IComparer<Movie>
    {

        public int Compare(Movie? x, Movie? y)
        {
            if (x == null || y == null) return 0;
            return x.Year.CompareTo(y.Year);
        }

    }
    class Director
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Lastname { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
