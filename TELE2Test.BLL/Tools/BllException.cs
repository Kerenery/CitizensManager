namespace TELE2Test.BLL.Tools;

public class BllException : Exception
{
    public BllException()
    {
    }

    public BllException(string message)
    {
    }

    public BllException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}