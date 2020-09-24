using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        //Instance created
        private readonly ConnectionToEs _connectionToEs;

        //Constructor
        public UserRL()
        {
            _connectionToEs = new ConnectionToEs();
        }

        //Method to search data 
        public object DataSearch(string UserRole)
        {
            try
            {
                var responsedata = _connectionToEs.EsClient().Search<UserDetails>(s => s
                                .Index("bookstore")
                                .Size(3)
                                .Query(q => q
                                    .Match(m => m
                                        .Field(f => f.UserRole)
                                        .Query(UserRole)
                                    )
                                )
                            );

                var datasend = (from hits in responsedata.Hits
                                select hits.Source).ToList();

                return datasend;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
