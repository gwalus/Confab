using Confab.Modules.Conferences.Core.Entities;
using System.Threading.Tasks;

namespace Confab.Modules.Conferences.Core.Policies
{
    internal interface IHostDeletionPolicy
    {
        Task<bool> CanDeleteAsync(Host host);
    }
}
