using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using WebApplication1.Models;

namespace CinemaManagement
{
    class Worker
    {
        protected const string API_URL = "http://localhost:49146";
        public List<Showing> getShowings()
        {
            List<Showing> result = new List<Showing>();
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/showings";
            rClient.endPoint = api_url;
            string strResponse = string.Empty;
            strResponse = rClient.makeRequest();

            using JsonDocument doc = JsonDocument.Parse(strResponse);
            JsonElement root = doc.RootElement;
            var showings = root.EnumerateArray();
            while (showings.MoveNext())
            {
                var showing = showings.Current;
                Showing show = new Showing(showing.GetProperty("id").GetInt32(),
                                           showing.GetProperty("time").GetInt32(),
                                           showing.GetProperty("hall_id").GetInt32(),
                                           showing.GetProperty("movie_id").GetInt32());
                result.Add(show);
            }
            return result;
        }

        public List<Movie> getMovies()
        {
            List<Movie> result = new List<Movie>();
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/movies";
            rClient.endPoint = api_url;
            string strResponse = string.Empty;
            strResponse = rClient.makeRequest();

            using JsonDocument doc = JsonDocument.Parse(strResponse);
            JsonElement root = doc.RootElement;
            var movies = root.EnumerateArray();
            while (movies.MoveNext())
            {
                var movie = movies.Current;
                Movie mv = new Movie(movie.GetProperty("id").GetInt32(),
                                     movie.GetProperty("name").ToString(),
                                     movie.GetProperty("duration").GetInt32());
                result.Add(mv);
            }
            return result;
        }

        public List<Hall> getHalls()
        {
            List<Hall> result = new List<Hall>();
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/halls";
            rClient.endPoint = api_url;
            string strResponse = string.Empty;
            strResponse = rClient.makeRequest();

            using JsonDocument doc = JsonDocument.Parse(strResponse);
            JsonElement root = doc.RootElement;
            var halls = root.EnumerateArray();
            while (halls.MoveNext())
            {
                var hall = halls.Current;
                Hall hl = new Hall(hall.GetProperty("id").GetInt32(),
                                           hall.GetProperty("columns_count").GetInt32(),
                                           hall.GetProperty("rows_count").GetInt32());
                result.Add(hl);
            }
            return result;
        }

        public object getObjectWithId(string type, int id)
        {
            Object result = "UNKNOWN TYPE";
            switch (type)
            {
                case "reservations":
                    var loRes = generateDetailedReservationsList();
                    foreach (DetailedReservation res in loRes)
                    {
                        if (res.Reservation.ReservationId == id) result = res.Reservation;
                    }
                    if (result.ToString() == "UNKNOWN TYPE") result = "CANNOT FIND OBJECT WITH THIS ID";
                    break;

                case "halls":
                    var loHls = generateDetailedHallsList();
                    foreach (DetailedHall hl in loHls)
                    {
                        if (hl.Hall.HallId == id) result = hl.Hall;
                    }
                    if (result.ToString() == "UNKNOWN TYPE") result = "CANNOT FIND OBJECT WITH THIS ID";
                    break;

                case "movies":
                    var loMv = generateDetailedMoviesList();
                    foreach (DetailedMovie mv in loMv)
                    {
                        if (mv.Movie.MovieId == id) result = mv.Movie;
                    }
                    if (result.ToString() == "UNKNOWN TYPE") result = "CANNOT FIND OBJECT WITH THIS ID";
                    break;

                case "showing":
                    var loShow = generateDetailedShowingsList();
                    foreach (DetailedShowing show in loShow)
                    {
                        if (show.Show.ShowingId == id) result = show.Show;
                    }
                    if (result.ToString() == "UNKNOWN TYPE") result = "CANNOT FIND OBJECT WITH THIS ID";
                    break;

                default:
                    break;
            }
            return result;
        }

        public User getUserWithUsername(string usrn, bool isWr)
        {
            User result = new User();
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/customers";
            if (isWr) api_url = API_URL + "/api/workers";
            api_url += "/" + usrn;
            rClient.endPoint = api_url;
            string strResponse = string.Empty;
            strResponse = rClient.makeRequest();

            using JsonDocument doc = JsonDocument.Parse(strResponse);
            JsonElement root = doc.RootElement;
            var users = root.EnumerateArray();
            while (users.MoveNext())
            {
                var user = users.Current;
                result = new User(user.GetProperty("id").GetInt32(),
                                           user.GetProperty("first_name").ToString(),
                                           user.GetProperty("last_name").ToString(),
                                           user.GetProperty("login").ToString(),
                                           user.GetProperty("password").ToString());
                
            }
            return result;
        }

        public List<Reservation> getReservations()
        {
            List<Reservation> result = new List<Reservation>();
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/reservations";
            rClient.endPoint = api_url;
            string strResponse = string.Empty;
            strResponse = rClient.makeRequest();

            using JsonDocument doc = JsonDocument.Parse(strResponse);
            JsonElement root = doc.RootElement;
            var reservations = root.EnumerateArray();
            while (reservations.MoveNext())
            {
                var reservation = reservations.Current;
                Reservation res = new Reservation(reservation.GetProperty("id").GetInt32(),
                                           reservation.GetProperty("showing_id").GetInt32(),
                                           reservation.GetProperty("column_id").GetInt32(),
                                           reservation.GetProperty("row_id").GetInt32(),
                                           reservation.GetProperty("customer_id").GetInt32(),
                                           reservation.GetProperty("created_at").GetInt32());
                result.Add(res);
            }
            return result;
        }

        public List<User> getCustomers()
        {
            List<User> result = new List<User>();
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/customers";
            rClient.endPoint = api_url;
            string strResponse = string.Empty;
            strResponse = rClient.makeRequest();

            using JsonDocument doc = JsonDocument.Parse(strResponse);
            JsonElement root = doc.RootElement;
            var users = root.EnumerateArray();
            while (users.MoveNext())
            {
                var user = users.Current;
                User hl = new User(user.GetProperty("id").GetInt32(),
                                           user.GetProperty("first_name").ToString(),
                                           user.GetProperty("last_name").ToString(),
                                           user.GetProperty("login").ToString(),
                                           user.GetProperty("password").ToString());
                result.Add(hl);
            }
            return result;
        }

        public List<DetailedShowing> generateDetailedShowingsList()
        {
            List<DetailedShowing> result = new List<DetailedShowing>();
            List<Showing> loShowings = getShowings();
            List<Movie> loMovies = getMovies();
            foreach (var show in loShowings)
            {
                foreach (var movie in loMovies)
                {
                    if (movie.MovieId == show.MovieId)
                    {
                        result.Add(new DetailedShowing(show, movie.Name));
                    }
                }
            }
            return result;
        }

        public List<DetailedHall> generateDetailedHallsList()
        {
            List<DetailedHall> result = new List<DetailedHall>();
            List<Hall> loHalls = getHalls();
            foreach (var hall in loHalls)
            {
                result.Add(new DetailedHall(hall));
            }
            return result;
        }

        public List<DetailedMovie> generateDetailedMoviesList()
        {
            List<DetailedMovie> result = new List<DetailedMovie>();
            List<Movie> loMovies = getMovies();
            foreach (var mv in loMovies)
            {
                result.Add(new DetailedMovie(mv));
            }
            return result;
        }

        public List<DetailedReservation> generateDetailedReservationsList()
        {
            List<DetailedReservation> result = new List<DetailedReservation>();
            List<Reservation> loReservations = getReservations();
            List<Movie> loMovies = getMovies();
            List<Showing> loShowings = getShowings();
            List<User> loCustomers = getCustomers();
            foreach (var res in loReservations)
            {
                foreach (var mv in loMovies)
                {
                    foreach (var show in loShowings)
                    {
                        foreach (var usr in loCustomers)
                        {
                            if (res.ShowingId == show.ShowingId &&
                                res.CustomerId == usr.UserId &&
                                show.MovieId == mv.MovieId)
                            {
                                result.Add(new DetailedReservation(res, usr, mv, show));
                            }
                        }
                    }
                }
            }
            return result;
        }

        public string putShowing(Showing show)
        {
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/showings";
            rClient.endPoint = api_url;
            rClient.httpMethod = httpVerb.PUT;
            string strResponse = string.Empty;
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"Time", show.Time},
                {"HallId", show.HallId},
                {"MovieId",  show.MovieId},
                {"ShowingId",  show.ShowingId}
            };
            strResponse = rClient.makePost(postData);
            return strResponse;
        }
        public string putHall(Hall hl)
        {
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/halls";
            rClient.endPoint = api_url;
            rClient.httpMethod = httpVerb.PUT;
            string strResponse = string.Empty;
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"HallId", hl.HallId},
                {"ColumnsCount", hl.ColumsCount},
                {"RowsCount",  hl.RowsCount}
            };
            strResponse = rClient.makePost(postData);
            return strResponse;
        }
        public string putMovie(Movie mv)
        {
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/movies";
            rClient.endPoint = api_url;
            rClient.httpMethod = httpVerb.PUT;
            string strResponse = string.Empty;
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"Name", mv.Name},
                {"Duration", mv.Duration},
                {"MovieId",  mv.MovieId}
            };
            strResponse = rClient.makePost(postData);
            return strResponse;
        }
        public string putReservation(Reservation res)
        {
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/reservations";
            rClient.endPoint = api_url;
            rClient.httpMethod = httpVerb.PUT;
            string strResponse = string.Empty;
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"ReservationId", res.ReservationId},
                {"ShowingId", res.ShowingId},
                {"ColumnId",  res.ColumnId},
                {"RowId",  res.RowId},
                {"CustomerId",  res.CustomerId},
                {"CreatedAt",  res.CreatedAt}
            };
            strResponse = rClient.makePost(postData);
            return strResponse;
        }

        public string postShowing(Showing show)
        {
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/showings";
            rClient.endPoint = api_url;
            rClient.httpMethod = httpVerb.POST;
            string strResponse = string.Empty;
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"ShowingId",  show.ShowingId},
                {"Time",  show.Time},
                {"HallId",  show.HallId},
                {"MovieId",  show.MovieId}
            };
            strResponse = rClient.makePost(postData);
            return strResponse;
        }
        public string postHall(Hall hl)
        {
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/halls";
            rClient.endPoint = api_url;
            rClient.httpMethod = httpVerb.POST;
            string strResponse = string.Empty;
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"HallId",  hl.HallId},
                {"ColumnsCount",  hl.ColumsCount},
                {"RowsCount",  hl.RowsCount}
            };
            strResponse = rClient.makePost(postData);
            return strResponse;
        }
        public string postMovie(Movie mv)
        {
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/movies";
            rClient.endPoint = api_url;
            rClient.httpMethod = httpVerb.POST;
            string strResponse = string.Empty;
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"Name",  mv.Name},
                {"Duration",  mv.Duration}
            };
            strResponse = rClient.makePost(postData);
            return strResponse;
        }
        public string postReservation(Reservation res)
        {
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/reservations";
            rClient.endPoint = api_url;
            rClient.httpMethod = httpVerb.POST;
            string strResponse = string.Empty;
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"ColumnId",  res.ColumnId},
                {"RowId",  res.RowId},
                {"CustomerId",  res.CustomerId},
                {"CreatedAt",  res.CreatedAt},
                {"ShowingId", res.ShowingId}
            };
            strResponse = rClient.makePost(postData);
            return strResponse;
        }

        public string deleteObjectWithId(string type, int id)
        {
            RestClient rClient = new RestClient();
            string api_url = API_URL + "/api/" + type + "/" + id;
            rClient.endPoint = api_url;
            rClient.httpMethod = httpVerb.DELETE;
            string strResponse = string.Empty;
            strResponse = rClient.makeRequest();

            return strResponse;
        }

    }
}
