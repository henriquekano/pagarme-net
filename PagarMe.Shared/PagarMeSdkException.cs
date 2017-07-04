using System;
namespace PagarMe
{
    public class PagarMeSdkException : Exception
    {
        private string _message { get; }

        public PagarMeSdkException(string message)
        {
            this._message = message;
        }
    }
}
