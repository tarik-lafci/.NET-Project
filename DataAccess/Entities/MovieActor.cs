#nullable disable
using DataAccess.Records.Bases;

namespace DataAccess.Entities
{
    public class MovieActor : RecordBase
    {
        public int  MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }


    }
}
