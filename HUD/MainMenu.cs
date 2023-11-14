using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    [Header("MainMenu")]
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameObject Credits;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject QuitMenu;
    [SerializeField] private List<GameObject> MenuList = new List<GameObject>();
    [SerializeField] private List<GameObject> Button = new List<GameObject>();
    [SerializeField] private GameObject FirstSettingsButtons, FirstCreditsButtons, FirstButtonQuit, FirstMenuButton, FirstButtonEpileptic, FirstButtonTuto1, FirstButtontuto2;

    private void Start()
    {

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstButtonEpileptic);
        
    }
    public void ReturntoTheMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstMenuButton);
    }
    #region LevelChange
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
       
        Time.timeScale = 1;
    }
    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
       // SceneManager.LoadScene(4, LoadSceneMode.Additive);

        yield return null;

    }
    #endregion

   
    

    #region Option
    public void OpenOptionMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstSettingsButtons);

    }


    #endregion

    #region Credits 
    public void OpenCredi()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstCreditsButtons);
    }
    #endregion

    #region MenuToQuit

    public void OpenMenuToQuit()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstButtonQuit);
    }

    #endregion
    public void OpenTuto1()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstButtonTuto1);
    }

    public void OpenTuto2() {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstButtontuto2);
    }

    public void QuitTheGame()
    {
       Application.Quit();
    }

    private void Update()
    {
        if (  Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {

                int ActuelMenu = 0;
                foreach (var item in MenuList)
                {
                    if (item.activeSelf == true)
                    {
                        ActuelMenu = MenuList.IndexOf(item);
                    }
                }
                EventSystem.current.SetSelectedGameObject(Button[ActuelMenu]);
            }
           
        }
    }
}
