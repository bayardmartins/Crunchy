using Microsoft.EntityFrameworkCore;
using Lessons.Api.Infrastructure.Data;
using Lessons.Api.Interfaces;

namespace Lessons.Api.Infrastructure.Repositories
{
    public class LessonsRepository: BaseRepository<Lesson>, ILessonsRepository
    {
        public LessonsRepository(LessonsApiContext context): base(context) {}
    }
}