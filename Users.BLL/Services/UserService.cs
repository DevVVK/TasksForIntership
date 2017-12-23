﻿using System;
using System.Collections.Generic;
using Users.BLL.BusinessModels.Security;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using Users.BLL.MapBuilders.UnitOfWork;
using UsersDAL.Repositories.UnitOfWorks;

namespace Users.BLL.Services
{
    public class UserService : IUsersService, IDisposable
    {
        private UnitOfWork _dataBase;

        private UnitOfWorkMapper _mapper;

        public UserService()
        {
            _dataBase = new UnitOfWork();
            _mapper = new UnitOfWorkMapper();
        }

#region CRUD users
        
        public void AddUser(UserDto user)
        {
            var addUser = _mapper.MapUser.GetMapOne(user);

            using (var md5Hasher = new EncriptionPasswordProvider(addUser.Password))
            {
                addUser.Password = md5Hasher.GetHashPassword();
            }

            _dataBase.Users.Add(addUser);
        }

        public List<UserDto> GetAllUsers()
        {
            var users = _dataBase.Users.GetAll();

            return _mapper.MapUserDto.GetMapList(users);
        }

        public UserDto GetUserOne(int id)
        {
            var user = _dataBase.Users.GetOne(id);

            return _mapper.MapUserDto.GetMapOne(user);
        }

        public void UpdateUser(UserDto user)
        {
            var updateUser = _mapper.MapUser.GetMapOne(user);

            _dataBase.Users.Update(updateUser);
        }

        public void DeleteUser(UserDto user)
        {
            var deleteUser = _mapper.MapUser.GetMapOne(user);

            _dataBase.Users.Delete(deleteUser);
        }

        #endregion

        public void Dispose()
        {
            _dataBase?.Dispose();
        }
    }
}