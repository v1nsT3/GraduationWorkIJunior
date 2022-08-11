using UnityEngine;

public class Menu : MonoBehaviour
{
    public void OpenPanel(GameObject gameObject)
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject gameObject)
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
