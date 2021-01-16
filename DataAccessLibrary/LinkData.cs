using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface ILinkData
    {
        Task<List<LinkModel>> GetLinks();
        Task InsertLink(LinkModel link);
    }

    public class LinkData : ILinkData
    {
        private readonly ISqlDataAccess _db;

        public LinkData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<LinkModel>> GetLinks()
        {
            var sql = "select * from links";
            return _db.LoadData<LinkModel, dynamic>(sql, new { });
        }

        public Task InsertLink(LinkModel link)
        {
            var sql = @"insert into links (url, name, description)
                values (@Url, @Name, @Description);";
            return _db.SaveData(sql, link);
        }
    }
}