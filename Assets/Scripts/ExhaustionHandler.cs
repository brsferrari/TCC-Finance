using UnityEngine;
using UnityEngine.SceneManagement;

public class ExhaustionHandler : MonoBehaviour
{
    [Header("Objetos para Exhaustion Bar")]
    public static float total_parts = 244.0f;
    public static float total_fill = 1.0f;
    private static float current_value = total_fill;
    private static float fill_step = total_fill / total_parts;
    public static event System.Action<float> OnExhaustionChanged;

    public static string GetValue() {
        return (current_value.ToString("0.0000"));
    }
    
    public static void DecreaseFillAmount(bool click = false) {
        if (!IsGameOver()) {
            if (!click) {
                current_value -= fill_step;
            } else {
                current_value -= (fill_step/3);
            }
        } else {
            GameOver();
        }
        OnExhaustionChanged?.Invoke(current_value);
    }

    public static void IncreaseFillAmount() {
        if (!IsGameOver() && current_value < total_fill) {
            current_value += (fill_step*2);
        } else if (!IsGameOver() && current_value >= total_fill){
            current_value = total_fill;
        } else {
            GameOver();
        }
        OnExhaustionChanged?.Invoke(current_value);
    }

    private static void GameOver() {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single); 
    }

    private static bool IsGameOver() {
        return current_value <= 0;
    }
}
