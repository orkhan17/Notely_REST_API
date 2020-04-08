using Notely_REST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notely_REST_API.Repositories
{
    public interface INoteRepository
    {
        Note FindNoteById(long id);
        IEnumerable<Note> GetAllNotes();
        void AddNote(Note note);
        void UpdateNote(Note note);
        void DeleteNote(long id);
        bool SaveAll();
    }
}
