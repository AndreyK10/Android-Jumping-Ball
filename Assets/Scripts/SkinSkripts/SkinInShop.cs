using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SkinInShop : MonoBehaviour
{

    [SerializeField] private SSkinInfo skinInfo;
    public SSkinInfo _skinInfo { get { return skinInfo; } }

    [SerializeField] private Button equipButton;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private GameObject skinImage;

    [SerializeField] private bool isSkinUnlocked;
    [SerializeField] private bool isDefaultSkin;
    private void Awake()
    {
        skinImage.GetComponent<SpriteRenderer>().sprite = skinInfo._skinPrefab.GetComponent<SpriteRenderer>().sprite;
        skinImage.GetComponent<SpriteRenderer>().color = skinInfo._skinPrefab.GetComponent<SpriteRenderer>().color;

        if (isDefaultSkin) PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
        if (PlayerPrefs.GetInt(ScoreManager.PREFS_HIGHSCORE) >= skinInfo._skinPrice) PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);

        UpdateSkinButton();
    }

    private void UpdateSkinButton()
    {
        if (PlayerPrefs.GetInt(skinInfo._skinID.ToString()) == 1)
        {
            isSkinUnlocked = true;
            buttonText.text = "Equip";
        }
        else
        {
            buttonText.text = "Locked\nReach " + skinInfo._skinPrice;
            equipButton.interactable = false;
        }
    }

    public void EquipSkin()
    {
        if (isSkinUnlocked)
        {
            SkinManager.instance.EquipSkin(this);
        }

    }
}
