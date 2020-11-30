namespace Catman.Education.Application.Extensions
{
    using System.Linq;
    using Catman.Education.Application.Entities;

    internal static class RolesExtensions
    {
        public static bool IsAdmin(this User user) =>
            user.Role == Roles.Admin;

        public static bool IsStudent(this User user) =>
            user.Role == Roles.Student;

        public static bool ValidRole(this string role) =>
            Roles.ValidRoles.Contains(role);
    }
}
