using System.Collections.Generic;
using App.Core.Domain;
namespace App.Service.Business
{
    /// <summary>
    /// Interface ITheLoaiService
    /// </summary>
    public interface ITheLoaiService : ICommonService<TheLoai>
    {
        /// <summary>
        /// Gets loai by team.
        /// </summary>
        /// <param name="maLoai"> ma loai.</param>
        /// <returns>List&lt;TheLoai&gt;.</returns>
        List<TheLoai> GetTheLoaiByTeam(string maLoai);
    }
}
