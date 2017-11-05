using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;
using Interpidians.Catalyst.Core.DomainService;

namespace Interpidians.Catalyst.Core.ApplicationService
{
    public class UserService : IUserService
    {
        private IUserMasterRepository UserMasterRepository { get; set; }
        private IUserRoleRepository UserRoleRepository { get; set; }
        private IUserProfileRepository UserProfileRepository { get; set; }
        private IShoppingCartRepository ShoppingCartRepository { get; set; }
        private ICartItemRepository CartItemRepository { get; set; }

        public UserService(IUserMasterRepository userMasterRepository, 
            IUserRoleRepository userRoleRepository,
            IUserProfileRepository userProfileRepository,
            IShoppingCartRepository shoppingCartRepository,
            ICartItemRepository cartItemRepository)
        {
            this.UserMasterRepository = userMasterRepository;
            this.UserRoleRepository = UserRoleRepository;
            this.UserProfileRepository = UserProfileRepository;
            this.ShoppingCartRepository = shoppingCartRepository;
            this.CartItemRepository = cartItemRepository;
        }

        public UserMaster Authenticate(UserMaster authUser)
        {
            UserMaster userDetails=UserMasterRepository.GetAll().Where(user => ((user.EmailID.ToUpper() == authUser.EmailID.ToUpper()) || (user.MobileNumber.ToUpper() == authUser.MobileNumber.ToUpper()) || (user.UserName.ToUpper() == authUser.UserName.ToUpper()))).FirstOrDefault();

            //Validate user
            if (userDetails != null && authUser.Password.Equals(userDetails.Password) && userDetails.AccountStatus.Equals("ACTIVE"))
            {
                return userDetails;
            }
            else {
                return null;
            }
        }

        public UserProfile GetProfileDetails(IdentifiableData userId)
        {
            throw new NotImplementedException();
        }

        public List<UserRole> GetRoles(IdentifiableData userId)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart GetShoppingCart(IdentifiableData userId)
        {
            throw new NotImplementedException();
        }

        public List<ProductMaster> GetSubscribedProducts(IdentifiableData userId)
        {
            throw new NotImplementedException();
        }

        public void Register(UserMaster userMaster)
        {
            UserMasterRepository.Add(userMaster);
        }

        public void UpdateProfile(UserProfile userProfile)
        {
            throw new NotImplementedException();
        }

        public List<String> GetAllExistingUserEmailIDs()
        {
            return UserMasterRepository.GetAll().Select(user=>user.EmailID.ToUpper()).ToList();
        }

        public List<String> GetAllMobileNumber()
        {
            return UserMasterRepository.GetAll().Select(user => user.MobileNumber.ToUpper()).ToList();
        }

        public UserMaster GetUserByEmailID(string emailID)
        {
            return UserMasterRepository.GetAll().Where(user => user.EmailID.ToUpper().Equals(emailID?.ToUpper())).FirstOrDefault();
        }
    }
}
