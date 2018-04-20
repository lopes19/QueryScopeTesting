using QueryStack.Domain.Model.Users;
using System.Collections.Generic;
using System.Linq;

namespace QueryStack.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository()
        {
            _context = new DataContext();
        }

        #region Sem SCOPE

        //public IEnumerable<User> GetMajorUsers()
        //{
        //    return _context.Users
        //        .AsNoTracking()
        //        .Where(x => x.Age >= 18)
        //        .ToList();
        //}

        //public IEnumerable<User> GetEnabledUsers()
        //{
        //    return _context.Users
        //        .AsNoTracking()
        //        .Where(x => x.Enabled)
        //        .ToList();
        //}

        //public IEnumerable<User> GetNotCanceledUsers()
        //{
        //    return _context.Users
        //        .AsNoTracking()
        //        .Where(x => x.Status == RegisterStatus.APPROVED || x.Status == RegisterStatus.AWAITING_APPROVAL)
        //        .ToList();
        //}

        //public IEnumerable<User> GetMajorAndEnabledUsers()
        //{
        //    return _context.Users
        //        .AsNoTracking()
        //        .Where(x => x.Age >= 18)
        //        .Where(x => x.Enabled)
        //        .ToList();
        //}

        //public IEnumerable<User> GetAvailableUsers()
        //{
        //    return _context.Users
        //        .AsNoTracking()
        //        .Where(x => x.Age >= 18)
        //        .Where(x => x.Enabled)
        //        .Where(x => x.Status == RegisterStatus.APPROVED)
        //        .ToList();
        //}

        //public IEnumerable<User> GetUsersWhoseAgeIsGreatherThan(int age)
        //{
        //    return _context.Users
        //        .AsNoTracking()
        //        .Where(x => x.Age > age)
        //        .ToList();
        //}

        #endregion

        #region Com SCOPE

        public IEnumerable<User> GetMajorUsers()
        {
            return _context.Users
                .AsNoTracking()
                .Where(UserScope.MajorUsers)
                .ToList();
        }

        public IEnumerable<User> GetEnabledUsers()
        {
            return _context.Users
                .AsNoTracking()
                .Where(UserScope.EnabledUsers)
                .ToList();
        }

        public IEnumerable<User> GetNotCanceledUsers()
        {
            return _context.Users
                .AsNoTracking()
                .Where(UserScope.NotCancelledUsers)
                .ToList();
        }

        public IEnumerable<User> GetMajorAndEnabledUsers()
        {
            return _context.Users
                .AsNoTracking()
                .Where(UserScope.MajorUsers)
                .Where(UserScope.EnabledUsers)
                .ToList();
        }

        public IEnumerable<User> GetAvailableUsers()
        {
            return _context.Users
                .AsNoTracking()
                .Where(UserScope.AvailableUsers)
                .ToList();
        }

        public IEnumerable<User> GetUsersWhoseAgeIsGreaterThan(int age)
        {
            return _context.Users
                .AsNoTracking()
                .Where(UserScope.AgeGreaterThan(age))
                .ToList();
        }

        #endregion

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
