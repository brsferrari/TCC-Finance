using System.Collections;
using System.Collections.Generic;
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

    [Header("Date & Time UI Settings")]
    public TextMeshProUGUI Date;
    public TextMeshProUGUI Time;

    [Header("Currency Settings")]
    public TextMeshProUGUI UICurrency;
    public TextMeshProUGUI PCCurrency;

    private void OnEnable() 
    {
        TimeHandler.OnDateTimeChanged += UpdateDateTime;
        CurrencyHandler.OnDoletasChanged += UpdateCurrencyText;
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

        // Select a Random Event
        if (dateTime.IsNewDay()) {
            int randomInt = Random.Range(0, 10000);
            Debug.Log(randomInt);
        }
    }

    private void UpdateCurrencyText(string newDoletasValue)
    {
        // Atualiza o texto Currency com o novo valor de doletas
        UICurrency.text = newDoletasValue;
        PCCurrency.text = newDoletasValue;
    }

    public void OpenCallendar() {
        Callendar.SetActive(true);
        UI.SetActive(false);
        Moveis.SetActive(false);
    }
}
