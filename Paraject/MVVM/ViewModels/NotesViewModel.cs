﻿using Paraject.Core.Commands;
using Paraject.Core.Repositories;
using Paraject.MVVM.Models;
using Paraject.MVVM.ViewModels.ModalDialogs;
using Paraject.MVVM.ViewModels.Windows;
using Paraject.MVVM.Views.ModalDialogs;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Paraject.MVVM.ViewModels
{
    public class NotesViewModel : BaseViewModel
    {
        private readonly int _currentProjectId;
        private readonly NoteRepository _noteRepository;

        public NotesViewModel(int currentProjectId)
        {
            _noteRepository = new NoteRepository();
            _currentProjectId = currentProjectId;

            ShowAddNoteModalDialogCommand = new ParameterizedDelegateCommand(ShowAddNoteModalDialog);
            ShowNoteDetailsModalDialogCommand = new ParameterizedDelegateCommand(ShowNoteDetailsModalDialog);

            DisplayAllNotes();
        }

        #region Properties
        public ObservableCollection<Note> Notes { get; set; }
        public ObservableCollection<GridTileData> NoteCardsGrid { get; set; }

        public ICommand ShowAddNoteModalDialogCommand { get; }
        public ICommand ShowNoteDetailsModalDialogCommand { get; }
        #endregion

        #region Methods
        private void DisplayAllNotes()
        {
            GetValuesForNotesCollection();
            SetNewGridDisplay();
            NoteCardsGridLocation();
        }
        private void GetValuesForNotesCollection()
        {
            Notes = new ObservableCollection<Note>(_noteRepository.GetAll(_currentProjectId));
        }
        private void SetNewGridDisplay()
        {
            NoteCardsGrid = null;
            NoteCardsGrid = new ObservableCollection<GridTileData>();
        }
        private void NoteCardsGridLocation()
        {
            int row = -1;
            int column = -1;

            //This is for a 3 column grid, with n number of rows
            for (int i = 0; i < Notes.Count; i++)
            {
                if (column == 2)
                {
                    column = 0;
                }

                else
                {
                    column++;
                }

                if (i % 3 == 0)
                {
                    row++;
                }

                GridTileData td = new(Notes[i], row, column);
                NoteCardsGrid.Add(td);
            }
        }

        public void ShowAddNoteModalDialog(object owner)
        {
            MainWindowViewModel.Overlay = true;

            AddNoteModalDialog addNoteModalDialog = new()
            {
                DataContext = new AddNoteModalDialogViewModel(DisplayAllNotes, _currentProjectId),
                Owner = owner as Window
            };
            addNoteModalDialog.ShowDialog();
        }
        public void ShowNoteDetailsModalDialog(object noteId)
        {
            MainWindowViewModel.Overlay = true;

            int selectedNote = (int)noteId;
            NoteDetailsModalDialogViewModel noteDetailsModalDialogViewModel = new NoteDetailsModalDialogViewModel(DisplayAllNotes, selectedNote);

            NoteDetailsModalDialog noteDetailsModalDialog = new NoteDetailsModalDialog();
            noteDetailsModalDialog.DataContext = noteDetailsModalDialogViewModel;
            noteDetailsModalDialog.ShowDialog();
        }
        #endregion
    }
}
