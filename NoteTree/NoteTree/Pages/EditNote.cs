namespace NoteTree.Pages
{
    class EditNote : DetailPage
    {
        public EditNote(Note note) : base((Note)note.Clone()) { }
    }
}
