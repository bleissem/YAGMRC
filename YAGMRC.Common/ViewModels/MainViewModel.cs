using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAGMRC.Core;

namespace YAGMRC.Common.ViewModels
{
    public class MainViewModel 
    {
        #region constructor

        public MainViewModel()
        {
            this.CoreMainViewModel = new YAGMRC.Core.ViewModels.MainViewModel();
            this.GMRMainViewModel = new GMRMainViewModel();
        }

        #endregion


        public GMRMainViewModel GMRMainViewModel { get; private set; }

        public YAGMRC.Core.ViewModels.MainViewModel CoreMainViewModel { get; private set; }


    }
}
