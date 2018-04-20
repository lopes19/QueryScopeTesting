using System;
using System.Collections.Generic;

namespace QueryStack.Domain.Model.Users
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetMajorUsers();

        IEnumerable<User> GetEnabledUsers();

        IEnumerable<User> GetNotCanceledUsers();

        IEnumerable<User> GetMajorAndEnabledUsers();

        IEnumerable<User> GetAvailableUsers();
    }
}
