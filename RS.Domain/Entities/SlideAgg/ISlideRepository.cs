using AppFramework.Domain;
using ShopManagement.Application.Contracts.Slide;

namespace RS.Domain.Entities.SlideAgg
{
    public interface ISlideRepository : IBaseRepository<long, Slide>
    {
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}
