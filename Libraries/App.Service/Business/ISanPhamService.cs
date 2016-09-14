using System.Collections.Generic;
using App.Core.Domain;
namespace App.Service.Business
{
    /// <summary>
    /// Interface ISanPhamService
    /// </summary>
    public interface ISanPhamService : ICommonService<SanPham>
    {
        /// <summary>
        /// Gets ma giay dep by team.
        /// </summary>
        /// <param name="maChatLieu">ma giay dep.</param>
        /// <returns>List&lt;MaGiayDep&gt;.</returns>
        List<SanPham> GetSanPhamByTeam(string maGiayDep);
        string GetNewUrlImage(string urlold, string fileName, string NewForderUrl);
    }
}
