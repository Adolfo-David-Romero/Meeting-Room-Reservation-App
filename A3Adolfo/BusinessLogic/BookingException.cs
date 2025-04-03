namespace A3Adolfo.BusinessLogic;


internal class BookingException: Exception
{
    /// <summary> Custom exception func. </summary>
    public BookingException(string message) :base(message) { }
}