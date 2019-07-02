using Services.DataAccess;
using Services.Entities;

namespace Services
{
    public class SqlUserData : IUserData
    {
        private readonly AcesDbContext db;

        public SqlUserData(AcesDbContext db)
        {
            this.db = db;
        }
        public User GetByUsername(string username)
        {
            throw new System.NotImplementedException();
        }
        public User Add(User newUser)
        {
            db.Add(newUser);
            return newUser;
        }
        public int Commit(){
            return db.SaveChanges();
        }
    }
}
