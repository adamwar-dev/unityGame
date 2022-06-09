using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*
 * Adam Warzecha
 */

public class EndMenuOverScreen : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public void SetupEndMenu(bool result) {
        gameObject.SetActive(true);
        resultText.text = resultText.text + (result ? "WON" : "LOST");
    }

    public void PlayAgain() {
        SceneManager.LoadScene("Main");
    }

     public void MainMenu() {
        SceneManager.LoadScene("Menu");
    }
}
