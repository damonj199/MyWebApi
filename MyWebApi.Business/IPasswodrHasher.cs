namespace MyWebApi.Business
{
    public interface IPasswodrHasher
    {
        string Generete(string password);
        bool Verify(string password, string hashedPassword);
    }
}