// FinishTrigger (di SampleScene)
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 1. Dapatkan PlayerLook
            PlayerLook lookHandler = FindFirstObjectByType<PlayerLook>();
            
            // 2. Buka Kunci Kursor SEBELUM pindah scene
            if (lookHandler != null)
            {
                // Gunakan SetCursorLock(false) untuk membuka kursor dan membuatnya terlihat
                lookHandler.SetCursorLock(false); 
            }
            
            // 3. Pastikan waktu kembali normal jika di-pause, lalu pindah scene
            Time.timeScale = 1f;
            
            SceneManager.LoadScene("WinScene");
        }
    }
}