using Microsoft.EntityFrameworkCore;
using Lessons.Api.Infrastructure.Data;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Infrastructure.Repositories
{
    public class AlternativesRepository: BaseRepository<Alternative>, IAlternativesRepository 
    {
        public AlternativesRepository(LessonsApiContext context) : base(context) {}
    }
}