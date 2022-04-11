namespace LiteCRM.Api.Contracts;

public static class ApiRoutes
{
    private const string Base = "/api";

    public static class Users
    {
        public const string CreateUser = $"{Base}/users";
    }
}