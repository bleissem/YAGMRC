using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace YAGMRC.Mobile.ViewModels
{
    public abstract class ViewModelBase
    {
        #region constructor

        public ViewModelBase()
        {
        }

        #endregion constructor

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var property = (MemberExpression)expression.Body;
            this.OnPropertyChanged(property.Member.Name);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}