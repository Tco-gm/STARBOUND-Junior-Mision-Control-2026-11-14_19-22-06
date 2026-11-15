using UnityEngine;
using UniversityOfGames.ProgressBarToolkit;

public class OxygenSystem : MonoBehaviour
{
    [Header("Configuración de Oxígeno")]
    [Tooltip("Oxígeno máximo (ej. 100)")]
    public float maxOxygen = 100f;
    [Tooltip("Cuánto oxígeno se pierde por segundo")]
    public float depletionRate = 5f;

    [Header("Referencia Visual (Opcional)")]
    [Tooltip("Arrastra aquí tu barra de progreso del Canvas")]
    public ClassicProgressBar oxygenBar;
    
    private float currentOxygen;
    private bool isDepleting = false; // El "interruptor" de la condición

    void Start()
    {
        currentOxygen = maxOxygen;
        UpdateUI();
    }

    void Update()
    {
        // Si la condición se cumple (isDepleting es true), baja el oxígeno
        if (isDepleting && currentOxygen > 0)
        {
            currentOxygen -= depletionRate * Time.deltaTime;

            if (currentOxygen < 0) currentOxygen = 0;

            UpdateUI();

            if (currentOxygen <= 0)
            {
                isDepleting = false;
                Debug.Log("¡Te quedaste sin oxígeno!");
            }
        }
    }

    
    public void ActivarConsumoOxigeno()
    {
        isDepleting = true;
        Debug.Log("Consumo de oxígeno ACTIVADO");
    }

    public void DesactivarConsumoOxigeno()
    {
        isDepleting = false;
        Debug.Log("Consumo de oxígeno DESACTIVADO");
    }

    public void RecargarOxigeno(float cantidad)
    {
        currentOxygen += cantidad;
        if (currentOxygen > maxOxygen) currentOxygen = maxOxygen;
        UpdateUI();
    }


    private void UpdateUI()
    {
        if (oxygenBar != null)
        {
            oxygenBar.FillAmount = currentOxygen / maxOxygen;
        }
    }
}