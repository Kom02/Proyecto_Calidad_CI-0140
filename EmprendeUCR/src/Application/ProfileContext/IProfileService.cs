using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.Reports.Entities;

namespace EmprendeUCR.Application.ProfileContext
{
    public interface IProfileService
    {
        Task<User> GetUser(string email);
        Task<IList<Entrepreneur>> GetUsers();
        Task<Members> GetMember(string email);
        Task<Client> GetClient(string email);
        Task<Entrepreneur> GetEntrepreneur(string email);
        Task<Administrator> GetAdministrator(string email);
        Task<IList<Likes>> GetLikes(string email);
        Task<Phones> GetPhone(string email);
        string GetCategoryTitle(int categoryId);
        IList<Category> GetParentCategories();
        IList<Category> GetCategoryChildren(int parentId);
        IList<Category> GetCategories();
        IList<Province> GetProvinces();
        IList<Canton> GetCantons(string province);
        IList<District> GetDistricts(string canton);
        Task<bool> UpdatePhone(string email, string phone);
        Task<bool> UpdateUser(User u);
        Task<bool> UpdateAdministrator(Administrator a);
        Task<bool> UpdateMember(Members m);
        Task<bool> UpdateClient(Client c);
        Task<bool> UpdateEntrepreneur(Entrepreneur e);
        Task<bool> AddLikes(Likes l);
        Task<bool> RemoveLikes(Likes l);
        Task<bool> AddReport(Report r);
    }
}
