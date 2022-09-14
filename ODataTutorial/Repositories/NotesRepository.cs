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
            return Notes.Single(x => x.Id == key);
        }
    }
}
