namespace Spider_Navigation.Models
{
    public class ValidateResult
    {
        public Message Result { get; set; }

        public string Message { get; set; }

        public string Input { get; set; }
    }

    public enum Message
    {
        Default,
        Failure,
        Success

    }

    public static class MessageExtensions
    {

        public static string Vaidation = "All Validation is Passed";

        public static string ValidInstruction = "The given Insturction is Valid";
        public static string InValidInstruction = "Insturction should contains only FLR";

        public static string ValidDirection = "The given Direction is Valid";
        public static string InValidDirection = "Direction should contains only Left Right Up and Down";

        public static string ValidSpidyLocation = "Spidy Location is Valid";
        public static string InvalidSpidyLocation = "Spidy Location is out of the Wall";

        public static string ValidSpidyCoordinates = "Spidy co-ordinates is Valid";
        public static string InvalidSpidyCoordinates = "Spidy co-ordinates is out of the Wall";


    }

}