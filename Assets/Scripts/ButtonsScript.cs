using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    
    public string Menu, Ingame, Lose; //nomes de cenas a mudar

    // Troca de cena
    public void SwitchToGame()
    {
        SceneManager.LoadScene(Ingame);
    }
    public void SwitchToLose()
    {
        SceneManager.LoadScene(Lose);
    }
    public void SwitchToMenu()
    {
        SceneManager.LoadScene(Menu);
    }
}
