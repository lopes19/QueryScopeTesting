using System;
using System.Linq.Expressions;

namespace QueryStack.Domain.Model.Users
{
    public static class UserScope
    {
        public static Expression<Func<User, bool>> EnabledUsers = (u) => u.Enabled;

        public static Expression<Func<User, bool>> MajorUsers = (u) => u.Age >= 18;

        public static Expression<Func<User, bool>> NotCancelledUsers = (u) => u.Status == RegisterStatus.APPROVED || u.Status == RegisterStatus.AWAITING_APPROVAL;

        public static Expression<Func<User, bool>> AvailableUsers = (u) => u.Enabled && u.Age >= 18 && u.Status == RegisterStatus.APPROVED;

        public static Expression<Func<User, bool>> AgeGreaterThan(int age)
        {
            return u => u.Age > age;
        }

    }
}
