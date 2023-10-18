using Dapper;
using SLH.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SLH.Service.Common
{
    public class Helper
    {
        public static IDbConnection GetSqlConnection()
        {
            return new SqlConnection(AppSettings.SqlConnectionString);
        }


        public static void GetData<T>(ref ApiResult<T> result, ref DynamicParameters parameters, string procedureName)
            where T : class
        {
            BaseHelper.AddResultOutputParams(ref parameters);

            using (IDbConnection con = Helper.GetSqlConnection())
            {
                var task = con.QueryMultiple(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!task.IsConsumed)
                    result.Item = task.Read<T>().FirstOrDefault();
            }

            BaseHelper.SetResultParams(ref result, ref parameters);
        }

        public static void GetListData<T>(ref ApiResult<List<T>> result, ref DynamicParameters parameters, string procedureName)
            where T : class
        {
            BaseHelper.AddResultOutputParams(ref parameters);

            using (IDbConnection con = Helper.GetSqlConnection())
            {
                var task = con.QueryMultiple(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (!task.IsConsumed)
                    result.Item = task.Read<T>().ToList();
            }

            BaseHelper.SetResultParams(ref result, ref parameters);
        }

        /// <summary>
        /// Encrypts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// Encrypted string
        /// </returns>
        public static string Encrypt(string input)
        {
            string key = AppSettings.EncyptionKey;
            byte[] inputArray = Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// Decrypts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// decrypted string
        /// </returns>
        public static string Decrypt(string input)
        {
            string key = AppSettings.EncyptionKey;
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static double GetActualTimeStamp()
        {
            var st = new DateTime(1970, 1, 1);
            TimeSpan t = DateTime.Now.ToUniversalTime() - st;
            double totalSeconds = t.TotalSeconds;
            return totalSeconds;
        }
    }
}
