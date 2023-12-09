using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetByMail(string email)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            throw new NotImplementedException();
        }
    }
}
