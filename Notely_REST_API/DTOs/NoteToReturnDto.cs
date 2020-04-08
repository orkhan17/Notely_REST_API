using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notely_REST_API.DTOs
{
    public class NoteToReturnDto
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public string CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
