using SAPbobsCOM;

namespace AddDocumentSbo.Models
{
    public class ConnectionSbo
    {
        public ConnectionSbo(
            string server,
            string companyDB,
            string dbUserName,
            string dbPassword,
            BoDataServerTypes dbServerType,
            string userName,
            string password)
        {
            Server = server;
            CompanyDB = companyDB;
            DbUserName = dbUserName;
            DbPassword = dbPassword;
            DbServerType = dbServerType;
            UserName = userName;
            Password = password;
        }

        public string Server { get; set; }
        public string CompanyDB { get; set; }
        public string DbUserName { get; set; }
        public string DbPassword { get; set; }
        public BoDataServerTypes DbServerType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
