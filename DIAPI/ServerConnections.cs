using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DIAPI
{
    
    class ServerConnections
    {
        //declaration of the privtes
        private SAPbobsCOM.Company company = new SAPbobsCOM.Company();
        private int connectionResult;
        private int errorCode = 0;
        private string errorMessage = "";

        public int Connect() 
        {
            //pass the stored settings from app.config to a local variable
            company.Server = ConfigurationManager.AppSettings["server"].ToString();
            company.CompanyDB = ConfigurationManager.AppSettings["companydb"].ToString();
            company.DbUserName = ConfigurationManager.AppSettings["dbuser"].ToString();
            company.DbUserName = ConfigurationManager.AppSettings["dbpass"].ToString();
            //change this variable to your enviromen( sql 2012 - 2016)
            company.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            company.UserName = ConfigurationManager.AppSettings["user"].ToString();
            company.Password = ConfigurationManager.AppSettings["password"].ToString();
            //choose the languge of your sap install (this must match!)
            company.language = SAPbobsCOM.BoSuppLangs.ln_Dutch;
            //true = if ssl is enable and not self signed !
            company.UseTrusted = false;
            company.LicenseServer = ConfigurationManager.AppSettings["licenseserver"].ToString();

            connectionResult = company.Connect();
            if (connectionResult != 0) 
            {
                //connection has failed !
                company.GetLastError(out errorCode, out errorMessage);
            }
            return connectionResult;
        }
        public SAPbobsCOM.Company GetCompany() 
        {
            return this.company;
        }
        public int GetErrorCode() 
        {
            return this.errorCode;
        }
        public string GetErrorMessage() 
        {
            return this.errorMessage;
        }

    }
}
