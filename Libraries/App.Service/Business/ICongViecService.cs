using System.Collections.Generic;
using App.Core.Domain;

namespace App.Service.Business
{
    /// <summary>
    /// Interface ICongViecService
    /// </summary>
    public interface ICongViecService : ICommonService<CongViec>
    {
        /// <summary>
        /// Gets cong viec by team.
        /// </summary>
        /// <param name="MaCV"> ma cong viec.</param>
        /// <returns>List&lt;CongViec&gt;.</returns>
        List<CongViec> GetCongViecByTeam(string MaCV);
    }
}