using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.ApplicationService
{
    public interface IUserService
    {
        UserMaster Authenticate(UserMaster userMaster);
        UserMaster GetUserByEmailID(string emailID);
        void Register(UserMaster userMaster);
        List<UserRole> GetRoles(IdentifiableData userId);
        ShoppingCart GetShoppingCart(IdentifiableData userId);
        List<ProductMaster> GetSubscribedProducts(IdentifiableData userId);
        UserProfile GetProfileDetails(IdentifiableData userId);
        List<String> GetAllExistingUserEmailIDs();
        List<String> GetAllMobileNumber();
        void UpdateProfile(UserProfile userProfile);
    }
}
