using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Create.Game.Common;

namespace YAGMRC.Create.Game.ViewModel
{
    public class MainViewModel: GalaSoft.MvvmLight.ViewModelBase
    {

        #region constructor

        public MainViewModel(IStorage storage)
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IStorage>(() => storage, true);
            SimpleIoc.Default.Register<CreateGameViewModel>(true);

      
        }        

        #endregion

        public CreateGameViewModel CreateGame
        {
            get
            {
                return SimpleIoc.Default.GetInstance<CreateGameViewModel>();
            }
        }

    }
}
