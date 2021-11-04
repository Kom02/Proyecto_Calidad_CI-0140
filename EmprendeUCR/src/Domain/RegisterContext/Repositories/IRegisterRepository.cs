using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.RegisterContext.Entities;
using System.Collections.Generic;

namespace EmprendeUCR.Domain.RegisterContext.Repositories
{
    public interface IRegisterRepository : IRepository<Register>
    {
        Task<bool> addUserAsync(User user);
        bool verifyUserRecord(Register newRegister);
        Task<bool> addCredentialsAsync(Credentials credentials);
        Task<bool> addPhoneAsync(Phones phones);
        Task<bool> addEmailConfirmationAsync(EmailConfirmation emailConfirmation);
        Task<IList<Category>> getParents();
        Task<IList<Category>> getChildrenOf(int parentId);
        Task<EmailConfirmation> getConfirmationEmail(string hash_code);
        Task<bool> getUserConfirmEmail(string email);
        Task<IList<District>> getAllDistricts();
        Task<IList<Canton>> getAllCantons();
        Task<IList<Province>> getAllProvinces();
        Task<IList<Category>> getAllCategories();
        Task<bool> updateUserAsync(User user);
        Task<bool> addMembersAsync(Members members);
        Task<bool> addClientAsync(Client client);
        Task<bool> addShoppingCartAsync(ShoppingCart shoppingCart);
        Task<bool> addLikesAsync(Likes likes);
        Task<bool> addEntrepreneurAsync(Entrepreneur entrepreneur);
        Task<bool> addAdministratorAsync(Administrator administrator);
        IList<Canton> getListCantons(string province);
        IList<District> getListDistrics(string canton);
        Task<bool> addActiveAdministrator(ActiveAdministrators activeAdministrator);
        bool AddMemberLikes(Likes l);
        Task<bool> verifyPastAdmin(string email);
        bool verifyUserType(string email, int userType);
        EmailConfirmation getEmailConfirmation(string email);
        Task<string> GetPassword(string email);
        Task<bool> verifyMembers(string email);
    }
}
