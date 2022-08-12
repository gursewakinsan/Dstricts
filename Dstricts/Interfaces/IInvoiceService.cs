using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dstricts.Interfaces
{
    public interface IInvoiceService
    {
        Task<Models.TenantInvoiceInfoResponse> TenantInvoiceInfoAsync(Models.TenantInvoiceInfoRequest request);
    }
}
