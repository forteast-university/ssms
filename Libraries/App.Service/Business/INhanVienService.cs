using System.Collections.Generic;
using App.Core.Domain;
namespace App.Service.Business
{
    /// <summary>
    /// Interface INhanVienService
    /// </summary>
    public interface INhanVienService : ICommonService<NhanVien>
    {
        /// <summary>
        /// Gets nhan vien by team.
        /// </summary>
        /// <param name="MaNhanVien">ma nhan vien.</param>
        /// <returns>List&lt;NhanVien&gt;.</returns>
        List<NhanVien> GetNhanVienByTeam(string MaNhanVien);
    }
}
