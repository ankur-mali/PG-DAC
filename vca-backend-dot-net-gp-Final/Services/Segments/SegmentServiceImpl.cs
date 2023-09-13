using VCA.Models;
using VCA.Repositories;
namespace VCA.Services.Segments
{
    public class SegmentServiceImpl : ISegmentService
    {
        private readonly AppDbContext _context;// DI

        public SegmentServiceImpl(AppDbContext context)
        {
            _context = context;
        }


        public List<Segment> GetAllSegments()
        {
            return _context.Segments.ToList();
        }

    }
}
