using Abp.AutoMapper;
using BabyMemory_V2.Authentication.External;

namespace BabyMemory_V2.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
