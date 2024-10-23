using Kal3ndyla.Core.Products;
using Kal3ndyla.Core.Tracks;
using Kal3ndyla.Infrastructure.Services.Interfaces;
using Kal3ndyla.Persistence.Models;

namespace Kal3ndyla.Infrastructure.SearchEngine;

public class TracksSearchEngine : ISearchService<TrackModel, TrackFields>
{
    public IEnumerable<TrackModel> Search(IQueryable<TrackModel> heap, ProductsQuery<TrackFields> query)
    {
        if (query is null)
        {
            return heap;
        }

        if (query.Guid is not null)
        {
            var foundTrack = heap.SingleOrDefault(model => model.Guid == query.Guid);

            return foundTrack is null
                ? Array.Empty<TrackModel>()
                : [ foundTrack ];
        }

        var filteredTracks = heap;

        if (query.AuthorSubstring is not null)
        {
            filteredTracks = filteredTracks.Where(model => model.Author.Contains(query.AuthorSubstring));
        }

        if (query.TitleSubstring is not null)
        {
            filteredTracks = filteredTracks.Where(model => model.Title.Contains(query.TitleSubstring));
        }

        return filteredTracks;
    }
}