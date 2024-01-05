using UnityEngine;
using UnityEngine.SceneManagement;

public class StopLevel : MonoBehaviour
{
    public bool wonLevelOnTouch = true;
    private void OnTriggerEnter(Collider other)
    {
        Cursor.lockState = CursorLockMode.None;

        if (other.CompareTag("Player"))
        {
            if (wonLevelOnTouch)
            {
                SceneManager.LoadScene("youWonMenu");
            }
            else
            {
                SceneManager.LoadScene("youLostMenu");
            }   
        }
    }
}
