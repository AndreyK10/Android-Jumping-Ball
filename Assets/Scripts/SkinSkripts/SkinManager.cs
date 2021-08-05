using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{

    public static SkinManager instance;

    public GameObject equippedSkin { get; private set; }
    private const string PREF_SKIN = "skin_v2.0";

    [SerializeField] private Transform allSkinsInShopTransform;
    [SerializeField] private List<SkinInShop> skinsInShop = new List<SkinInShop>();

    private Button currentlyEquippedSkinButton;

    private void Awake()
    {
        instance = this;

        foreach (Transform s in allSkinsInShopTransform)
        {
            if (s.TryGetComponent(out SkinInShop skinInShop))
            {
                skinsInShop.Add(skinInShop);
            }
        }

        EquipPreviousSkin();

        SkinInShop equippedSkinInShop = Array.Find(skinsInShop.ToArray(), skin => skin._skinInfo._skinPrefab == equippedSkin);
        DisableEquipButton(equippedSkinInShop);
    }

    public void EquipSkin(SkinInShop skinInfoInShop)
    {
        equippedSkin = skinInfoInShop._skinInfo._skinPrefab;
        PlayerPrefs.SetString(PREF_SKIN, skinInfoInShop._skinInfo._skinID.ToString());

        if (currentlyEquippedSkinButton != null) currentlyEquippedSkinButton.interactable = true;

        DisableEquipButton(skinInfoInShop);        
    }
    private void EquipPreviousSkin()
    {
        string lastEquippedSkin = PlayerPrefs.GetString(PREF_SKIN, SSkinInfo.SkinIDs.defaultSkin.ToString());
        SkinInShop equippedSkinInShop = Array.Find(skinsInShop.ToArray(), skin => skin._skinInfo._skinID.ToString() == lastEquippedSkin);
        EquipSkin(equippedSkinInShop);
    }

    private void DisableEquipButton(SkinInShop skin)
    {
        currentlyEquippedSkinButton = skin.GetComponentInChildren<Button>();
        currentlyEquippedSkinButton.interactable = false;
    }
    public void EquipDefaultSkin()
    {
        EquipPreviousSkin();
    }
}
