using AutoMapper;
using HVACTopGun.DataAccess.Features.Tenants;
using HVACTopGun.Domain.Features.Tenants;
using HVACTopGun.Domain.Features.Users;


namespace HVACTopGun.Application.Features.Tenants
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;

        public TenantService(IMapper mapper, ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
        }

        public async Task<int?> GetTenantIdByObjectId(string objectId)
        {
            // Add any additional logic if needed
            return await _tenantRepository.GetTenantIdByObjectId(objectId);
        }

        public async Task<int> GetLastCreatedTenantId()
        {
            // Add any additional logic if needed
            return await _tenantRepository.GetLastCreatedTenantId();
        }

        public async Task<IEnumerable<TenantDto>> GetAllTenants()
        {
            var tenants = await _tenantRepository.GetAllTenants();
            return _mapper.Map<IEnumerable<TenantDto>>(tenants);
        }

        public async Task<TenantDto?> GetTenant(int id)
        {
            var tenantModel = await _tenantRepository.GetTenant(id);
            return _mapper.Map<TenantDto>(tenantModel);
        }

        public async Task<TenantDto?> GetTenantByBusinessName(string businessName)
        {
            var tenantModel = await _tenantRepository.GetTenantByBusinessName(businessName);
            return _mapper.Map<TenantDto>(tenantModel);
        }

        public async Task CreateTenant(TenantDto tenantDto)
        {
            var tenantModel = _mapper.Map<TenantModel>(tenantDto);
            // Add any business logic or validation before calling the repository
            await _tenantRepository.CreateTenant(tenantModel);
        }

        public async Task<UserModel?> GetUserById(int id)
        {
            // Add any additional logic if needed
            return await _tenantRepository.GetUserById(id);
        }

        public async Task DeleteTenant(int id)
        {
            // Add any business logic or validation before calling the repository
            await _tenantRepository.DeleteTenant(id);
        }
    }
}
