using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.RegisterContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Application.RegisterContext
{
    public interface IRegisterService
    {
        Task<bool> insertNewUser(User user);
        bool verifyUserExistence(Register newRegister);
        Task<bool> insertNewCredentials(Credentials credentials);
        Task<bool> insertNewEmailConfirmation(EmailConfirmation emailConfirmation);
        Task<bool> insertNewPhone(Phones phone);
        string getMailBody(string hasEmail, int TypeUser);
        Task<string> sendEmail(Mail mailClass);
        string encryptPassword(string password);
        byte[] encryptStringToBytes_Aes(string password, byte[] Key, byte[] IV);
        string getSalt();
        string hashEmail(string email);
        Task<IList<Category>> getCategoryParents();
        Task<IList<Category>> getChildrenOfCategory(int id);
        Task<EmailConfirmation> getEmailConfirmation(string hash_code);
        Task<bool> getUserConfirmationEmail(string email);
        bool verifyExpirationDate(EmailConfirmation email);
        Task<IList<District>> listDistricts();
        Task<IList<Canton>> listCantons();
        Task<IList<Province>> listProvinces();
        Task<IList<Category>> listCategories();
        Task<bool> updateUser(User user);
        Task<bool> insertNewMember(Members members);
        Task<bool> insertNewClient(Client client);
        Task<bool> insertNewShoppingCart(ShoppingCart shoppingcart);
        Task<bool> insertNewLike(Likes like);
        Task<bool> insertNewEntrepreneur(Entrepreneur entrepreneur);
        Task<bool> insertNewAdministrator(Administrator administrator);
        IList<Canton> getListCantonsByProvince(string province);
        IList<District> getListDistrictsByCanton(string canton);
        Task<bool> addNewActiveAdministrator(ActiveAdministrators activeAdministrator);
        bool AddLikes(Likes l);
        Task<bool> verifyPastAdminRegister(string email);
        bool verifyUserTypes(string email, int userType);
        EmailConfirmation getEmailConfirmationByEmail(string email);
        Task<string> getUserPassword(string email);
        Task<bool> verifyMembersExistence(string email);
    }
}