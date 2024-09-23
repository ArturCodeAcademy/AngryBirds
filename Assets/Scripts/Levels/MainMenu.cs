using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _prefabButton;
    [SerializeField] private Transform _buttonContainer;

	private void Start()
	{
		for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
		{
			int buildIndex = i;
			Button button = Instantiate(_prefabButton, _buttonContainer);
			button.GetComponentInChildren<TMP_Text>().text = $"Level {i}";
			button.onClick.AddListener(() => SceneManager.LoadScene(buildIndex));
			button.gameObject.SetActive(true);
		}
	}

	public void OnQuitButtonClick()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}
