using UnityEngine;

public class ColorConfig : MonoBehaviour {

    public const string RED     = "#FA2020";
    public const string PURPLE  = "#7554E2";
    public const string BLUE    = "#2E32B7";
    public const string AQUA    = "#54DBE2";
    public const string YELLOW  = "#EEE721";
    public const string GREEN   = "#13D432";
    public const string PINK    = "#E254D0";
    public const string BLACK   = "#000000";
    public const string GREY    = "#808080";
    public const string WHITE   = "#FFFFFF";
    public const string BROWN   = "#A52A2A";
    public const string MAGENTA = "#FF00FF";

    //UI Colors
    public const string TEXT_GREY = "#323232";
    public const string IMAGINE_GREYOUT = "#9B9B9B";

    public static Color ConvertHexColor(string colorConfigCode)
    {
        Color tempColor;
        if (ColorUtility.TryParseHtmlString(colorConfigCode, out tempColor))
        {
            return tempColor;
        }
        return tempColor;
    }
}