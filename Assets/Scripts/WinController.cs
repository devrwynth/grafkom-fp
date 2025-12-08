using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    void Start()
    {
        // 1. Pastikan waktu game normal (jika FinishTrigger lupa mengaturnya)
        Time.timeScale = 1f; 
        
        // 2. Pastikan kursor dilepaskan agar tombol UI bisa diklik
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
