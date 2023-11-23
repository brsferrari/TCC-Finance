using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DPUtils.Systems.DateTime;

public class EventHandler : MonoBehaviour
{
    // Objetos para modificação
    [Header("Objetos")]
    public GameObject Moveis;
    public GameObject Computer;
    public GameObject Callendar;
    public GameObject UI;
    public GameObject WorkScreen;
    public GameObject ShopScreen;
    public GameObject TimeAdvanceUI;
    public GameObject TimeHandler;
    public GameObject GetOutBedButton;

    // Detecção do Mouse
    Ray ray;
    RaycastHit hit;


    void Start()
    {
        //Começar Ligado
        Moveis.SetActive(true);
        UI.SetActive(true);

        //Começar Desligado
        Computer.SetActive(false);
        Callendar.SetActive(false);
        WorkScreen.SetActive(false);
    }


    void Update()
    {
        // Detecção do Mouse ao Clicar
        if(Input.GetMouseButtonDown(0)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                // Moveis
                if (hit.transform.tag == "bed") {
                    StartBed();
                }
                        
                if (hit.transform.tag == "pc") {
                    StartComputer();
                }
            }
        }
    }

// ####################################### //
//             Start and Close             //
// ####################################### //
    // Rotina para avançar o tempo 
    void StartBed() {
        // Variables
        TimeHandler timeHandler = TimeHandler.GetComponent<TimeHandler>();
        Image imageComponent = TimeAdvanceUI.GetComponent<Image>();

        // Visual Stuff
        Moveis.SetActive(false);
        GetOutBedButton.SetActive(true);
        imageComponent.color = new Color(0, 0, 0, 150f / 255f);

        // Variables Control
        timeHandler.TimeBetweenTicks = 0.2f;
    }

    public void CloseBed() {
        // Variables
        TimeHandler timeHandler = TimeHandler.GetComponent<TimeHandler>();
        Image imageComponent = TimeAdvanceUI.GetComponent<Image>();

        // Visual Stuff
        Moveis.SetActive(true);
        GetOutBedButton.SetActive(false);
        imageComponent.color = new Color(0, 0, 0, 0);

        // Variables Control
        timeHandler.TimeBetweenTicks = 2.0f;
    }

    // Abre a Tela do Computador e Desativa os colisores dos Moveis e da UI
    void StartComputer() {
        Computer.SetActive(true);
        Moveis.SetActive(false);
        UI.SetActive(false);
    }

    // Fecha a Tela do Computador e Ativa os Colisores dos Moveis e da UI
    public void CloseComputer() {
        Computer.SetActive(false);
        Moveis.SetActive(true);
        UI.SetActive(true);
    }

    // Abre a Tela de Trabalho
    public void StartWork() {
        WorkScreen.SetActive(true);
    }

    // Fecha a Tela de Trabalho
    public void CloseWork() {
        WorkScreen.SetActive(false);
    }

    // Abre a Tela de Trabalho
    public void StartShop() {
        ShopScreen.SetActive(true);
    }

    // Fecha a Tela de Trabalho
    public void CloseShop() {
        ShopScreen.SetActive(false);
    }

    public void SetActiveBool(GameObject gamingObject) {
        gamingObject.SetActive(!gamingObject.activeSelf);
    }
}