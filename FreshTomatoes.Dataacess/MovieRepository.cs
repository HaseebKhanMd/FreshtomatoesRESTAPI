using FreshTomatoes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshTomatoes.DataAccess
{
    public class MovieRepository : IMovieRepository
    {
        /* Makes use of InMemory Data. 
         * This class can get data from Database using ADO.Net, EF or any other ORM tool
         */ 
         
        private List<Movie> movies = new List<Movie>();
        private static object syncRoot = new object();
        private static volatile MovieRepository instance = null;

        public static MovieRepository Instance
        {
            get 
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MovieRepository();
                        }
                    }
                }
                return instance;
            }
        
        }

        private MovieRepository()
        {
            movies = new List<Movie>()
	                    {
	                        new Movie(){ Id = 1, 
                                         Name = "Avengers - Age of Ultron", 
                                         URL = @"http://resizing.flixster.com/s8kIQtOhr36lGPkcUGCVeqVWw9Y=/180x270/dkpu1ddg7pbsk.cloudfront.net/movie/11/19/01/11190143_ori.jpg", 
                                         Rating = 4.5,
                                         Description = "When Tony Stark jumpstarts a dormant peacekeeping program, things go awry and Earth's Mightiest Heroes, including Iron Man, Captain America, Thor, The Incredible Hulk, Black Widow and Hawkeye, are put to the ultimate test as they battle to save the planet from destruction at the hands of the villainous Ultron."
                                         },
                            new Movie(){ Id = 2, 
                                         Name = "Furious 7", 
                                         URL = @"http://resizing.flixster.com/tBSZ6CjTf-YkvC4o-VC0JFIY-vk=/170x270/dkpu1ddg7pbsk.cloudfront.net/movie/11/18/14/11181482_ori.jpg", 
                                         Rating = 4.0,
                                         Description = "Continuing the global exploits in the unstoppable franchise built on speed, Vin Diesel, Paul Walker and Dwayne Johnson lead the returning cast of Fast & Furious 7. James Wan directs this chapter of the hugely successful series that also welcomes back favorites Michelle Rodriguez, Jordana Brewster, Tyrese Gibson, Chris Ludacris Bridges, Elsa Pataky and Lucas Black. They are joined by international action stars new to the franchise including Jason Statham, Djimon Hounsou, Tony Jaa, Ronda Rousey and Kurt Russell."
                                         },
                            new Movie(){ Id = 3, 
                                         Name = "Tomorrowland", 
                                         URL = @"http://resizing.flixster.com/dH2TEhqdJ5A6xxV3mQBPZ_1yEac=/180x267/dkpu1ddg7pbsk.cloudfront.net/movie/11/19/06/11190666_ori.jpg", 
                                         Rating = 3.5,
                                         Description = "From Disney comes two-time Oscar (R) winner Brad Bird's riveting, mystery adventure Tomorrowland, starring Academy Award (R) winner George Clooney. Bound by a shared destiny, former boy-genius Frank (Clooney), jaded by disillusionment, and Casey (Britt Robertson), a bright, optimistic teen bursting with scientific curiosity, embark on a danger-filled mission to unearth the secrets of an enigmatic place somewhere in time and space known only as Tomorrowland. What they must do there changes the world-and them-forever. Featuring a screenplay by Lost writer and co-creator Damon Lindelof and Brad Bird, from a story by Lindelof & Bird & Jeff Jensen, Tomorrowland promises to take audiences on a thrill ride of nonstop adventures through new dimensions that have only been dreamed of.(C) Walt Disney"
                                         },
                            new Movie(){ Id = 4, 
                                         Name = "Pitch Perfect 2", 
                                         URL = @"http://resizing.flixster.com/CSaptdyboc7JUz266OumNJHeAl4=/180x257/dkpu1ddg7pbsk.cloudfront.net/movie/11/19/12/11191224_ori.jpg", 
                                         Rating = 3.0,
                                         Description = "Surprise hit Pitch Perfect gets sequelized in this Universal Pictures production once again scripted by Kay Cannon. ~ Jeremy Wheeler, Rovi"
                                         },	    
                            new Movie(){ Id = 5, 
                                         Name = "Mad Max: Fury Road", 
                                         URL = @"http://resizing.flixster.com/GbDqFVUc_9VBNAnanZVQxlYD0ZM=/180x267/dkpu1ddg7pbsk.cloudfront.net/movie/11/19/12/11191276_ori.jpg", 
                                         Rating = 4.0,
                                         Description = "Filmmaker George Miller gears up for another post-apocalyptic action adventure with Fury Road, the fourth outing in the Mad Max film series. Charlize Theron stars alongside Tom Hardy (Bronson), with Zoe Kravitz, Adelaide Clemens, and Rosie Huntington Whiteley heading up the supporting cast. ~ Jeremy Wheeler, Rovi"
                                         },	
                            new Movie(){ Id = 6, 
                                         Name = "Far From The Madding Crowd", 
                                         URL = @"http://resizing.flixster.com/c8g2_ZQY4dBR7lxc9zWgzQnA01U=/180x267/dkpu1ddg7pbsk.cloudfront.net/movie/11/19/09/11190928_ori.jpg", 
                                         Rating = 4.5,
                                         Description = "Based on the literary classic by Thomas Hardy, FAR FROM THE MADDING CROWD is the story of independent, beautiful and headstrong Bathsheba Everdene (Carey Mulligan), who attracts three very different suitors: Gabriel Oak (Matthias Schoenaerts), a sheep farmer, captivated by her fetching willfulness; Frank Troy (Tom Sturridge), a handsome and reckless Sergeant; and William Boldwood (Michael Sheen), a prosperous and mature bachelor. This timeless story of Bathsheba's choices and passions explores the nature of relationships and love - as well as the human ability to overcome hardships through resilience and perseverance. (C) Fox Searchlight"
                                         },	
                           new Movie(){ Id = 7, 
                                         Name = "The Imitation Game", 
                                         URL = @"http://resizing.flixster.com/G1oUSsU3x1Cbl6g4VoYEDMeOn7M=/180x266/dkpu1ddg7pbsk.cloudfront.net/movie/11/18/08/11180871_ori.jpg", 
                                         Rating = 2.5,
                                         Description = "During the winter of 1952, British authorities entered the home of mathematician, cryptanalyst and war hero Alan Turing (Benedict Cumberbatch) to investigate a reported burglary. They instead ended up arresting Turing himself on charges of 'gross indecency', an accusation that would lead to his devastating conviction for the criminal offense of homosexuality - little did officials know, they were actually incriminating the pioneer of modern-day computing. Famously leading a motley group of scholars, linguists, chess champions and intelligence officers, he was credited with cracking the so-called unbreakable codes of Germany's World War II Enigma machine. An intense and haunting portrayal of a brilliant, complicated man, THE IMITATION GAME follows a genius who under nail-biting pressure helped to shorten the war and, in turn, save thousands of lives. (c) Weinstein"
                                         },	

                           new Movie(){ Id = 8, 
                                         Name = "American Snipper", 
                                         URL = @"http://resizing.flixster.com/uH63Fj4OSyQcFquEIV0NuCQVW88=/180x267/dkpu1ddg7pbsk.cloudfront.net/movie/11/18/08/11180834_ori.jpg", 
                                         Rating = 3.5,
                                         Description = "From director Clint Eastwood comes American Sniper, starring Bradley Cooper as Chris Kyle, the most lethal sniper in U.S. military history. But there was much more to this true American hero than his skill with a rifle. U.S. Navy SEAL sniper Chris Kyle is sent to Iraq with only one mission: to protect his brothers-in-arms. His pinpoint accuracy saves countless lives on the battlefield and, as stories of his courageous exploits spread, he earns the nickname Legend. However, his reputation is also growing behind enemy lines, putting a price on his head and making him a prime target of insurgents. Despite the danger, as well as the toll on his family at home, Chris serves through four harrowing tours of duty in Iraq, becoming emblematic of the SEAL creed to leave no man behind. But upon returning home, Chris finds that it is the war he can't leave behind. (C) Warner Bros"
                                         },	

                            new Movie(){ Id = 9, 
                                         Name = "Ant Man", 
                                         URL = @"http://resizing.flixster.com/2v4J8EokFyspSZWdr5pL9jT7BH8=/180x267/dkpu1ddg7pbsk.cloudfront.net/movie/11/19/12/11191270_ori.png", 
                                         Rating = 4.0,
                                         Description = "The next evolution of the Marvel Cinematic Universe brings a founding member of The Avengers to the big screen for the first time with Marvel Studios' Ant-Man. Armed with the astonishing ability to shrink in scale but increase in strength, master thief Scott Lang must embrace his inner-hero and help his mentor, Dr. Hank Pym, protect the secret behind his spectacular Ant-Man suit from a new generation of towering threats. Against seemingly insurmountable obstacles, Pym and Lang must plan and pull off a heist that will save the world. -- (C) Marvel"
                                         },	

                             new Movie(){ Id = 10, 
                                         Name = "Kingsman: The Secret Service", 
                                         URL = @"http://resizing.flixster.com/JioZvKjI2nmMxMn00QVpoY4qbd8=/180x267/dkpu1ddg7pbsk.cloudfront.net/movie/11/18/95/11189501_ori.jpg", 
                                         Rating = 4.5,
                                         Description = "Based upon the acclaimed comic book and directed by Matthew Vaughn (Kick Ass, X-Men First Class), Kingsman: The Secret Service tells the story of a super-secret spy organization that recruits an unrefined but promising street kid into the agency's ultra-competitive training program just as a global threat emerges from a twisted tech genius. (c) Fox"
                                         },	
	                    };


        }

        public List<Movie> GetAllMovies()
        {          
            return movies;     
        }

    
        public List<Movie> GetAllMoviesCustom(int pageIndex, int pageSize)
        {
            return movies.Skip(pageIndex * pageSize).Take(pageSize).ToList();        
        }

        public Movie GetMovie(int id)
        {
            return movies.FirstOrDefault<Movie>(p => p.Id == id);
        }

        public bool AddMovie(Movie movie)
        {
            // TODO // Add validation for Unique contrainst etc.
            try
            {
                movie.Id = GetId();
                movies.Add(movie);
            }
            catch (Exception)
            { 
                // Log your exception here
                // throw exception based on exception policy
                //ExceptionHandler.HandlerException(ex, ExceptionHandler.Policy.DataAccess);
                return false;
            }
            return true;
        }

        public bool UpdateMovie(Movie movie)
        {
            try
            {
                int index = movies.FindIndex(p => p.Id == movie.Id);
                if (index == -1)
                {
                    return false;
                }
                movies.RemoveAt(index);
                movies.Add(movie);
            }
            catch (Exception)
            {
                // Log your exception here
                // throw exception based on exception policy
                return false;
            }
            return true;
        }

        public bool DeleteMovie(int id)
        {
            try
            {
                movies.RemoveAll(p => p.Id == id);
            }
            catch (Exception)
            {
                // Log your exception here
                // throw exception based on exception policy
                return false;
            }
            return true;
        }

        private int GetId()
        {
            return movies.Max(p => p.Id) + 1;
        }


       
    }
}
