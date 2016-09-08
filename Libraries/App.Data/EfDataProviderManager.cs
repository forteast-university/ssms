using System;
using App.Core;
using App.Core.Data;
//using Nop.Core;

namespace App.Data
{
    //todo remove
    public partial class EfDataProviderManager : BaseDataProviderManager
    {
        public EfDataProviderManager(DataSettings settings):base(settings)
        {
        }

        public override IDataProvider LoadDataProvider()
        {
            var providerName = Settings.DataProvider;
            if (String.IsNullOrWhiteSpace(providerName))
                throw new AppException("Data Settings doesn't contain a providerName");
            switch (providerName.ToLowerInvariant())
            {
                case "sqlserver":
                    return new SqlServerDataProvider();
                case "sqlce":
                    return new SqlCeDataProvider();
                default:
                    throw new AppException(string.Format("Not supported dataprovider name: {0}", providerName));
            }
        }
    }
}
