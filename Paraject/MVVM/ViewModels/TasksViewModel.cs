﻿using Paraject.Core.Commands;
using Paraject.Core.Repositories;
using Paraject.MVVM.Models;
using Paraject.MVVM.ViewModels.Windows;
using System.Windows.Input;

namespace Paraject.MVVM.ViewModels
{
    public class TasksViewModel : BaseViewModel
    {
        private readonly UserAccountRepository _userAccountRepository;

        public TasksViewModel(ProjectsViewModel projectsViewModel, Project currentProject)
        {
            CurrentProject = currentProject;
            _userAccountRepository = new UserAccountRepository();

            //TasksView child Views
            TasksTodoVM = new TasksTodoViewModel(currentProject.Id, "FinishLine");
            CompletedTasksVM = new CompletedTasksViewModel(currentProject.Id);
            ProjectNotesVM = new ProjectNotesViewModel();
            ProjectDetailsVM = new ProjectDetailsViewModel(projectsViewModel, currentProject);

            CurrentView = TasksTodoVM;

            //TasksView child Views
            TasksTodoViewCommand = new ParameterizedDelegateCommand(NavigateToTasksTodoView);
            CompletedTasksViewCommand = new ParameterizedDelegateCommand(o => { CurrentView = CompletedTasksVM; });
            ProjectNotesViewCommand = new ParameterizedDelegateCommand(o => { CurrentView = ProjectNotesVM; });
            ProjectDetailsViewCommand = new ParameterizedDelegateCommand(o => { CurrentView = ProjectDetailsVM; });
            NavigateBackToProjectsViewCommand = new DelegateCommand(NavigateBackToProjectsView);
        }

        #region Properties
        public Project CurrentProject { get; set; }
        public object CurrentView { get; set; }
        #endregion

        #region ViewModels (that will navigate with their associated Views)
        public ProjectsViewModel ProjectsVM { get; set; }

        //TasksView child Views
        public TasksTodoViewModel TasksTodoVM { get; set; }
        public CompletedTasksViewModel CompletedTasksVM { get; set; }
        public ProjectNotesViewModel ProjectNotesVM { get; set; }
        public ProjectDetailsViewModel ProjectDetailsVM { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateBackToProjectsViewCommand { get; }
        public ICommand TasksTodoViewCommand { get; }
        public ICommand CompletedTasksViewCommand { get; }
        public ICommand ProjectNotesViewCommand { get; }
        public ICommand ProjectDetailsViewCommand { get; }
        #endregion

        #region Navigation Methods
        public void NavigateBackToProjectsView()
        {
            ProjectsViewModel projectsViewModel = new ProjectsViewModel(_userAccountRepository.GetById(CurrentProject.User_Id_Fk));
            ProjectsVM = projectsViewModel;
            MainWindowViewModel.CurrentView = ProjectsVM;
        }
        private void NavigateToTasksTodoView(object taskType) //the argument passed to this parameter is in TasksView (a "CommandParameter" from a Tab header)
        {
            TasksTodoVM = new TasksTodoViewModel(CurrentProject.Id, taskType.ToString());
            CurrentView = TasksTodoVM;
        }
        #endregion

    }
}