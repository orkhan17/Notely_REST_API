using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notely_REST_API.DTOs
{
    public class NoteToUpdateDto
    {
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime LastModified { get; set; }

        public NoteToUpdateDto()
        {
            LastModified = DateTime.Now;
        }
    }
}
