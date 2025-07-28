using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] PlayerController playerController;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        playerController.SetCanMove(false);  // 이동 금지
        isPaused = true;
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void ResumeGame()
    {
        playerController.SetCanMove(true);  // 이동 허용
        isPaused = false;
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }

    public void GoToHomeScene()
    {
        playerController.SetCanMove(true);  // 이동 허용
        Debug.Log("홈화면으로 이동");


        // SceneManager.LoadScene("HomeScene");
    }
}