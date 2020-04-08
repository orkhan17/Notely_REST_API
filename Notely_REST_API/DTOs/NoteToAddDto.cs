using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notely_REST_API.DTOs
{
    public class NoteToAddDto
    {
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public NoteToAddDto()
        {
            CreatedDate = DateTime.Now;
            IsDeleted = false;
        }

    }
}
