using AppFramework.Application;

namespace RS.Contracts.Slides;

public interface ISlideApplication
{
    OperationResult Create(CreateSlide command);
    OperationResult Edit(EditSlide command);
    OperationResult Remove(long id);
    OperationResult Restore(long id);
    EditSlide GetDetails(long id);
    List<SlideViewModel> GetList();
}
