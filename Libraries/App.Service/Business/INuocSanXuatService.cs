using System.Collections.Generic;
using App.Core.Domain;
namespace App.Service.Business
{
    /// <summary>
    /// Interface INuocSanXuatService
    /// </summary>
    public interface INuocSanXuatService : ICommonService<NuocSanXuat>
    {
        /// <summary>
        /// Gets nuoc san xuat by team.
        /// </summary>
        /// <param name="MaNuocSX">Ma Nuoc San Xuat.</param>
        /// <returns>List&lt;NuocSanXuat&gt;.</returns>
        List<NuocSanXuat> GetNuocSanXuatByTeam(string MaNuocSX);
    }
}
