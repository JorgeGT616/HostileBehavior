using UnityEngine;

public class SkinSelector : MonoBehaviour
{

    enum SkinType
    {
        Default,
        Green,
        Orange,
        Purple,
        Red,
        Blue,
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectSkin(int skinIndex)
    {
        SkinType selectedSkin = (SkinType)skinIndex;
        switch (selectedSkin)
        {
            case SkinType.Default:
                PlayerPrefs.SetInt("SelectedSkin", (int)SkinType.Default); 
                break;
            case SkinType.Green:
                PlayerPrefs.SetInt("SelectedSkin", (int)SkinType.Green);
                break;
            case SkinType.Orange:
                PlayerPrefs.SetInt("SelectedSkin", (int)SkinType.Orange);
                break;
            case SkinType.Purple:
                PlayerPrefs.SetInt("SelectedSkin", (int)SkinType.Purple);
                break;
            case SkinType.Red:
                PlayerPrefs.SetInt("SelectedSkin", (int)SkinType.Red);
                break;
            case SkinType.Blue:
                PlayerPrefs.SetInt("SelectedSkin", (int)SkinType.Blue);
                break;
            default:
                PlayerPrefs.SetInt("SelectedSkin", (int)SkinType.Default);
                break;
        }
    }
}
