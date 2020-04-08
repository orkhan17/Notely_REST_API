using AutoMapper;
using Notely_REST_API.DTOs;
using Notely_REST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notely_REST_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<NoteToAddDto, Note>();
            CreateMap<Note, NoteToReturnDto>();
            CreateMap<NoteToUpdateDto, Note>();
        }
    }
}
