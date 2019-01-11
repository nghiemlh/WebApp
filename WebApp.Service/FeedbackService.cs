using WebApp.Data.Infrastructure;
using WebApp.Data.Repositories;
using WebApp.Model.Models;

namespace WebApp.Service
{
	public interface IFeedbackService
	{
		Feedback Create(Feedback feedback);

		void Save();
	}

	public class FeedbackService : IFeedbackService
	{
		private IFeedbackRepository _feedbackRepository;
		private IUnitOfWork _unitOfWork;

		public FeedbackService(IFeedbackRepository feedbackRepository, IUnitOfWork unitOfWork)
		{
			_feedbackRepository = feedbackRepository;
			_unitOfWork = unitOfWork;
		}

		public Feedback Create(Feedback feedback)
		{
			return _feedbackRepository.Add(feedback);
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}
	}
}