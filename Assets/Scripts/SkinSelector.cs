using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    // Keep in sync with the "ships" array order in the Player prefab.
    enum SkinType
    {
        Default,
        Green,
        Orange,
        Purple,
        Red,
        Blue,
    }

    const int SkinCount = 6; // Number of available skins (SkinType values)

    public void SelectSkin(int skinIndex)
    {
        // Clamp to a valid range so a bad button argument can never store an
        // index that would be out of range when the ship is instantiated.
        skinIndex = Mathf.Clamp(skinIndex, 0, SkinCount - 1);

        PlayerPrefs.SetInt("SelectedSkin", skinIndex);
        PlayerPrefs.Save(); // Required so the choice persists on WebGL builds
    }
}
