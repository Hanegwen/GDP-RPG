using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    string nextScene;   //name of character select screen
    [SerializeField]
    GameObject creditsPanel;    //image containing credits
    [SerializeField]
    GameObject quitPopUpImage;  //image asking if player is sure they want to quit

    public void StartButtonPressed()
    {
        SceneManager.LoadScene(nextScene);  //load character select scene
    }

    public void CreditsButtonPressed()  //credits button and credits back button
    {
        if (creditsPanel.activeSelf)
            creditsPanel.SetActive(false);
        else
            creditsPanel.SetActive(true);
    }

    public void QuitButtonPressed() //quit button and quit back button
    {
        if (quitPopUpImage.activeSelf)
            quitPopUpImage.SetActive(false);
        else
            quitPopUpImage.SetActive(true);
    }

    public void QuitGameButtonPressed() //actual quit button
    {
        Application.Quit(); //closes down application
    }
}
