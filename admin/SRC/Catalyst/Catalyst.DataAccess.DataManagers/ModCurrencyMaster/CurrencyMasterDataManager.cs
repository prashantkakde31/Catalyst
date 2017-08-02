using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.DataAccess.DataManagers.ModCurrencyMaster
{
    public class CurrencyMasterDataManager
    {
        public DataTable GetCurrencyList()
        {
            try
            {
                return DBOperate.GetDataTable("usp_GetAllCurrency");
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetCurrencyListWithID(int ID)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                        new SqlParameter("@CurrencyID",ID)
                };
                return DBOperate.GetDataTable("usp_GetCurrencyById", parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}
