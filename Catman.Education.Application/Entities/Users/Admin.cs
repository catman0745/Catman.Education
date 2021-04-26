namespace Catman.Education.Application.Entities.Users
{
    public class Admin : User
    {
        public override string Role => nameof(Admin);
    }
}
