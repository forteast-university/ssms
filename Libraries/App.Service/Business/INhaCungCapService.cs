using System.Collections.Generic;
using App.Core.Domain;
namespace App.Service.Business
{
    /// <summary>
    /// Interface INhaCungCapService
    /// </summary>
    public interface INhaCungCapService : ICommonService<NhaCungCap>
    {
        /// <summary>
        /// Gets nha cung cap by team.
        /// </summary>
        /// <param name="MaNCC">ma nha cung cap.</param>
        /// <returns>List&lt;NhaCungCap&gt;.</returns>
        List<NhaCungCap> GetNhaCungCapByTeam(string MaNCC);
    }
}
