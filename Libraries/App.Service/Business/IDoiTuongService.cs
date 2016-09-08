using System.Collections.Generic;
using App.Core.Domain;

namespace App.Service.Business
{
    /// <summary>
    /// Interface IDoiTuongService
    /// </summary>
    public interface IDoiTuongService : ICommonService<DoiTuong>
    {
        /// <summary>
        /// Gets doi tuong by team.
        /// </summary>
        /// <param name="MaDoiTuong">ma doi tuong.</param>
        /// <returns>List&lt;DoiTuong&gt;.</returns>
        List<DoiTuong> GetDoiTuongByTeam(string MaDoiTuong);
    }
}