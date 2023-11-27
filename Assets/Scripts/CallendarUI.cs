using UnityEngine;

public class CallendarUI : MonoBehaviour
{
    public GameObject Callendar;
    public GameObject UI;
    public GameObject Moveis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseCallendar() {
        Callendar.SetActive(false);
        UI.SetActive(true);
        Moveis.SetActive(true);
    }
}
