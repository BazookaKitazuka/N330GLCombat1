using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void playGame()
   {
       //Change Game from title to game
        SceneManager.LoadScene("Map1");
   }

    public void quitGame()
   {
      Application.Quit();
   }


}
