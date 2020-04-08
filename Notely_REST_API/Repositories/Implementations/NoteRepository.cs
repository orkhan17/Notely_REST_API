using Notely_REST_API.Database;
using Notely_REST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notely_REST_API.Repositories.Implementations
{
    public class NoteRepository: INoteRepository
    {
        private readonly NotelyDbContext _context;

        public NoteRepository(NotelyDbContext context)
        {
            _context = context;
        }

        public Note FindNoteById(long id)
        {
            var note = _context.Notes.Find(id);
            return note;
        }

        public IEnumerable<Note> GetAllNotes()
        {
            var notes = _context.Notes;
            return notes;
        }

        public void AddNote(Note note)
        {
            _context.Notes.Add(note);
        }

        public void UpdateNote(Note note)
        {
            _context.Notes.Update(note);
        }

        public void DeleteNote(long id)
        {
            var note = FindNoteById(id);
            _context.Notes.Remove(note);
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
