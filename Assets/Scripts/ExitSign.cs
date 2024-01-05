using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSign : MonoBehaviour
{
    // Update is called once per frame
    public void ExitLevel()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("mainMenu");
    }
}
