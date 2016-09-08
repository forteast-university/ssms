using System.Collections.Generic;
using App.Core.Domain;

namespace App.Service.Business
{
    /// <summary>
    /// Interface IChiTietHDNService
    /// </summary>
    public interface IChiTietHDNService : ICommonService<ChiTietHDN>
    {
        /// <summary>
        /// Gets chi tiet hoa don nhap by team.
        /// </summary>
        /// <param name="SoHDN">so hoa don nhap.</param>
        /// <returns>List&lt;ChiTietHDN&gt;.</returns>
        List<ChiTietHDN> GetChiTietHDNByTeam(string SoHDN);
    }
}