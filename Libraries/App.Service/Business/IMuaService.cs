using System.Collections.Generic;
using App.Core.Domain;
namespace App.Service.Business
{
    /// <summary>
    /// Interface IMuaService
    /// </summary>
    public interface IMuaService : ICommonService<Mua>
    {
        /// <summary>
        /// Gets mua by team.
        /// </summary>
        /// <param name="MaMua"> ma mua.</param>
        /// <returns>List&lt;Mua&gt;.</returns>
        List<Mua> GetMuaByTeam(string MaMua);
    }
}
