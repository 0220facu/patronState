using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
namespace BLL
{
    public class BLLUser
    {
        DALUser dal = new DALUser();
        public void createUser(BEUser user)
        {
            dal.createUser(user);
        }
        public void updateUser(BEUser user)
        {
            dal.updateUser(user);
        }
        public List<BEUser> getUsers()
        {
            return dal.getUsers();
        }
    }
}
