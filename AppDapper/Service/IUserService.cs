using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDapper.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUsers();

        Task<UserModel> Get(int Id);

        Task<UserModel> Create(UserModel model);

        Task<bool> Delete(int Id);

        Task<UserModel> Update(int Id, UserModel model);
    }
}
