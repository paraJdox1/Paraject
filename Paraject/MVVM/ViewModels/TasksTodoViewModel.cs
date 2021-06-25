﻿using Paraject.Core.Commands;
using Paraject.MVVM.ViewModels.Windows;
using Paraject.MVVM.Views.ModalDialogs;
using System.Windows;
using System.Windows.Input;

namespace Paraject.MVVM.ViewModels
{
    public class TasksTodoViewModel : BaseViewModel
    {
        //test
        private readonly int _projectId;
        public TasksTodoViewModel(int projectId)
        {
            _projectId = projectId;
            AddTaskModalDialogCommand = new DelegateCommand(DisplayModal);
            AddTaskCommand = new DelegateCommand(Test);
        }

        private void DisplayModal()
        {
            //Show overlay from MainWindow
            MainWindowViewModel.Overlay = true;

            AddTaskModalDialog addTaskModalDialog = new();
            addTaskModalDialog.DataContext = this;
            addTaskModalDialog.Show();
        }

        private void Test()
        {
            MessageBox.Show($"{_projectId}");
        }

        public ICommand AddTaskModalDialogCommand { get; }
        public ICommand AddTaskCommand { get; }
    }
}
