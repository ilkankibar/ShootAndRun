using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted;
    public GameObject mainMenu;
    public void StartGame()
    {
        isGameStarted = true;
        mainMenu.SetActive(false);
    }
}
