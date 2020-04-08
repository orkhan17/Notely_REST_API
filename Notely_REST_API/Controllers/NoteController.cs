using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notely_REST_API.DTOs;
using Notely_REST_API.Models;
using Notely_REST_API.Repositories;
namespace Notely_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public NoteController(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }


        [HttpGet("{id}", Name = "GetSingleNote")]
        public IActionResult GetNote(long id)
        {
            var note = _noteRepository.FindNoteById(id);

            if (note == null)
                return NotFound();

            var noteToReturn = _mapper.Map<NoteToReturnDto>(note);
            return Ok(noteToReturn);
        }

        [HttpGet]
        public IActionResult GetAllNotes()
        {
            var notes = _noteRepository.GetAllNotes().ToList();
           // var noteToReturn = _mapper.Map<IEnumerable<NewsToReturnDto>>(news);
            if (notes == null)
                return NotFound();

            return Ok(notes);
        }

        [HttpPost]
        public IActionResult AddNote([FromBody]NoteToAddDto noteToAddDto)
        {
            var noteToAdd = _mapper.Map<Note>(noteToAddDto);
            _noteRepository.AddNote(noteToAdd);

            bool result = _noteRepository.SaveAll();

            if (!result)
                return new StatusCodeResult(500);

            return CreatedAtRoute("GetSingleNote", new { id = noteToAdd.Id }, _mapper.Map<NoteToReturnDto>(noteToAdd));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNote(long id, [FromBody]NoteToUpdateDto noteToUpdateDto)
        {
            var note = _noteRepository.FindNoteById(id);

            if (note == null)
                return NotFound();

            _mapper.Map(noteToUpdateDto, note);
            _noteRepository.UpdateNote(note);

            bool result = _noteRepository.SaveAll();

            if (!result)
                return new StatusCodeResult(500);

            var noteToReturn = _mapper.Map<NoteToReturnDto>(note);
            return Ok(noteToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(long id)
        {
            var note = _noteRepository.FindNoteById(id);
            if (note == null)
                return NotFound();

            _noteRepository.DeleteNote(id);

            bool result = _noteRepository.SaveAll();

            if (!result)
                return new StatusCodeResult(500);

            return NoContent();
        }
    }
}