using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Core;

namespace YAGMRC.Common.Factories
{
    public class CreateGoogleStorage: IStorageFactory
    {
        #region Constructor

        public CreateGoogleStorage(string user)
        {
            m_User = user;
        }

        private string m_User;

        #endregion

        public IStorage Create()
        {
            return new YAGMRC.GoogleStorage.GoogleDriveStorage(m_User);
        }
    }
}
