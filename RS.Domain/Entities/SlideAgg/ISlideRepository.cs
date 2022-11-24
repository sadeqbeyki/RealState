using AppFramework.Domain;
using RS.Contracts.Slides;

namespace RS.Domain.Entities.SlideAgg
{
    public interface ISlideRepository : IBaseRepository<long, Slide>
    {
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}
