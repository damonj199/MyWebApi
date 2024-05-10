namespace MyWebApi.Business;

public static class PasswodrHasher
{
    public static string Generete(string password) =>
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public static bool Verify(string password, string hashedPassword) =>
        BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
}
