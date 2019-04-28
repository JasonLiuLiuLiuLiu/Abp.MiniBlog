using Abp.MultiTenancy;
using Abp.MiniBlog.Authorization.Users;

namespace Abp.MiniBlog.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
