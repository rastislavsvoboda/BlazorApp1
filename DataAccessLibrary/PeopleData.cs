using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IPeopleData
    {
        Task<List<PersonModel>> GetPeople();
        Task InsertPerson(PersonModel person);
    }

    public class PeopleData : IPeopleData
    {
        private readonly ISqlDataAccess _db;

        public PeopleData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<PersonModel>> GetPeople()
        {
            var sql = "select * from dbo.People";
            return _db.LoadData<PersonModel, dynamic>(sql, new {});
        }

        public Task InsertPerson(PersonModel person)
        {
            var sql = @"insert into dbo.People (FirstName, LastName, EmailAddress)
                values (@FirstName, @LastName, @EmailAddress);";
            return _db.SaveData(sql, person);
        }
    }
}
