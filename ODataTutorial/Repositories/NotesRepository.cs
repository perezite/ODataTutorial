using System.Diagnostics;
using ODataTutorial.Entities;

namespace ODataTutorial.Repositories
{
    public class NotesRepository
    {
        private static readonly List<Note> Notes = new()
        {
            new Note {Id = Guid.NewGuid(), MessageNote = "Note 1"},
            new Note {Id = Guid.NewGuid(), MessageNote = "Note 2"},
        };

        public IQueryable<Note> GetNotes()
        {
            return Notes.Select(x => x).AsQueryable();
        }

        public Note? Find(Guid key)
        {
            return Notes.SingleOrDefault(x => x.Id == key);
        }

        public void Update(Guid id, Note note)
        {
            var existingNote = Find(id);
            Debug.Assert(existingNote != null, nameof(existingNote) + " != null");
            existingNote.MessageNote = note.MessageNote;
        }
    }
}
