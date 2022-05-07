using AppDapper.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AppDapper.Service.User.Concrete
{
    public class UserService : IUserService
    {
        private readonly IDapper _config;

        public UserService(IDapper config)
        {
            _config = config;
        }

        public async Task<UserModel> Create(UserModel model)
        {
            var result = await _config.Create<UserModel>(@$"insert into Person(fullname, login, password, image_url) 
                         values('{model.FullName}', '{model.Login}', '{model.password}', '{model.ImageUrl}')", null, CommandType.Text);
            if (result is null)
            {
                return null;
            }

            return result;
        }

        public async Task<bool> Delete(int Id)
        {
            var result = await _config.Delete<bool>($@"delete from person where id = {Id}", null, CommandType.Text);
            if (result is false)
            {
                return false;
            }

            return true;
        }

        public async Task<UserModel> Get(int Id)
        {
            var result = await _config.Get<UserModel>($@"select * from person where id = {Id}", null, CommandType.Text);
            if (result is null)
            {
                return null;
            }

            return result;
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var result = await _config.GetAll<UserModel>("SELECT * FROM person;", null, CommandType.Text);
            if (result is null)
            {
                return null;
            }

            return result;
        }

        public async Task<UserModel> Update(int Id, [FromBody] UserModel model)
        {
            var result = await _config.Update<UserModel>($@"UPDATE person set fullname = '{model.FullName}', 
                                    login = '{model.Login}', password = '{model.password}', image_url = '{model.ImageUrl}'
                                    where id = {Id}", null, CommandType.Text);
            if (result is null)
            {
                return null;
            }

            return result;
        }
    }
}
