using System.Net;
using Kal3ndyla.Core.Tracks;
using Kal3ndyla.Infrastructure.Exceptions;
using Kal3ndyla.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kal3ndyla.API.Controllers;

[ApiController]
[Route("tracks")]
public class TrackController(ITrackService tracksService) : ControllerBase
{
    private readonly ITrackService _tracksService = tracksService;

    [HttpPost]
    [Route("")]
    public IActionResult AddTrack(CommonTrackInfo createTrackQuery)
    {
        try 
        {
            var createdGuid = _tracksService.AddTrack(createTrackQuery);
            return CreatedAtAction(nameof(AddTrack), new{ CreatedGuid = createdGuid });
        }
        catch
        {
            return InternalServerError();
        }
    }

    [HttpDelete]
    [Route("{guid:guid}")]
    public StatusCodeResult DeleteTrack(Guid guid)
    {
        try
        {
            _tracksService.DeleteTrack(guid);
            return NoContent();
        }
        catch
        {
            return InternalServerError();
        }
    }

    [HttpPut]
    [Route("")]
    public StatusCodeResult UpdateTrack(Track track)
    {
        try
        {
            _tracksService.UpdateTrack(track);
            return NoContent();
        }
        catch (TrackNotFoundException)
        {
            return NotFound();
        }
        catch
        {
            return InternalServerError();
        }
    }

    [HttpGet]
    [Route("")]
    public IActionResult GetTracks([FromQuery] TracksQuery trackQuery)
    {
        try
        {
            var foundTracks = _tracksService.GetTracks(trackQuery);
            return new JsonResult(foundTracks);
        }
        catch
        {
            return InternalServerError();
        }
    }

    [HttpGet]
    [Route("{guid:guid}")]
    public IActionResult GetTrack(Guid guid)
    {
        try
        {
            var foundTrack = _tracksService.GetTrack(guid);
            return new JsonResult(foundTrack);
        }
        catch
        {
            return InternalServerError();
        }
    }
    
    private StatusCodeResult InternalServerError() => StatusCode((int)HttpStatusCode.InternalServerError);
}