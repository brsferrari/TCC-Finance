using UnityEngine;

public class CurrencyHandler : MonoBehaviour
{
    // Objetos para modificação
    [Header("Objetos para Alteração da Moeda")]
    public static float IncreaseByClick = 00.0100f;
    public static float IncreaseCurrencyExtra = 00.0000f; 
    // Objetos privados
    private static float doletas = 00.0000f;
    private static string doletas_text;

    //Eventos
    public static event System.Action<string> OnDoletasChanged;

    void Start() {
        doletas = 00.0000f;
        IncreaseByClick = 00.0100f;
    }

    // Métodos
    public static void GetDoletas() {
        doletas_text = ("R$ " + doletas.ToString("0.0000"));
    }

    public static float GetDoletasValue() {
        return doletas;
    }

    public static void IncreaseCurrency() {
        doletas = doletas + IncreaseByClick + IncreaseCurrencyExtra;
        GetDoletas();
        OnDoletasChanged?.Invoke(doletas_text);
    }

    public static void DeacreseCurrency(float ValueToDecrease) {
        doletas = doletas - ValueToDecrease;
        GetDoletas();
        OnDoletasChanged?.Invoke(doletas_text);
    }
}
