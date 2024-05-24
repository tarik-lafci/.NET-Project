using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Business.Services
{
    public interface IActorService
    {
        IQueryable<ActorModel> Query();
        Result Add(ActorModel model);
        Result Update(ActorModel model);
        Result Delete(int id);
        List<ActorModel> GetList();
        ActorModel GetItem(int id);

    }
    public class ActorService : ServiceBase, IActorService
    {
        public ActorService(Db db_) : base(db_)
        {
        }

        public IQueryable<ActorModel> Query()
        {
            return _db.Actors.Include(o => o.MovieActors).ThenInclude(mv => mv.Movie)
                .OrderByDescending(a => a.IsActive).ThenBy(a => a.BirthDate).ThenBy(a => a.Name).ThenBy(a => a.Surname)
                .Select(a => new ActorModel()
                {
                    BirthDate = a.BirthDate,
                    Id = a.Id,
                    IsActive = a.IsActive,
                    Name = a.Name,
                    Surname = a.Surname,
                    Score = a.Score,

                    BirthDateOutput = a.BirthDate.HasValue ? a.BirthDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                    IsActiveOutput = a.IsActive ? "Active" : "Not Active",
                    ScoreOutput = a.Score.ToString("N1"),
                    FullNameOutput = a.Name + " " + a.Surname,

                    MovieIdsInput = a.MovieActors.Select(ma => ma.MovieId).ToList(), //to edit
                    MovieNamesOutput = string.Join("<br />", a.MovieActors.Select(ma => ma.Movie.MovieName))


                });
        }
        public Result Add(ActorModel model)
        {
			if (_db.Actors.Any(a => a.Name.ToLower() == model.Name.ToLower().Trim() && a.Surname.ToLower() == model.Surname.ToLower().Trim()))
				return new ErrorResult("Actor with same name and surname exists!");
			var entity = new Actor()
			{
				BirthDate = model.BirthDate,
				IsActive = model.IsActive,
				Name = model.Name.Trim(),
				Score = model.Score ?? 0,
				Surname = model.Surname.Trim(),
				MovieActors = model.MovieIdsInput?.Select(movieId => new MovieActor()
				{
					MovieId = movieId
				}).ToList()
			};
			_db.Actors.Add(entity);
			_db.SaveChanges();
            model.Id = entity.Id;
			return new SuccesResult("Actor added successfuly.");
		}

        public Result Update(ActorModel model)
        {
            if (_db.Actors.Any(a => a.Id != model.Id && a.Name.ToLower() == model.Name.ToLower().Trim() && a.Surname.ToLower() == model.Surname.ToLower().Trim()))
				return new ErrorResult("Actor with same name and surname exists!");
            var entity = _db.Actors.Include(a => a.MovieActors).SingleOrDefault(a => a.Id == model.Id);
            if (entity is null)
				return new ErrorResult("Actor not found!");

            _db.MovieActors.RemoveRange(entity.MovieActors);
            entity.BirthDate = model.BirthDate;
            entity.IsActive = model.IsActive;
            entity.Name = model.Name.Trim();
            entity.Score = model.Score ?? 0;
            entity.Surname = model.Surname.Trim();
            entity.MovieActors = model.MovieIdsInput?.Select(movieId => new MovieActor()
            {
                MovieId = movieId
            }).ToList();

            _db.Actors.Update(entity);
            _db.SaveChanges();
			return new SuccesResult("Actor updated successfuly.");

		}

		public Result Delete(int id)
        {
            var entity = _db.Actors.Include(a => a.MovieActors).SingleOrDefault(a=> a.Id == id);
            if (entity is null)
                return new ErrorResult("Actor not found!");
            _db.MovieActors.RemoveRange(entity.MovieActors);
            _db.Actors.Remove(entity);
            _db.SaveChanges();
            return new SuccesResult("Actor deleted successfuly.");

        }

        public List<ActorModel> GetList()
        {
            return Query().ToList();
        }

        public ActorModel GetItem(int id)
        {
            return Query().SingleOrDefault(a => a.Id == id);
        }
    }
}