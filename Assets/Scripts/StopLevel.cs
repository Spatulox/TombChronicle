using UnityEngine;
using UnityEngine.SceneManagement;

public class StopLevel : MonoBehaviour
{
    public bool wonLevelOnTouch = true;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
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
