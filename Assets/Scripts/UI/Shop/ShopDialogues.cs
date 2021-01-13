using UnityEngine;

public class ShopDialogues : MonoBehaviour
{
    public const string WEAPON_WELCOME = "Welcome, welcome. Please feel free to look around.";
    public const string WEAPON_PURCHASE_SUCCESFUL = "A fine purchase, you won't regret it";
    public const string WEAPON_PURCHASE_UNSUCCESFUL_GOLD = "Not so fast, you don't have enough gold.";
    public const string WEAPON_PURCHASE_UNSUCCESFUL_FLOOR_REQUIREMENT = "You'll need to proof yourself in combat before I'll let you buy that";
    public const string WEAPON_PURCHASE_UNSUCCESFUL_NO_REQUIREMENTS_MET = "You'll need to proof yourself in combat and get some gold first";

    public const string SHIELD_WELCOME = "Looking for protection? You've come to the right Orc.";
    public const string SHIELD_PURCHASE_SUCCESFUL = "It's as tough as an Orc's hide. I should know.";
    public const string SHIELD_PURCHASE_UNSUCCESFUL_GOLD = "Are you just bad at counting or are you trying to rob me?";
    public const string SHIELD_PURCHASE_UNSUCCESFUL_FLOOR_REQUIREMENT = "You think I'd sell my finer shields to a rookie like you?";
    public const string SHIELD_PURCHASE_UNSUCCESFUL_NO_REQUIREMENTS_MET = "I won't sell that to a poor and inexperienced fighter";

    public const string ARMOR_WELCOME = "Looking for protection? You've come to the right Orc.";
    public const string ARMOR_PURCHASE_SUCCESFUL = "It's as tough as an Orc's hide. I should know.";
    public const string ARMOR_PURCHASE_UNSUCCESFUL_GOLD = "Hasn't anybody every told you that you shouldn't try to rob a Orc?";
    public const string ARMOR_PURCHASE_UNSUCCESFUL_FLOOR_REQUIREMENT = "Even a good piece of armor like that won't protect a rookie like you, come back when you have more experience";
    public const string ARMOR_PURCHASE_UNSUCCESFUL_NO_REQUIREMENTS_MET = "I won't sell that to a poor and inexperienced fighter.";

    public const string HEALER_WELCOME = "Hi warrior, for a price I can make sure you don't end up like me.";
    public const string HEALER_SUCCESFUL = "There you go, as good as new.";
    public const string HEALER_UNSUCCESFUL_GOLD = "Healing costs money, and you don't have enough to get fully healed. But I've patched you up a bit.";
    public const string HEALER_UNSUCCESFUL_FULL_HEALTH = "You don't need any healing";
    public const string HEALER_UNSUCCESFUL_FULL_MANA = "It seems like you are at full power already";
    public const string HEALER_UNSUCCESFUL_BOTH_FULL = "You seem to be at peak condition, you don't need my services";
    public const string HEALER_UNSUCCESFUL_PICK_ONE = "You might have enough gold to pay for one of my services, but not for both";
}
