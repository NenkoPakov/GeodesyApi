using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Nest;
using GeodesyApi.Data.Models;

namespace GeodesyApi.Services
{
    public class SearchService
    {
//
//
//        private const string ServerAddress = "http://localhost:9200";
//        private const string IndexName = "News";
//
//        /// <summary>
//        /// Returns forum post ids that matches the given query
//        /// </summary>
//        public IEnumerable<int> Search(string query)
//        {
//            var client = this.GetClient();
//            var ids =
//                client.Search<ElasticSearchNews>(s => s.fie("Id").QueryString(query).Take(1000))
//                    .Hits.OrderByDescending(x => x.Score).Select(x => x.Id.ToInteger());
//
//            return ids;
//        }
//
//        /// <summary>
//        /// Add or update index for a given forumPost
//        /// </summary>
//        /// <param name="news"></param>
//        public void Index(News news)
//        {
//            var client = this.GetClient();
//
//            client.Delete<ElasticSearchNews>(news.Id);
//            var forumPostContent = new StringBuilder();
//            this.GetAllForumPostContent(news, forumPostContent);
//            var indexData = news.Title + " " + string.Join(" ", news.Tags.Select(x => x.Word)).Trim() + " " + forumPostContent;
//            indexData = indexData.StripHtmlTags().Replace("&nbsp;", " ").Trim();
//            var data = new ElasticSearchNews { Id = news.Id, Content = indexData };
//            client.Index(data);
//        }
//
//        public void Remove(ForumPost forumPost)
//        {
//            var client = this.GetClient();
//            client.Delete<ElasticSearchNews>(forumPost.Id);
//        }
//
//        public void WarmUp()
//        {
//            var client = this.GetClient();
//            var indexSettings = new IndexSettings { NumberOfReplicas = 1, NumberOfShards = 1 };
//            client.CreateIndex(
//                c =>
//                c.Index(IndexName)
//                    .InitializeUsing(indexSettings)
//                    .AddMapping<ElasticSearchForumPost>(m => m.MapFromAttributes()));
//        }
//
//        private void GetAllForumPostContent(News forumPost, StringBuilder result)
//        {
//            result.AppendLine(forumPost.Content);
//            foreach (var post in forumPost.Children)
//            {
//                GetAllForumPostContent(post, result);
//            }
//        }
//
//        private ElasticClient GetClient()
//        {
//            var settings = new ConnectionSettings(new Uri(ServerAddress));
//            var client = new ElasticClient(settings);
//            return client;
//        }
    }
}
