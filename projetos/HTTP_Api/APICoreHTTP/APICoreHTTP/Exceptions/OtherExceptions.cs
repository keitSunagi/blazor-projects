namespace APICoreHTTP.Exceptions
{
    public class OtherExceptions : Exception
    {
        public OtherExceptions(string message, string innerMessage) 
            : base($"ERRO CRÍTICO |[{DateTime.Today.ToString()}] - ["
                  + message + "] - Inner - ["
                  + innerMessage + "]")
        {
            
        }
    }
}
