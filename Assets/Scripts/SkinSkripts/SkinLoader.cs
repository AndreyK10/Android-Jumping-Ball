using UnityEngine;

public class SkinLoader : MonoBehaviour
{      
    private void Awake()
    {
        Instantiate(SkinManager.instance.equippedSkin);
    }
}
