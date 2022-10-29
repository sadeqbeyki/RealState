using AppFramework.Domain;
using RS.Application.Slide;

namespace RS.Domain.Entities.SlideAgg
{
    public interface ISlideRepository : IBaseRepository<long, Slide>
    {
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}
