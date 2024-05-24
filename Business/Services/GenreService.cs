using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public interface IGenreService
    {
        IQueryable<GenreModel> Query();
        Result Add(GenreModel model);
        Result Update(GenreModel model);
        Result Delete(int id);
    }
    public class GenreService : ServiceBase, IGenreService
    {
        public GenreService(Db db) : base(db)
        {
        }

        public IQueryable<GenreModel> Query()
        {
            return _db.Genres.Include(s=>s.Movies).OrderBy(s => s.GenreName).Select(s => new GenreModel
            {
                Id = s.Id,
                GenreName = s.GenreName,
                MovieCountOutput = s.Movies.Count,

                    MovieNamesOutput= string.Join("<br/>", s.Movies.OrderByDescending(m=>m.Price).ThenByDescending(m=>m.MovieName).Select(m=>m.MovieName))

            });
        }
        public Result Add(GenreModel model)
        {
            if (_db.Genres.Any(s=> s.GenreName.ToLower() == model.GenreName.ToLower().Trim()))
                return new ErrorResult("Genre with the same name exist!");

            Genre entity = new Genre()
            {
                GenreName = model.GenreName.Trim()
            };
            _db.Genres.Add(entity);
            _db.SaveChanges();
            return new SuccesResult("Genre is added succesfully!");
            
        }


        public Result Update(GenreModel model)
        {
            if (_db.Genres.Any(s => s.Id != model.Id && s.GenreName.ToLower() == model.GenreName.ToLower().Trim()))
                return new ErrorResult("Genre with the same name exist!");

            Genre entity = _db.Genres.Find(model.Id);

            if (entity is null)
                return new ErrorResult("Genre is not found!");

            entity.GenreName = model.GenreName.Trim();
            
            _db.Genres.Update(entity);
            _db.SaveChanges();
            return new SuccesResult("Genre is updated succesfully!");
        }

        public Result Delete(int id)
        {
            Genre entity = _db.Genres.Include(g=>g.Movies).SingleOrDefault(g => g.Id == id);
            if (entity is null)
                return new ErrorResult("Genre is not found");
            if (entity.Movies is not null && entity.Movies.Any())
                return new ErrorResult("Genre has relational movies, you can not delete it!");

            _db.Genres.Remove(entity);
            _db.SaveChanges();
            return new SuccesResult("Genre is deleted succesfully.");
        }

    }
}
