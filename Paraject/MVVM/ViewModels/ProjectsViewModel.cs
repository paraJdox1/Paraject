﻿using Paraject.Core.Commands;
using Paraject.MVVM.ViewModels.Windows;
using Paraject.MVVM.Views.ModalDialogs;
using System.Windows;
using System.Windows.Input;

namespace Paraject.MVVM.ViewModels
{
    public class ProjectsViewModel : BaseViewModel
    {
        public ICommand AddProjectCommand { get; }
        public ICommand AllProjectsCommand { get; }
        public ICommand PersonalProjectsCommand { get; }
        public ICommand PaidProjectsCommand { get; }
        public ICommand AddProjectsDialogCommand { get; }

        public string Message { get; set; } //test property
        public DisplayProjectsViewModel DisplayProjectsVM { get; set; }

        public ProjectsViewModel()
        {
            DisplayProjectsVM = new DisplayProjectsViewModel();

            AddProjectCommand = new DelegateCommand(Add);
            AllProjectsCommand = new DelegateCommand(AllProjects);
            PersonalProjectsCommand = new DelegateCommand(PersonalProjects);
            PaidProjectsCommand = new DelegateCommand(PaidProjects);
            AddProjectsDialogCommand = new DelegateCommand(ShowAddProjectsDialog);

            AllProjects();
        }

        public void Add()
        {
            MessageBox.Show("sfdsf");
        }

        #region Display Project/s Methods
        public void AllProjects()
        {
            Message = "all";
        }
        public void PersonalProjects()
        {
            Message = "personal";
        }
        public void PaidProjects()
        {
            Message = "paid";
        }
        #endregion

        #region AddProjectModalDialog dialog
        public void ShowAddProjectsDialog()
        {
            //Show overlay from MainWindow
            MainWindowViewModel.Overlay = true;

            AddProjectModalDialog addProjectModalDialog = new AddProjectModalDialog();
            addProjectModalDialog.DataContext = this;
            addProjectModalDialog.ShowDialog();
        }
        #endregion
    }
}
