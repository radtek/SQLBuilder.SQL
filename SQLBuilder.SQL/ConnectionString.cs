using System;
using System.Collections.Generic;

namespace SQLBuilder.SQL {
    /// <summary>
    /// Connection String Class
    /// </summary>
    public class ConnectionString {
        #region Public Properties
        /// <summary>
        /// The network address of an instance of SQL Server in the organization. For more information about valid address syntax, see the description of the Address ODBC keyword, later in this topic.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The string identifying the application.
        /// </summary>
        public string APP { get; set; }

        /// <summary>
        /// Declares the application workload type when connecting to a server. Possible values are ReadOnly and ReadWrite. The default is ReadWrite. For more information about SQL Server Native Client's support for Always On Availability Groups, see SQL Server Native Client Support for High Availability, Disaster Recovery.
        /// </summary>
        public ApplicationIntents? ApplicationIntent { get; set; }

        /// <summary>
        /// The string identifying the application.
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// The name of the primary file (include the full path name) of an attachable database. To use AttachDBFileName, you must also specify the database name with the provider string Database keyword. If the database was previously attached, SQL Server does not reattach it (it uses the attached database as the default for the connection).
        /// </summary>
        public string AttachDBFileName { get; set; }

        /// <summary>
        /// Configures OEM/ANSI character translation. Recognized values are "true" and "false".
        /// </summary>
        public bool? AutoTranslate { get; set; }

        /// <summary>
        /// The amount of time (in seconds) to wait for data source initialization to complete.
        /// </summary>
        public int? ConnectTimeout { get; set; }

        /// <summary>
        /// The SQL Server language name.
        /// </summary>
        public string CurrentLanguage { get; set; }

        /// <summary>
        /// The database name.
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// The name of an instance of SQL Server in the organization. When not specified, a connection is made to the default instance on the local computer. For more information about valid address syntax, see the description of the Server ODBC keyword, later in this topic.
        /// </summary>
        public string DataSource { get; set; }

        /// <summary>
        /// Specifies the mode of data type handling to use. Recognized values are "0" for provider data types and "80" for SQL Server 2000 data types.
        /// </summary>
        public int? DataTypeCompatibility { get; set; }

        /// <summary>
        /// Specifies whether data should be encrypted before sending it over the network. Possible values are "yes" and "no". The default value is "no".
        /// </summary>
        public bool? Encrypt { get; set; }

        /// <summary>
        /// The name of the failover server used for database mirroring.
        /// </summary>
        public string FailoverPartner { get; set; }

        /// <summary>
        /// The SPN for the failover partner. The default value is an empty string. An empty string causes SQL Server Native Client to use the default, provider-generated SPN.
        /// </summary>
        public string FailoverPartnerSPN { get; set; }

        /// <summary>
        /// The database name.
        /// </summary>
        public string InitialCatalog { get; set; }

        /// <summary>
        /// The name of the primary file (include the full path name) of an attachable database. To use AttachDBFileName, you must also specify the database name with the provider string DATABASE keyword. If the database was previously attached, SQL Server does not reattach it (it uses the attached database as the default for the connection).
        /// </summary>
        public string InitialFileName { get; set; }

        /// <summary>
        /// Accepts the value "SSPI" for Windows Authentication.
        /// </summary>
        public bool? IntegratedSecurity { get; set; }

        /// <summary>
        /// The SQL Server language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Enables or disables multiple active result sets (MARS) on the connection if the server is SQL Server 2005 or later. Possible values are "yes" and "no". The default value is "no".
        /// </summary>
        public bool? MarsConn { get; set; }

        /// <summary>
        /// Enables or disables multiple active result sets (MARS) on the connection. Recognized values are "true" and "false". The default is "false".
        /// </summary>
        public bool? MARSConnection { get; set; }

        /// <summary>
        /// The network library used to establish a connection to an instance of SQL Server in the organization.
        /// </summary>
        public string Network { get; set; }

        /// <summary>
        /// The network address of an instance of SQL Server in the organization. For more information about valid address syntax, see the description of the Address ODBC keyword, later in this topic.
        /// </summary>
        public string NetworkAddress { get; set; }

        /// <summary>
        /// The network library used to establish a connection to an instance of SQL Server in the organization.
        /// </summary>
        public string NetworkLibrary { get; set; }

        /// <summary>
        /// Network packet size. The default is 4096.
        /// </summary>
        public int? PacketSize { get; set; }

        /// <summary>
        /// The SQL Server login password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Accepts the strings "true" and "false" as values. When "false", the data source object is not allowed to persist sensitive authentication information
        /// </summary>
        public bool? PersistSecurityInfo { get; set; }

        /// <summary>
        /// Accepts the strings "yes" and "no" as values. When "no", the data source object is not allowed to persist sensitive authentication information
        /// </summary>
        public bool? PersistSensitive { get; set; }

        /// <summary>
        /// For SQL Server Native Client, this should be "SQLNCLI11".
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// The SQL Server login password.
        /// </summary>
        public string PWD { get; set; }

        /// <summary>
        /// The name of an instance of SQL Server in the organization. When not specified, a connection is made to the default instance on the local computer. For more information about valid address syntax, see the description of the Server ODBC keyword, in this topic.
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// The SPN for the server. The default value is an empty string. An empty string causes SQL Server Native Client to use the default, provider-generated SPN.
        /// </summary>
        public string ServerSPN { get; set; }

        /// <summary>
        /// The amount of time (in seconds) to wait for data source initialization to complete.
        /// </summary>
        public int? Timeout { get; set; }

        /// <summary>
        /// When "yes", instructs the SQL Server Native Client OLE DB provider to use Windows Authentication Mode for login validation. Otherwise instructs the SQL Server Native Client OLE DB provider to use a SQL Server username and password for login validation, and the UID and PWD keywords must be specified.
        /// </summary>
        public bool? TrustedConnection { get; set; }

        /// <summary>
        /// Accepts the strings "yes" and "no" as values. The default value is "no", which means that the server certificate will be validated.
        /// </summary>
        public bool? TrustServerCertificate { get; set; }

        /// <summary>
        /// The SQL Server login name.
        /// </summary>
        public string UID { get; set; }

        /// <summary>
        /// Specifies whether data should be encrypted before sending it over the network. Possible values are "true" and "false". The default value is "false".
        /// </summary>
        public bool? UseEncryptionforData { get; set; }

        /// <summary>
        /// The SQL Server login name.
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// The workstation identifier.
        /// </summary>
        public string WorkstationID { get; set; }

        /// <summary>
        /// The workstation identifier.
        /// </summary>
        public string WSID { get; set; }
        #endregion

        #region Public Override Method
        /// <summary>
        /// Generates the connection string.
        /// </summary>
        /// <returns>The connection string.</returns>
        public override string ToString() {
            List<string> lstConnections = new List<string>();
            if (!this.Address.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("Address={0}", this.Address)); }
            if (!this.APP.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("APP={0}", this.APP)); }
            if (this.ApplicationIntent.HasValue) {
                switch (this.ApplicationIntent.Value) {
                    case ApplicationIntents.ReadOnly:
                        lstConnections.Add("ReadOnly");
                        break;
                    case ApplicationIntents.ReadWrite:
                        lstConnections.Add("ReadWrite");
                        break;
                }
            }
            if (!this.ApplicationName.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("Application Name={0}", this.ApplicationName)); }
            if (!this.AttachDBFileName.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("AttachDBFileName={0}", this.AttachDBFileName)); }
            if (this.AutoTranslate.HasValue) { lstConnections.Add(String.Format("AutoTranslate={0}", this.AutoTranslate.Value ? "true" : "false")); }
            if (this.ConnectTimeout.HasValue) { lstConnections.Add(String.Format("Connect Timeout={0}", this.ConnectTimeout.Value)); }
            if (!this.CurrentLanguage.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("Current Language={0}", this.CurrentLanguage)); }
            if (!this.Database.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("Database={0}", this.Database)); }
            if (!this.DataSource.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("Data Source={0}", this.DataSource)); }
            if (this.DataTypeCompatibility.HasValue) { lstConnections.Add(String.Format("DataTypeCompatibility={0}", this.DataTypeCompatibility.Value)); }
            if (this.Encrypt.HasValue) { lstConnections.Add(String.Format("Encrypt={0}", this.Encrypt.Value ? "yes" : "no")); }
            if (!this.FailoverPartner.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("FailoverPartner={0}", this.FailoverPartner)); }
            if (!this.FailoverPartnerSPN.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("FailoverPartnerSPN={0}", this.FailoverPartnerSPN)); }
            if (!this.InitialCatalog.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("Initial Catalog={0}", this.InitialCatalog)); }
            if (!this.InitialFileName.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("Initial File Name={0}", this.InitialFileName)); }
            if (this.IntegratedSecurity.HasValue) { lstConnections.Add(String.Format("Integrated Security={0}", this.IntegratedSecurity.Value ? "true" : "false")); }
            if (!this.Language.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("Language={0}", this.Language)); }
            if (this.MarsConn.HasValue) { lstConnections.Add(String.Format("MarsConn={0}", this.MarsConn.Value ? "yes" : "no")); }
            if (this.MARSConnection.HasValue) { lstConnections.Add(String.Format("MARS Connection={0}", this.MARSConnection.Value ? "true" : "false")); }
            if (!this.Network.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("Network={0}", this.Network)); }
            if (!this.NetworkAddress.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("Network Address={0}", this.NetworkAddress)); }
            if (!this.NetworkLibrary.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("Network Library={0}", this.NetworkLibrary)); }
            if (this.PacketSize.HasValue) { lstConnections.Add(String.Format("PacketSize={0}", this.PacketSize.Value)); }
            if (!this.Password.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("Password={0}", this.Password)); }
            if (this.PersistSecurityInfo.HasValue) { lstConnections.Add(String.Format("Persist Security Info={0}", this.PersistSecurityInfo.Value ? "true" : "false")); }
            if (this.PersistSensitive.HasValue) { lstConnections.Add(String.Format("PersistSensitive={0}", this.PersistSensitive.Value ? "yes" : "no")); }
            if (!this.Provider.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("Provider={0}", this.Provider)); }
            if (!this.PWD.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("PWD={0}", this.PWD)); }
            if (!this.Server.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("Server={0}", this.Server)); }
            if (!this.ServerSPN.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("ServerSPN={0}", this.ServerSPN)); }
            if (this.Timeout.HasValue) { lstConnections.Add(String.Format("Timeout={0}", this.Timeout.Value)); }
            if (this.TrustedConnection.HasValue) { lstConnections.Add(String.Format("Trusted_Connection={0}", this.TrustedConnection.Value ? "yes" : "no")); }
            if (this.TrustServerCertificate.HasValue) { lstConnections.Add(String.Format("TrustServerCertificate={0}", this.TrustServerCertificate.Value ? "yes" : "no")); }
            if (!this.UID.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("UID={0}", this.UID)); }
            if (this.UseEncryptionforData.HasValue) { lstConnections.Add(String.Format("Use Encryption for Data={0}", this.UseEncryptionforData.Value ? "true" : "false")); }
            if (!this.UserID.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("User ID={0}", this.UserID)); }
            if (!this.WorkstationID.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("Workstation ID={0}", this.WorkstationID)); }
            if (!this.WSID.IsNullOrWhiteSpace()) { lstConnections.Add(String.Format("WSID={0}", this.WSID)); }
            return String.Join(";", lstConnections.ToArray());
        }
        #endregion
    }
}
