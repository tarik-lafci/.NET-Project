using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
	public interface IMovieService
	{
		IQueryable<MovieModel> Query();
	}
	public class MovieService : ServiceBase, IMovieService
	{
		public MovieService(Db db) : base(db)
		{
		}

		public IQueryable<MovieModel> Query()
		{
			return _db.Movies.Include(o => o.MovieActors).Include(o => o.Genre).OrderBy(m => m.MovieName)
				.Select(m => new MovieModel()
			{
				Id = m.Id,
				Price = m.Price,
				IsReleased = m.IsReleased,
				ReleaseDate = m.ReleaseDate,
				GenreId = m.GenreId,
				StudioId = m.StudioId,
				MovieName = m.MovieName
				
			});
		}
	}
}
