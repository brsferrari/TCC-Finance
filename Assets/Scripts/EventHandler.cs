using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventHandler : MonoBehaviour
{
    // Objetos para modificação
    [Header("Texto do Diálogo da Cama")]
    public TextMeshProUGUI textComponent;
    [Header("Objetos")]
    public GameObject CaixaDialogo;
    public GameObject Moveis;
    public GameObject Computer;
    public GameObject Callendar;
    public GameObject UI;
    public GameObject WorkScreen;

    // Detecção do Mouse
    Ray ray;
    RaycastHit hit;

    // Diálogo
    private int index;
    private int started;
    [Header("Texto que será escrito")]
    public string[] lines;
    public float textSpeed;


    void Start()
    {
        //Começar Ligado
        Moveis.SetActive(true);
        UI.SetActive(true);

        //Começar Desligado
        Computer.SetActive(false);
        CaixaDialogo.SetActive(false);
        Callendar.SetActive(false);
        WorkScreen.SetActive(false);
    }


    void Update()
    {
        // Detecção do Mouse ao Clicar
        if(Input.GetMouseButtonDown(0)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                // UI
                if (hit.transform.tag == "nextbutton") {
                    if (textComponent.text == lines[index]) {
                        NextLine();
                    } else {
                        StopAllCoroutines();
                        textComponent.text = lines[index];
                    }
                }

                // Moveis
                if (hit.transform.tag == "bed") {
                    StartDialogue();
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

    // Abre a Tela de Trabalho e Desativa o Botao de fechar a Tela do Computador
    public void StartWork() {

        WorkScreen.SetActive(true);
    }

    // Fecha a Tela de Trabalho e Ativa o Botao de fechar a Tela do Computador
    public void CloseWork() {
        WorkScreen.SetActive(false);
    }

// ####################################### //
//                DIALOGO                  //
// ####################################### //

    // Começar o Dialogo
    void StartDialogue() {
        index = 0;
        textComponent.text = string.Empty;
        CaixaDialogo.SetActive(true);
        Moveis.SetActive(false);
        StartCoroutine(TypeLine());
    }

    // Proxima Linha do Dialogo
    void NextLine() {
        if (index < lines.Length - 1) {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            CaixaDialogo.SetActive(false);
            Moveis.SetActive(true);
        }
    }

    // Co-rotina para escrever o dialogo
    IEnumerator TypeLine() {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

    }
}
