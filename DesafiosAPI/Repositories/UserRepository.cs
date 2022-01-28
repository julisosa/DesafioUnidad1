using DesafiosAPI.Models;

namespace DesafiosAPI.Repositories
{
    public class UserRepository : BaseRepository<User, DesafiosContext>
    {
        public UserRepository(DesafiosContext context) : base(context)
        {

        }
    }
}
