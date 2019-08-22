using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRepository
    {
        public void Add(User entity)
        {
            SomethingEntities ctx = new SomethingEntities();
            entity.IsDeleted = false;
            ctx.Users.Add(entity);
            ctx.SaveChanges();
        }
    }
}
