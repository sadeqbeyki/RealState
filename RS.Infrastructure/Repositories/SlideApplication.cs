﻿using AppFramework.Application;
using RS.Application.Slide;
using RS.Domain.Entities.SlideAgg;

namespace RS.Infrastructure.Repositories
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IFileUploader _fileUploader;

        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operation = new OperationResult();
            var pictureName = _fileUploader.Upload(command.Picture, "slides");
            var slide = new Slide(pictureName, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Title, command.Text, command.Link, command.BtnText);
            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(command.Id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var pictureName = _fileUploader.Upload(command.Picture, "slides");

            slide.Edit(pictureName, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Title, command.Text, command.Link, command.BtnText);
            _slideRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Remove();
            _slideRepository.SaveChanges();
            return operation.Succeeded();

        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Restore();
            _slideRepository.SaveChanges();
            return operation.Succeeded();
        }
    }
}
