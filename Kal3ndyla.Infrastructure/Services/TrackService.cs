using Kal3ndyla.Core.Tracks;
using Kal3ndyla.Infrastructure.Exceptions;
using Kal3ndyla.Infrastructure.Extensions;
using Kal3ndyla.Infrastructure.SearchEngine.Interfaces;
using Kal3ndyla.Infrastructure.Services.Interfaces;
using Kal3ndyla.Persistence.Contexts;
using Kal3ndyla.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Kal3ndyla.Infrastructure.Services;

public class TrackService(Kal3ndylaContext db, ISearchEngine<TrackModel, TracksQuery> searchEngine) : ITrackService
{
    private readonly Kal3ndylaContext _db = db;
    private readonly ISearchEngine<TrackModel, TracksQuery> _searchEngine = searchEngine;

    public Guid AddTrack(CommonTrackInfo createTrackQuery)
    {
        var model = new TrackModel{
            Guid = Guid.NewGuid(),
            Author = createTrackQuery.Author,
            Title = createTrackQuery.Title,
            Duration = createTrackQuery.Duration,
            Release = null
        };

        _db.Tracks.Add(model);
        _db.SaveChanges();

        return model.Guid;
    }

    public void DeleteTrack(Guid guid)
    {
        var trackToDelete = _db.Tracks.Single(track => track.Guid == guid);
        _db.Tracks.Remove(trackToDelete);
        _db.SaveChanges();
    }

    public Track GetTrack(Guid guid)
    {
        var foundTrack = _db.Tracks.AsNoTracking().SingleOrDefault(track => track.Guid == guid)?.ToTrack();

        if (foundTrack == null)
        {
            throw new TrackNotFoundException(guid);
        }

        return foundTrack;
    }

    public IEnumerable<Track> GetTracks(TracksQuery tracksQuery)
    {
        var heap = _db.Tracks.AsNoTracking();
        return _searchEngine.Search(heap, tracksQuery).Select(TrackModelExtensions.ToTrack);
    }

    public void UpdateTrack(Track track)
    {
        var existingTrack = _db.Tracks.SingleOrDefault(model => model.Guid == track.Guid);
        
        if (existingTrack is null)
        {
            throw new TrackNotFoundException(track.Guid);
        }

        existingTrack.Author = track.Author;
        existingTrack.Title = track.Title;
        existingTrack.Duration = track.Duration;

        _db.SaveChanges();
    }
}