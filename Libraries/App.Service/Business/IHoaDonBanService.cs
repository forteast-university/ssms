using System.Collections.Generic;
using App.Core.Domain;

namespace App.Service.Business
{
    /// <summary>
    /// Interface IHoaDonBanService
    /// </summary>
    public interface IHoaDonBanService : ICommonService<HoaDonBan>
    {
        /// <summary>
        /// Gets hoa don ban by team.
        /// </summary>
        /// <param name="SoHDB">so hoa don ban.</param>
        /// <returns>List&lt;HoaDonBan&gt;.</returns>
        List<HoaDonBan> GetChiTietHDBByTeam(string SoHDB);
    }
}