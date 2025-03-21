namespace APICoreHTTP.Exceptions
{
    public class MusicNotFoundException : Exception
    {
        public MusicNotFoundException(string name) : base($"Música {name} não foi encontrada!.")
        {}

    }
}
