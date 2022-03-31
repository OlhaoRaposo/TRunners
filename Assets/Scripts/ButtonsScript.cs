using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{

    public string level; //nome do level a mudar

    // Troca de cena
    public void OnButtonLoadScene()
    {
        SceneManager.LoadScene(level);
    }
}
