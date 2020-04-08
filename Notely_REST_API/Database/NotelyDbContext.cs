using Microsoft.EntityFrameworkCore;
using Notely_REST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notely_REST_API.Database
{
    public class NotelyDbContext: DbContext
    {
        public NotelyDbContext(DbContextOptions<NotelyDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
    }
}
