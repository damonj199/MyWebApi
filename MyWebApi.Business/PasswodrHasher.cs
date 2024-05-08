namespace MyWebApi.Business;

public class PasswodrHasher : IPasswodrHasher
{
    public string Generete(string password) =>
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string password, string hashedPassword) =>
        BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
}
