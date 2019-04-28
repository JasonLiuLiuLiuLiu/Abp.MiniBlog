using System.Collections.Generic;
using Abp.MiniBlog.Roles.Dto;

namespace Abp.MiniBlog.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}