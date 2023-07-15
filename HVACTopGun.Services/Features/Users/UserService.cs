using AutoMapper;
using HVACTopGun.DataAccess.Features.Tenants;
using HVACTopGun.DataAccess.Features.Users;
using HVACTopGun.Domain.Features.Tenants;
using HVACTopGun.Domain.Features.Users;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
namespace HVACTopGun.Services.Features.Users;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public UserService(ITenantRepository tenantRepository, IUserRepository userRepository, AuthenticationStateProvider authenticationStateProvider, IMapper mapper)
    {
        _tenantRepository = tenantRepository;
        _userRepository = userRepository;
        _authenticationStateProvider = authenticationStateProvider;
        this._mapper = mapper;
    }

    public async Task CreateUserAndTenant()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        var azureAD_ObjectID = user.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
        var userName = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        var businessName = user.Claims.FirstOrDefault(c => c.Type == "businessName")?.Value;

        if (azureAD_ObjectID == null || userName == null || businessName == null)
        {
            throw new Exception("Unable to retrieve necessary claim values for user creation");
        }

        var userExists = await _userRepository.UserExists(azureAD_ObjectID);

        if (!userExists)
        {
            // Insert Tenant parameters
            var tenantModel = new TenantModel
            {
                FirstName = "First Name",
                LastName = "Last Name",
                CompanyName = businessName,
                Domain = "Domain",
                Email = "Email",
                PhoneNumber = "Phone Number",
                Address = "Address",
                City = "City",
                State = "State",
                ZipCode = "Zipcode",
                TimeZone = "TimeZone",
                SubscriptionType = "1",

            };
            await _tenantRepository.CreateTenant(tenantModel);
            var tenantId = await _tenantRepository.GetLastCreatedTenantId();

            // User insert parameters
            var userModel = new UserModel
            {
                TenantID = tenantId,
                AzureAD_ObjectID = azureAD_ObjectID,
                Email = "Email",
                FirstName = "First Name",
                LastName = "Last Name",
                PhoneNumber = "Phone Number",
                Role = "Role",
                UserName = userName,
            };

            await _userRepository.CreateUser(userModel);
        }
    }

    public async Task CreateUser(UserDto user)
    {
        var userModel = _mapper.Map<UserModel>(user);
        await _userRepository.CreateUser(userModel);
    }

    public async Task<UserModel> GetUserByObjectId(string objectId)
    {
        return await _userRepository.GetUserByObjectId(objectId);
    }

    public async Task<int?> GetUserIdByObjectId(string azureObjectId)
    {
        return await _userRepository.GetUserIdByObjectId(azureObjectId);
    }

    public async Task<UserDto?> GetUserById(int id)
    {
        var userModel = await _userRepository.GetUserById(id);
        return _mapper.Map<UserDto>(userModel);
    }

    public async Task<UserDto> UpdateUser(UserDto userDto)
    {
        var userModel = _mapper.Map<UserModel>(userDto);
        await _userRepository.UpdateUser(userModel);

        // Retrieve the updated user from the repository
        var updatedUserModel = await _userRepository.GetUserById(userModel.UserId);

        return _mapper.Map<UserDto>(updatedUserModel);
    }

    public async Task<bool> UserExists(string azureAD_ObjectID)
    {
        return await _userRepository.UserExists(azureAD_ObjectID);
    }

    public async Task DeleteUser(int id)
    {
        await _userRepository.DeleteUser(id);
    }


}

