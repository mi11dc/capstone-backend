using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Common
{
    public class BaseHelper
    {
        public static void AddResultOutputParams(ref DynamicParameters parameters)
        {
            parameters.Add(BaseSqlConstant.CODE, dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add(BaseSqlConstant.MESSAGE, dbType: DbType.String, direction: ParameterDirection.Output, size: BaseSqlConstant.VARCHARMAXSIZE);
        }

        public static void SetResultParams<T>(ref ApiResult<T> result, ref DynamicParameters parameters)
            where T : class
        {
            result.SetCode(GetSqlParamValue<int>(BaseSqlConstant.CODE, parameters));
            result.Message = GetSqlParamValue<string>(BaseSqlConstant.MESSAGE, parameters);
        }
        public static T GetSqlParamValue<T>(string parameterName, DynamicParameters parameters)
        {
            return parameters.Get<T>(parameterName);
        }

        public static string GetCurrentDirectoryPath()
        {
            return System.IO.Directory.GetCurrentDirectory();
        }

        public static void AddPageParams(BaseSearchEntity searchEnity, ref DynamicParameters parameters)
        {
            parameters.Add(BaseSqlConstant.OFFSET, searchEnity.GetOffset(), dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add(BaseSqlConstant.LIMIT, searchEnity.GetLimit(), dbType: DbType.Int32, direction: ParameterDirection.Input);
        }

        public static string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)
        {
            string sOTP = String.Empty;
            Random rand = new Random();
            for (int i = 0; i < iOTPLength; i++)
            {
                string sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];
                sOTP += sTempChars;
            }
            return sOTP;
        }
    }
}
