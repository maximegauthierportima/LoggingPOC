namespace LoggingPOC.Enums
{
    /// <summary>
    /// Enum containing the different flow of the application <br/>
    /// Useful to understand in which flow a problem happen
    /// </summary>
    public enum FlowId
    {
        GetWeather = 0,
        GetException = 1,
        GetArgumentNullException = 2
    }
}
