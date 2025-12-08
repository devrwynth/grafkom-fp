// PauseHandler (di SampleScene)
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    private bool isPaused = false;

    // Fungsi untuk memperbarui status dari luar (dipanggil dari PauseController)
    public void SetPausedStatus(bool paused)
    {
        isPaused = paused;
        // Jika di-resume dari tombol, kita Unload scene di PauseController
        // Di sini kita hanya memastikan statusnya benar
    }

    void Update()
    {
        // Cek input P hanya jika game berjalan (Time.timeScale = 1f)
        // atau jika game di-pause (isPaused = true)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                // Jika isPaused true, berarti scene PauseScene sudah dimuat.
                // Saat tombol 'P' ditekan, kita harus memanggil ResumeGame().
                // PENTING: Karena ResumeGame() akan meng-unload PauseScene, 
                // pastikan SceneManager.UnloadSceneAsync("PauseScene") dijalankan.
                ResumeGame();
            }
        }
    }

    public void PauseGame() 
    {
        if (isPaused) return; 

        Time.timeScale = 0f;
        SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
        isPaused = true;
        
        // Dapatkan dan BUKA KUNCI kursor saat pause
        PlayerLook lookHandler = FindFirstObjectByType<PlayerLook>();
        if (lookHandler != null)
        {
            lookHandler.SetCursorLock(false); // BUKA KUNCI KURSORE
        }
    }

    // Fungsi ResumeGame untuk tombol 'Esc'
    public void ResumeGame()
    {
        if (!isPaused) return; 
        
        // Dapatkan dan KUNCI KEMBALI kursor saat resume
        PlayerLook lookHandler = FindFirstObjectByType<PlayerLook>();
        if (lookHandler != null)
        {
            lookHandler.SetCursorLock(true); // KUNCI KEMBALI KURSORE
        }
        
        // Pastikan SceneManager.UnloadSceneAsync dipanggil hanya jika Scene dimuat
        Scene pauseScene = SceneManager.GetSceneByName("PauseScene");
        
        if (pauseScene.isLoaded)
        {
            Time.timeScale = 1f;
            SceneManager.UnloadSceneAsync("PauseScene");
        }
        
        isPaused = false;
    }
}