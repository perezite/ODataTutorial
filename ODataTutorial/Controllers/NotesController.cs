using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataTutorial.Entities;
using ODataTutorial.Repositories;

namespace ODataTutorial.Controllers;

public class NotesController : ODataController
{
    private readonly NotesRepository _repository = new();

    [EnableQuery(PageSize = 15)]
    public IQueryable<Note> Get()
    {
        return _repository.GetNotes();
    }

    //[EnableQuery]
    //public SingleResult<Note> Get([FromODataUri] Guid key)
    //{
    //    var result = _db.Notes.Where(c => c.Id == key);
    //    return SingleResult.Create(result);
    //}

    //[EnableQuery]
    //public async Task<IActionResult> Post([FromBody] Note note)
    //{
    //    _db.Notes.Add(note);
    //    await _db.SaveChangesAsync();
    //    return Created(note);
    //}

    [EnableQuery]
    public async Task<IActionResult> Patch([FromODataUri] Guid key, Delta<Note> note)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingNote = _repository.Find(key);
        if (existingNote == null)
        {
            return NotFound();
        }

        note.Patch(existingNote);

        await Task.CompletedTask;
        return Updated(existingNote);
    }

    //[EnableQuery]
    //public async Task<IActionResult> Delete([FromODataUri] Guid key)
    //{
    //    Note existingNote = await _db.Notes.FindAsync(key);
    //    if (existingNote == null)
    //    {
    //        return NotFound();
    //    }

    //    _db.Notes.Remove(existingNote);
    //    await _db.SaveChangesAsync();
    //    return StatusCode(StatusCodes.Status204NoContent);
    //}

    //private bool NoteExists(Guid key)
    //{
    //    return _db.Notes.Any(p => p.Id == key);
    //}
}
