using System;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]GameObject winScreen;
    [SerializeField]GameObject loseScreen;

    public void OpenWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void OpenLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}