using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
 public void onEasyButton ()
 {
    SceneManager.LoadScene("_Scene_0");
 }
  public void onHardButton ()
 {
    SceneManager.LoadScene("Hard");
 }
  public void onMediumButton ()
 {
    SceneManager.LoadScene("Medium");
 }
 public void onQuitButton()
 {
    Application.Quit();
 }

 public void OnMenuButton()
 {
   SceneManager.LoadScene(0);
 }

}
