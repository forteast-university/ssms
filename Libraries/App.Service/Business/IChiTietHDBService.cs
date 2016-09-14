using System.Collections.Generic;
using App.Core.Domain;

namespace App.Service.Business
{
    /// <summary>
    /// Interface IChiTietHDBService
    /// </summary>
    public interface IChiTietHDBService : ICommonService<ChiTietHDB>
    {
        /// <summary>
        /// Gets chi tiet hoa don ban by team.
        /// </summary>
        /// <param name="SoHDB">The so hoa don ban.</param>
        /// <returns>List&lt;ChiTietHDB&gt;.</returns>
        List<ChiTietHDB> GetChiTietHDBByTeam(string SoHDN);
    }
}