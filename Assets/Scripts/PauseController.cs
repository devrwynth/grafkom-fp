// PauseController (di PauseScene)
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public void OnResumeClick()
    {
        // 1. Kembalikan waktu agar game berjalan normal
        Time.timeScale = 1f;
        
        PauseHandler handler = FindFirstObjectByType<PauseHandler>();
        PlayerLook lookHandler = FindFirstObjectByType<PlayerLook>();

        if (handler != null)
        {
            handler.SetPausedStatus(false); 
        }
        
        // 2. KUNCI KEMBALI KURSORE setelah tombol diklik
        if (lookHandler != null)
        {
            lookHandler.SetCursorLock(true); 
        }

        // 3. Bongkar scene pause (UnloadSceneAsync dilakukan terakhir)
        SceneManager.UnloadSceneAsync("PauseScene");
    }

    public void OnRestartClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnMenuClick()
    {
        Time.timeScale = 1f; // Pastikan waktu kembali normal sebelum ke menu
        SceneManager.LoadScene("MenuScene"); // Sebaiknya Load Scene Menu yang benar
    }
}