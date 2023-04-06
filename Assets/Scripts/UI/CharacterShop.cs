using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShop : MonoBehaviour
{
    public int BigCharacter;
    public int SimpleCharacter;
    public int NinjaCharacter;

    public int currentSkin;

    private void Start()
    {
        BigCharacter = PlayerPrefs.GetInt("BigCharacter");
        SimpleCharacter = PlayerPrefs.GetInt("SimpleCharacter");
        NinjaCharacter = PlayerPrefs.GetInt("NinjaCharacter");
        currentSkin = PlayerPrefs.GetInt("CurrentSkin");
    }

    public void BigCharacterSkins()
    {
        if (BigCharacter != 0)
        {
            currentSkin = 1;
            PlayerPrefs.SetInt("CurrentSkin", 1);
        }
        else
        {
            PlayerPrefs.SetInt("BigCharacter", 1);
            BigCharacter = PlayerPrefs.GetInt("BigCharacter");
            PlayerPrefs.SetInt("CurrentSkin", 1);
        }
    }
}
