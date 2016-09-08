using System.Collections.Generic;
using App.Core.Domain;
namespace App.Service.Business
{
    /// <summary>
    /// Interface IKichCoService
    /// </summary>
    public interface IKichCoService : ICommonService<KichCo>
    {
        /// <summary>
        /// Gets kich co by team.
        /// </summary>
        /// <param name="MaCo">ma co.</param>
        /// <returns>List&lt;KichCo&gt;.</returns>
        List<KichCo> GetKichCoByTeam(string MaCo);
    }
}
