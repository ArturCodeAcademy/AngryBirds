using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletePanel : MonoBehaviour
{
    public void OnNextButtonClick()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (sceneIndex >= SceneManager.sceneCountInBuildSettings)
			sceneIndex = 0;

        SceneManager.LoadScene(sceneIndex);
    }

    public void OnBackButtonClick()
    {
		SceneManager.LoadScene(0);
	}
}
