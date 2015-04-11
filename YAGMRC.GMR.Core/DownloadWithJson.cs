using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace YAGMRC.GMR.Core
{
    internal class DownloadWithJson
    {

        #region Constructor

        public DownloadWithJson(Uri baseUri)
        {
            m_BaseUri = baseUri;
        }

        #endregion

        private Uri m_BaseUri;

        public T Execute<T>(string rest)
        {
            Uri diplomacyUri = new Uri(m_BaseUri, rest);

            using (WebClient wc = new WebClient())
            {
                Stream s = wc.OpenRead(diplomacyUri);
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        string str = sr.ReadToEnd();
                        return JsonConvert.DeserializeObject<T>(str);
                    }
                }
            }
        }

    }
}
