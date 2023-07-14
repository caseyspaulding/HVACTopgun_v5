
using AutoMapper;
using HVACTopGun.DataAccess.Features.Users;
using HVACTopGun.Domain.Features.Users;

namespace HVACTopGun.Application.Features.Users
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task CreateUser(UserDto userDto)
        {
            var userModel = _mapper.Map<UserModel>(userDto);
            await _userRepository.CreateUser(userModel);
        }

        public async Task<UserModel> GetUserByObjectId(string objectId)
        {
            var user = await _userRepository.GetUserByObjectId(objectId);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<int?> GetUserIdByObjectId(string azureObjectId)
        {
            // Add any additional logic if needed
            return await _userRepository.GetUserIdByObjectId(azureObjectId);
        }

        public async Task<UserDto?> GetUserById(int id)
        {
            var userModel = await _userRepository.GetUserById(id);
            return _mapper.Map<UserDto>(userModel);
        }

        public async Task UpdateUser(UserDto user)
        {
            // Add any business logic or validation before calling the repository
            var userModel = _mapper.Map<UserModel>(user);
            await _userRepository.UpdateUser(userModel);
        }

        public async Task DeleteUser(int id)
        {
            // Add any business logic or validation before calling the repository
            await _userRepository.DeleteUser(id);
        }
    }
}
