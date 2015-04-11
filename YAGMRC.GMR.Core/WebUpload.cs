using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Core.Commands;
using YAGMRC.Core.Models.SubmitTurn;

namespace YAGMRC.GMR.Core
{
    public class WebUpload : IWebUpload
    {
        #region Constructor

        public WebUpload()
        {
            m_BaseUri = new Uri("http://multiplayerrobot.com");
        }

        #endregion Constructor

        private Uri m_BaseUri;

        private HttpClient CreateHttpClient()
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                MaxRequestContentBufferSize = 2147483647L,
                AllowAutoRedirect = false
            };

            HttpClient httpClient = new HttpClient(handler)
            {
                BaseAddress = m_BaseUri
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        public void Execute(WebUploadParam parameter)
        {
            DateTime dt = DateTime.UtcNow;

            HttpClient httpClient = this.CreateHttpClient();
            httpClient.DefaultRequestHeaders.ExpectContinue = new bool?(false);

            MultipartFormDataContent mfdc = new MultipartFormDataContent(string.Format("Upload----{0}", dt.ToString(CultureInfo.InvariantCulture)));
            mfdc.Add(new StringContent(parameter.TurnID.ToString()), "turnId");
            mfdc.Add(new StringContent(false.ToString()), "isCompressed");
            mfdc.Add(new StringContent(parameter.AuthKey), "authKey");
            mfdc.Add(new StreamContent(new MemoryStream(parameter.Data)), "saveFileUpload", string.Format("{0}.Civ5Save", parameter.TurnID));

            Task<HttpResponseMessage> task = httpClient.PostAsync(parameter.Path, mfdc);
            task.Wait();
            HttpResponseMessage result = task.Result;

            result.EnsureSuccessStatusCode();

            Task<string> task2 = result.Content.ReadAsStringAsync();
            task2.Wait();

            this.Result = new WebUploadResult(JsonConvert.DeserializeObject<SubmitTurnResult>(task2.Result));
        }

        public bool CanExecute()
        {
            return true;
        }

        public WebUploadResult Result
        {
            get;
            private set;
        }
    }
}