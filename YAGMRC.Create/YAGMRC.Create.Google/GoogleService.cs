using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace YAGMRC.Create.GoogleStorage
{
    public class GoogleService
    {
        #region constructor

        public GoogleService()
        {
        }

        #endregion constructor

        private static GoogleService m_GoogleService;

        public static GoogleService GetInstance()
        {
            if (null == m_GoogleService)
            {
                m_GoogleService = new GoogleService();
            }

            return m_GoogleService;
        }

        private DriveService Authenticate(string user)
        {
            // TODO: on logout delete C:\Users\{user}\AppData\Roaming\Google.Apis.Auth

            GoogleClientSecrets config = GetClientConfiguration();

            List<string> scopes = new List<string>() { DriveService.Scope.Drive, DriveService.Scope.DriveFile };

            AuthorizationCodeFlow flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = config.Secrets,
                Scopes = scopes
            });

            var usercredentialstask = GoogleWebAuthorizationBroker.AuthorizeAsync(config.Secrets, scopes, user, System.Threading.CancellationToken.None, flow.DataStore);
            usercredentialstask.Wait();
            var usercredentialsresult = usercredentialstask.Result;

            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = usercredentialsresult,
                ApplicationName = "YAGMRC",
            });
        }

        private const string GoogleSecrectsFile = "googlesecrets.json";

        /// <summary>Retrieves the Client Configuration from the server path.</summary>
        /// <returns>Client secrets that can be used for API calls.</returns>
        private GoogleClientSecrets GetClientConfiguration()
        {
            FileInfo googleSecrets = new FileInfo(Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName, GoogleSecrectsFile));
            if (!googleSecrets.Exists)
            {
                throw new GoogleDriveException(googleSecrets + Environment.NewLine + "does not exists");
            }

            using (var stream = new FileStream(googleSecrets.FullName, FileMode.Open, FileAccess.Read))
            {
                return GoogleClientSecrets.Load(stream);
            }
        }

        public DriveService Service(string user)
        {
            return this.Authenticate(user);
        }
    }
}