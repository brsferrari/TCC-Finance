using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialHandler : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject final;
    public GameObject UIMoney;
    public GameObject currency_text;
    public GameObject work_button;
    public GameObject work_screen;
    public GameObject shop_screen;
    public GameObject close_work_button;
    public GameObject close_shop_button;
    public GameObject open_shop_button;
    public GameObject open_work_button;
    public GameObject close_pc_button;
    public GameObject pc;
    public GameObject PcScreen;
    public GameObject bed;
    public GameObject exhaustion;
    public GameObject standard_text;
    public GameObject next_button;
    private int actual_dialogue = 0;
    private int dialoguesize;
    private float current_currency = 0F;


    void Start() {
        StartTutorial();
    }

    void StartTutorial() {
        dialoguesize = dialogue.sentences.Length;
        string sentence = dialogue.sentences[actual_dialogue];
        standard_text.GetComponent<TextMeshProUGUI>().text = sentence;
        UIMoney.SetActive(true);
        actual_dialogue += 1;
    }

    public void NextDialogue() {
        string sentence = dialogue.sentences[actual_dialogue];
        if (actual_dialogue == 1) {
            standard_text.GetComponent<TextMeshProUGUI>().text = sentence;
            UIMoney.SetActive(false);
            next_button.SetActive(false);
            pc.SetActive(true);
        } else if (actual_dialogue == 2) {
            standard_text.GetComponent<TextMeshProUGUI>().text = sentence;
            pc.SetActive(false);
            open_shop_button.SetActive(false);
            close_pc_button.SetActive(false);
            PcScreen.SetActive(true);
        } else if (actual_dialogue == 3) {
            standard_text.GetComponent<TextMeshProUGUI>().text = sentence;
            work_screen.SetActive(true);
            next_button.SetActive(true);
        } else if (actual_dialogue == 4) {
            standard_text.GetComponent<TextMeshProUGUI>().text = sentence;
            exhaustion.SetActive(true);
        } else if (actual_dialogue == 5) {
            standard_text.GetComponent<TextMeshProUGUI>().text = sentence;
            close_work_button.SetActive(true);
            open_shop_button.SetActive(true);
            next_button.SetActive(false);
        } else if (actual_dialogue == 6) {
            standard_text.GetComponent<TextMeshProUGUI>().text = sentence;
            work_screen.SetActive(false);
            open_work_button.SetActive(false);
        } else if (actual_dialogue == 7) {
            standard_text.GetComponent<TextMeshProUGUI>().text = sentence;
            shop_screen.SetActive(true);
            close_shop_button.SetActive(false);
            next_button.SetActive(true);
        } else if (actual_dialogue == 8) {
            standard_text.GetComponent<TextMeshProUGUI>().text = sentence;
            next_button.SetActive(false);
            close_shop_button.SetActive(true);
            bed.SetActive(true);
        } else if (actual_dialogue == 9) {
            standard_text.GetComponent<TextMeshProUGUI>().text = sentence;
            bed.SetActive(false);
            final.SetActive(true);
        }
        actual_dialogue += 1;
    }

    public void IncreaseMoney() {
        current_currency += 1F;
        currency_text.GetComponent<TextMeshProUGUI>().text =  "R$ " + current_currency.ToString();
    }

    public void StartGame() {
        SceneManager.LoadScene("MainGame"); 
    }

    public void Tutorial() {
        SceneManager.LoadScene("Tutorial"); 
    }

}
