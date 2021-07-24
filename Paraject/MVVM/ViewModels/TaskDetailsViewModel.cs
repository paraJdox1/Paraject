﻿using Paraject.Core.Commands;
using Paraject.Core.Enums;
using Paraject.Core.Repositories;
using Paraject.Core.Services.DialogService;
using Paraject.MVVM.Models;
using Paraject.MVVM.ViewModels.MessageBoxes;
using Paraject.MVVM.ViewModels.Windows;
using System;
using System.Windows.Input;

namespace Paraject.MVVM.ViewModels
{
    public class TaskDetailsViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly TaskRepository _taskRepository;
        private readonly Action _refreshTaskCollection;
        private readonly TasksViewModel _tasksViewModel;

        public TaskDetailsViewModel(Action refreshTaskCollection, TasksViewModel tasksViewModel, Task selectedTask, Project parentProject)
        {
            _dialogService = new DialogService();
            _taskRepository = new TaskRepository();

            _refreshTaskCollection = refreshTaskCollection;
            _tasksViewModel = tasksViewModel;
            ParentProject = parentProject;
            SelectedTask = selectedTask;
            PreviousSelectedTaskStatus = SelectedTask.Status;

            UpdateTaskCommand = new DelegateCommand(Update);
            DeleteTaskCommand = new DelegateCommand(Delete);
        }

        #region Properties
        public Project ParentProject { get; set; }
        public Task SelectedTask { get; set; }
        public string PreviousSelectedTaskStatus { get; set; }


        public ICommand UpdateTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }
        #endregion

        #region Methods
        private void Update()
        {
            if (TaskIsValid())
            {
                UpdateTaskAndShowResult(_taskRepository.Update(SelectedTask));
            }
        }
        private bool TaskIsValid()
        {
            if (TaskSubjectIsValid() == false)
            {
                _dialogService.OpenDialog(new OkayMessageBoxViewModel("Incorrect Data Entry", "A Task should have a subject.", Icon.InvalidTask));
                return false;
            }

            else if (TaskStatusCanBeCompleted() == false)
            {
                _dialogService.OpenDialog(new OkayMessageBoxViewModel("Update Operation", $"Unable to change this Task's Status to \"Completed\" because there are still {SelectedTask.SubtaskCount} unfinished subtask/s remaining.", Icon.InvalidTask));
                return false;
            }

            UpdateTaskCount();
            return true;
        }
        private bool TaskSubjectIsValid()
        {
            return !string.IsNullOrWhiteSpace(SelectedTask.Subject);
        }
        private bool TaskStatusCanBeCompleted()
        {
            //A Task's status can only be changed as "Completed" if they don't have any unfinished Subtasks
            if (SelectedTask.Status == "Completed")
            {
                return SelectedTask.SubtaskCount == 0;
            }

            return true;
        }
        private void UpdateTaskCount()
        {
            //if the Previous SelectedTask's Status is "Completed" and we change the task's status to Open or In Progress, +! to the parent's task count (add 1 more "Incomplete" task)
            if (PreviousSelectedTaskStatus == "Completed")
            {
                IncreaseTaskCountIfTaskIsUnfinished();
            }

            //if the Previous SelectedTask's Status is "Open" or "In Progress", and we change the task's status to Completed, -1 to the parent's task count (minus 1  "Incomplete" task)
            else
            {
                DecreaseTaskCountIfTaskIsCompleted();
            }
        }
        private void IncreaseTaskCountIfTaskIsUnfinished()
        {
            if (SelectedTask.Status != "Completed")
            {
                ParentProject.TaskCount += 1;
            }
        }
        private void DecreaseTaskCountIfTaskIsCompleted()
        {
            if (SelectedTask.Status == "Completed")
            {
                ParentProject.TaskCount -= 1;
            }
        }
        private void UpdateTaskAndShowResult(bool isValid)
        {
            if (isValid)
            {
                _refreshTaskCollection();
                _dialogService.OpenDialog(new OkayMessageBoxViewModel("Update Operation", "Task Updated Successfully!", Icon.ValidTask));
                return;
            }

            _dialogService.OpenDialog(new OkayMessageBoxViewModel("Error", "An error occured, cannot update the Task.", Icon.InvalidTask));
        }

        private void Delete()
        {
            DialogResults result = _dialogService.OpenDialog(new YesNoMessageBoxViewModel("Delete Operation",
                                                             "Do you want to DELETE this task? \n\nAll Subtasks that belongs to this Task will also be deleted.",
                                                             Icon.Task));
            if (result == DialogResults.Yes)
            {
                DeleteProject();
            }
        }
        private void DeleteProject()
        {
            bool isDeleted = _taskRepository.Delete(SelectedTask.Id);
            if (isDeleted)
            {
                //redirect to TasksView(parent View) after a successful DELETE operation, and
                //refreshes the Tasks Collection in TasksTodoViewCompletedTasksView(child Views of TasksView) with the new records
                _refreshTaskCollection();
                _dialogService.OpenDialog(new OkayMessageBoxViewModel("Delete Operation", "Task Deleted Successfully!", Icon.ValidTask));
                MainWindowViewModel.CurrentView = _tasksViewModel;
            }
            else
            {
                _dialogService.OpenDialog(new OkayMessageBoxViewModel("Error", "An error occured, cannot delete the Task.", Icon.InvalidTask));
            }
        }
        #endregion
    }
}
