using System.Collections.Generic;
using App.Core.Domain;
namespace App.Service.Business
{
    /// <summary>
    /// Interface IMauService
    /// </summary>
    public interface IMauService : ICommonService<Mau>
    {
        /// <summary>
        /// Gets  mau by team.
        /// </summary>
        /// <param name="MaMau">ma mau.</param>
        /// <returns>List&lt;Mau&gt;.</returns>
        List<Mau> GetMauByTeam(string MaMau);
    }
}
