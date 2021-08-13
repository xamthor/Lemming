using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Extensions.Configuration;

namespace Lemming.Services
{
    public class YTService
    {
        private readonly YouTubeService _youtubeService;
        private readonly IConfigurationRoot _config;
        public YTService(IConfigurationRoot config)
        {
            _config = config;
            
            _youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = _config["YTKey"],
                ApplicationName = this.GetType().ToString()
            });
        }
        
        public async Task<string> Search(string query, int results)
        {
            var searchListRequest = _youtubeService.Search.List("snippet");
            searchListRequest.ChannelId = _config["YTChannel"];
            searchListRequest.Q = query;
            searchListRequest.MaxResults = results;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<string> videos = new List<string>();

            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add($"{searchResult.Snippet.Title} (https://www.youtube.com/watch?v={searchResult.Id.VideoId}");
                        break;
                }
            }

            return $"Videos:\n{string.Join("\n", videos)}\n";
        }
        
        public async Task<string> Random()
        {
            var searchListRequest = _youtubeService.Search.List("snippet");
            
            searchListRequest.ChannelId = _config["YTChannel"];
            searchListRequest.Q = "";
            searchListRequest.MaxResults = 21;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<string> videos = new List<string>();

            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add($"{searchResult.Snippet.Title} (https://www.youtube.com/watch?v={searchResult.Id.VideoId}");
                        break;
                }
            }

            int rndNum = new Random().Next(20);
            
            return $"Video:\n{videos[rndNum]}\n";
        }
    }
}