namespace NET1
{
    [Serializable]
    public class Actor : Person
    {

        private readonly int sizeInCentimeter;
        private List<Movie> movies;

        public int SizeInCentimeter
        {
            get { return sizeInCentimeter; }
        }


        public Actor(string name, string firstname, DateTime birthDate, int sizeInCentimeter):base(name, firstname, birthDate)
        {
            this.sizeInCentimeter = sizeInCentimeter;
            movies = new List<Movie>();
        }


    
        public override string ToString()
        {
            return "Actor [name = " + Name + " firstname = " + Firstname + " sizeInCentimeter = " + sizeInCentimeter + " birthdate = " + BirthDate + "]";
        }

        /**
	    * 
	    * @return list of movies in which the actor has played
	    */
        public IEnumerator<Movie> Movies()
        {
            return movies.GetEnumerator();
        }

        /**
	    * add movie to the list of movies in which the actor has played
	    * @param movie
	    * @return false if the movie is null or already present
	    */
        public bool AddMovie(Movie movie)
        {
            if ((movie == null) || movies.Contains(movie))
                return false;

            if (!movie.ContainsActor(this))
                movie.AddActor(this);

            movies.Add(movie);

            return true;
        }

        public bool ContainsMovie(Movie movie)
        {
            return movies.Contains(movie);
        }

        
        public override string Name
        {
            get { return  base.Name.ToUpper(); }
        }
    }
}
