using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;

namespace BLL.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FeedbackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FeedbackModel> AddASync(FeedbackModel model)
        {
            var entity = _mapper.Map<Feedback>(model);
            var addedEntity = await _unitOfWork.FeedbackRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var addedModel = _mapper.Map<FeedbackModel>(addedEntity);
            return addedModel;
        }
    }
}
