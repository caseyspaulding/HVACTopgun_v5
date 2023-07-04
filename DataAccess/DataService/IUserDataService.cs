﻿using DataAccess.Models;

namespace DataAccess.DataService
{
    public interface IUserDataService
    {
        Task CreateUser(UserModel user);
        Task DeleteUser(int id);
        Task<UserModel?> GetUserById(int id);
        Task<UserModel?> GetUserByObjectId(string azureObjectId);
        Task UpdateUser(UserModel user);
    }
}