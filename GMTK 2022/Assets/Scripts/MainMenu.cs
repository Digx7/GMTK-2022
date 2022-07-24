using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public TextMeshProUGUI verNumText;

    public void Awake(){
      verNumText.text = "" + Application.version;
    }

    public void LoadScene(string name){
      SceneManager.LoadScene(name);
    }

    public void Quit(){
      Application.Quit();
    }


}
