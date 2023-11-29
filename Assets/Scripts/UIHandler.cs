using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DPUtils.Systems.DateTime;

public class UIHandler : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject Callendar;
    public GameObject UI;
    public GameObject Moveis;
    public GameObject randomEvent;
    public EventHandler eventHandler;

    [Header("Date & Time UI Settings")]
    public TextMeshProUGUI Date;
    public TextMeshProUGUI Time;

    [Header("Currency Settings")]
    public TextMeshProUGUI UICurrency;
    public TextMeshProUGUI PCCurrency;

    [Header("Currency Settings")]
    public Image UIExBar;
    public Image PCExBar;

    private int days_without_re = 1;

    private void Start() 
    {
        TimeHandler.OnDateTimeChanged += UpdateDateTime;
        CurrencyHandler.OnDoletasChanged += UpdateCurrencyText;
        ExhaustionHandler.OnExhaustionChanged += UpdateExhaustionFill;
    }
    
    private void UpdateDateTime(DateTime dateTime)
    {
        if (dateTime.Date > 9) {
            Date.text = dateTime.Date.ToString();
        } else {
            Date.text = '0' + dateTime.Date.ToString();
        };
        if (dateTime.Hour > 9) {
            if (dateTime.Minutes > 9) {
                Time.text = dateTime.Hour.ToString() + ":" + dateTime.Minutes.ToString();
            } else {
                Time.text = dateTime.Hour.ToString() + ":0" + dateTime.Minutes.ToString();
            }
        } else {
            if (dateTime.Minutes > 9) {
                Time.text = '0' + dateTime.Hour.ToString() + ":" + dateTime.Minutes.ToString();
            } else {
                Time.text = '0' + dateTime.Hour.ToString() + ":0" + dateTime.Minutes.ToString();
            }
        }

        // Updating the Exhaustion Bar
        if (TimeHandler.is_recovering == false)
        {
            ExhaustionHandler.DecreaseFillAmount();
        }
        else if (TimeHandler.is_recovering == true)
        {
            ExhaustionHandler.IncreaseFillAmount();
        }

        // Select a Random Event
        if (dateTime.IsNewDay()) {
            TimeHandler.total_days += 1; 
            days_without_re += 1;
            int randomInt = 0;
            // If is not first week, choose a random event
            if (TimeHandler.total_days > 7 && days_without_re != 0 && days_without_re != 1) {
                if (days_without_re >= 7) {
                    randomInt = Random.Range(2, 8); // 66%
                } else {
                    randomInt = Random.Range(1, 50000); // 10%
                }
                if (EhPrimo(randomInt)) {
                    days_without_re = 0;
                    if (TimeHandler.is_recovering == true) {
                        eventHandler.CloseBed();
                    }
                    randomEvent.SetActive(true);
                    RandomEvent();
                }
            }
        }
    }

    private void UpdateCurrencyText(string newDoletasValue)
    {
        // Atualiza o texto Currency com o novo valor de doletas
        UICurrency.text = newDoletasValue;
        PCCurrency.text = newDoletasValue;
    }

    private void UpdateExhaustionFill(float newFillValue) {
        RectTransform uiExBarRect = UIExBar.GetComponent<RectTransform>();
        RectTransform pcExBarRect = PCExBar.GetComponent<RectTransform>();

        // Get the current anchorMax values
        Vector2 uiExBarAnchorMax = uiExBarRect.anchorMax;
        Vector2 pcExBarAnchorMax = pcExBarRect.anchorMax;

        // Change only the x-coordinate
        uiExBarAnchorMax.x = newFillValue;
        pcExBarAnchorMax.x = newFillValue;

        // Set the modified anchorMax values back to the RectTransforms
        uiExBarRect.anchorMax = uiExBarAnchorMax;
        pcExBarRect.anchorMax = pcExBarAnchorMax;
    }

    public void OpenCallendar() {
        Callendar.SetActive(true);
        UI.SetActive(false);
        Moveis.SetActive(false);
    }

    public bool EhPrimo(int numero)
    {
        if (numero <= 1)
        {
            return false;
        }

        for (int i = 2; i <= Mathf.Sqrt(numero); i++)
        {
            if (numero % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    public void RandomEvent() {
        CurrencyHandler.DeacreseCurrency(CurrencyHandler.GetDoletasValue()*30/100);
    }
}
