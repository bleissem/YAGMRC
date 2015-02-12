using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Mobile.Common
{
    public interface ICommand
    {
        void Execute();

        bool CanExecute();
    }

    public interface ICommand<TParam>
    {
        void Execute(TParam parameter);

        bool CanExecute();
    }


    public interface ICommand<TParamExecute, TParamCanExecute>
    {
        void Execute(TParamExecute parameter);

        bool CanExecute(TParamCanExecute parameter);
    }
}
