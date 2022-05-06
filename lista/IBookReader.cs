namespace lista
{
    internal interface IBookReader
    {
        int ReadId();
        string ReadTitle();
        string ReadAutor();
        int ReadReleaseYear();
    }
}
