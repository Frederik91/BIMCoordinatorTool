using BIMCoordinatorTool;
using GalaSoft.MvvmLight;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using System.Windows.Input;

namespace BIMCoordinatorToolWpf.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ICommand _addProjectCommand;
        private ICommand _removeProjectCommand;
        private ICommand _sendUpdateCommand;

        public MainViewModel()
        {
            //_addProjectCommand = new DelegateCommand();
            _sendUpdateCommand = new DelegateCommand(sendUpdateMails);
        }

        private void sendUpdateMails()
        {
            var MH = new MailingApi();
            MH.serviceSetup();
            MH.SendMail();
        }

        public ICommand AddProjectCommand
        {
            get { return _addProjectCommand; }
            set
            {
                _addProjectCommand = value;
                OnPropertyChanged("AddProjectCommand");
            }
        }

        public ICommand SendUpdateCommand
        {
            get { return _sendUpdateCommand; }
            set
            {
                _sendUpdateCommand = value;
                OnPropertyChanged("SendUpdateCommand");
            }
        }
    }
}