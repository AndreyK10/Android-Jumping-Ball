using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "New Skin", menuName = "Create New Skin")]
public class SSkinInfo : ScriptableObject
{
    public enum SkinIDs { defaultSkin, skinAqua, skinBlue, skinGold, skinGreen, skinPink, skinRed }

    [SerializeField] private SkinIDs skinID;
    public SkinIDs _skinID { get { return skinID; } }

    [SerializeField] private GameObject skinPrefab;
    public GameObject _skinPrefab { get { return skinPrefab; } }

    [SerializeField] private int skinPrice;
    public int _skinPrice { get { return skinPrice; } }
}
