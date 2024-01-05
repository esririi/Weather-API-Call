namespace Weather
{
    internal interface IRestResponse
    {
        bool IsSuccessful { get; }
        object Content { get; }
        object ErrorMessage { get; }
    }
}