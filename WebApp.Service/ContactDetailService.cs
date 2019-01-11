using WebApp.Data.Infrastructure;
using WebApp.Data.Repositories;
using WebApp.Model.Models;

namespace WebApp.Service
{
	public interface IContactDetailService
	{
		ContactDetail GetDefaultContact();
	}

	public class ContactDetailService : IContactDetailService
	{
		private IContactDetailRepository _contactDetailRepository;
		private IUnitOfWork _unitOfWork;

		public ContactDetailService(IContactDetailRepository contactDetailRepository, IUnitOfWork unitOfWork)
		{
			this._contactDetailRepository = contactDetailRepository;
			this._unitOfWork = unitOfWork;
		}

		public ContactDetail GetDefaultContact()
		{
			return _contactDetailRepository.GetSingleByCondition(x => x.Status);
		}
	}
}