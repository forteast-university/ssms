using System.Collections.Generic;
using App.Core.Domain;
namespace App.Service.Business
{
    /// <summary>
    /// Interface IKichCoService
    /// </summary>
    public interface IKhachHangService : ICommonService<KhachHang>
    {
        /// <summary>
        /// Gets  khach hang by team.
        /// </summary>
        /// <param name="MaKhach">ma khac.</param>
        /// <returns>List&lt;KhachHang&gt;.</returns>
        List<KhachHang> GetKhachHangByTeam(string MaKhach);
    }
}