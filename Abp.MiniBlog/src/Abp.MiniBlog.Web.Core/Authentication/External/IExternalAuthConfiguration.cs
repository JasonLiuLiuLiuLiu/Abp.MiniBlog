using System.Collections.Generic;

namespace Abp.MiniBlog.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
