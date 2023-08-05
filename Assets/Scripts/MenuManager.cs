using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;

    
    public void OpenMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }
}
