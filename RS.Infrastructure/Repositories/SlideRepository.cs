using AppFramework.Application;
using AppFramework.Infrastructure;
using RS.Contracts.Slides;
using RS.Domain.Entities.SlideAgg;
using System.Collections.Generic;
using System.Linq;

namespace RS.Infrastructure.Repositories;

public class SlideRepository : BaseRepository<long, Slide>, ISlideRepository
{
    private readonly RealStateContext _context;

    public SlideRepository(RealStateContext context) : base(context)
    {
        _context = context;
    }

    public EditSlide GetDetails(long id)
    {
        return _context.Slides.Select(s => new EditSlide
        {
            Id = id,
            PictureAlt = s.PictureAlt,
            PictureTitle = s.PictureTitle,
            Heading = s.Heading,
            Title = s.Title,
            Text = s.Text,
            Link = s.Link,
            BtnText = s.BtnText
        }).FirstOrDefault(x => x.Id == id);
    }

    public List<SlideViewModel> GetList()
    {
        return _context.Slides.Select(x => new SlideViewModel
        {
            Id = x.Id,
            Picture = x.Picture,
            Heading = x.Heading,
            Title = x.Title,
            IsRemoved = x.IsRemoved,
            CreationDate = x.CreationDate.ToFarsi()
        }).OrderByDescending(x => x.Id).ToList();
    }
}
