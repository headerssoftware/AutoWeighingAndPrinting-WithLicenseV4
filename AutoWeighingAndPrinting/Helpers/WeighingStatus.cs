using System.Drawing;

namespace AutoWeighingAndPrinting.Helpers
{
    public static class WeighingStatus
    {
        public const string WaitingForPart = "WAITING FOR PART";

        public const string WaitingForValidWeight = "WAITING FOR VALID WEIGHT";

        public const string WeightStabilizing = "WEIGHT STABILIZING";

        public const string WeightChanged = "WEIGHT CHANGED - RESETTING";

        public const string Printing = "PRINTING";

        public const string PrintedSuccessfully = "PRINTED SUCCESSFULLY - PLACE NEXT ITEM";

        public const string RemoveCurrentItem = "REMOVE CURRENT ITEM";

        public const string ZeroWeightValidation = "ZERO WEIGHT VALIDATION";

        public const string PlaceNextItem = "PLACE NEXT ITEM";

        public const string PrintFailed = "PRINT FAILED - CHECK PRINTER";

        public const string ScaleCommunicationError = "SCALE COMMUNICATION ERROR - TRY AGAIN";

        public const string Ready = "READY";
    }

    public static class WeighingColors
    {
        public static readonly Color Waiting = Color.LightGray;

        public static readonly Color Stabilizing = Color.Gold;

        public static readonly Color Success = Color.Green;

        public static readonly Color Error = Color.Red;

        public static readonly Color Information = Color.DodgerBlue;

        public static readonly Color Warning = Color.DarkOrange;
    }
}
