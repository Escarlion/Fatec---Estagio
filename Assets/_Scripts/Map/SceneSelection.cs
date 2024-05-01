using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] GameObject transitionOut;
    public void ChangeScene()
    {
        Destroy(Instantiate(transitionOut, GameObject.FindGameObjectWithTag("Canvas").transform), 1.5f);
        Invoke(nameof(NewScene), 1.2f);
    }

    private void NewScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
