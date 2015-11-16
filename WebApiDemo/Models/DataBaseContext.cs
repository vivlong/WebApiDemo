using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApiDemo.Models
{
    public class DataBaseContext : DbContext
    {
        private static string strSecretKey;
        #region DES
        //private string DESKey = "F322186F";
        //private string DESIV = "F322186F";
        private static string DESEncrypt(string strPlain, string strDESKey, string strDESIV)
        {
            string DESEncrypt = "";
            try
            {
                byte[] bytesDESKey = ASCIIEncoding.ASCII.GetBytes(strDESKey);
                byte[] bytesDESIV = ASCIIEncoding.ASCII.GetBytes(strDESIV);
                byte[] inputByteArray = Encoding.Default.GetBytes(strPlain);
                DESCryptoServiceProvider desEncrypt = new DESCryptoServiceProvider();
                desEncrypt.Key = bytesDESKey;
                desEncrypt.IV = bytesDESIV;
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, desEncrypt.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(inputByteArray, 0, inputByteArray.Length);
                        csEncrypt.FlushFinalBlock();
                        StringBuilder str = new StringBuilder();
                        foreach (byte b in msEncrypt.ToArray())
                        {
                            str.AppendFormat("{0:X2}", b);
                        }
                        DESEncrypt = str.ToString();
                    }
                }
            }
            catch
            { }
            return DESEncrypt;
        }
        private static string DesDecrypt(string strValue)
        {
            string DesDecrypt = "";
            if (string.IsNullOrEmpty(strValue))
            {
                return DesDecrypt;
            }
            try
            {
                byte[] DESKey = new byte[] { 70, 51, 50, 50, 49, 56, 54, 70 };
                byte[] DESIV = new byte[] { 70, 51, 50, 50, 49, 56, 54, 70 };
                DES desprovider = new DESCryptoServiceProvider();
                byte[] inputByteArray = new byte[strValue.Length / 2];
                int intI;
                for (intI = 0; intI < strValue.Length / 2; intI++)
                {
                    inputByteArray[intI] = (byte)(Convert.ToInt32(strValue.Substring(intI * 2, 2), 16));
                }
                desprovider.Key = DESKey;
                desprovider.IV = DESIV;
                using (MemoryStream ms = new MemoryStream())
                {
                    CryptoStream cs = new CryptoStream(ms, desprovider.CreateDecryptor(), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    DesDecrypt = Encoding.Default.GetString(ms.ToArray());
                }
            }
            catch
            { throw; }
            return DesDecrypt;
        }
        #endregion
        private static string GetConnectionString()
        {
            string IniConnection = "";
            string strAppSetting = "";
            string[] strDataBase = new string[3];
            if (string.IsNullOrEmpty(strAppSetting))
            {
                strAppSetting = System.Configuration.ConfigurationManager.AppSettings["DataBase"];
                strSecretKey = System.Configuration.ConfigurationManager.AppSettings["SecretKey"];
                strDataBase = strAppSetting.Split(',');
                int intCnt;
                for (intCnt = 0; intCnt <= strDataBase.Length - 1; intCnt++)
                {
                    strAppSetting = System.Configuration.ConfigurationManager.AppSettings[strDataBase[intCnt]];
                    string[] strDatabaseInfo;
                    strDatabaseInfo = strAppSetting.Split(',');
                    if (strDatabaseInfo.Length == 6)
                    {
                        IniConnection = System.Configuration.ConfigurationManager.AppSettings[strDatabaseInfo[5]];
                        string strConnection = "";
                        strConnection = IniConnection.Replace("#DataSource", strDatabaseInfo[0]);
                        strConnection = strConnection.Replace("#Catalog", strDatabaseInfo[1]);
                        strConnection = strConnection.Replace("#UserName", strDatabaseInfo[2]);
                        strConnection = strConnection.Replace("#Password", DesDecrypt(strDatabaseInfo[3]));
                        return strConnection;
                    }
                }
            }
            return "";
        }
        public DataBaseContext()
                : base(GetConnectionString())
        {
        }

        public DbSet<Rcbp1> DtRcbp1 { get; set; }
        public DbSet<Jmjm6> DtJmjm6 { get; set; }
    }
}