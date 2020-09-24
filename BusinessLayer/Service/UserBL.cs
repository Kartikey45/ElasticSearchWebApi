using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL _IUserRL;

        public UserBL(IUserRL _IUserRL)
        {
            this._IUserRL = _IUserRL;
        }

        public object DataSearch(string UserRole)
        {
            try
            {
                var result = _IUserRL.DataSearch(UserRole);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
