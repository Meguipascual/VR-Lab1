using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Console : MonoBehaviour
{

    public TextMeshProUGUI consoleText; // O public Text consoleText;
    private System.Collections.Generic.List<string> logMessages = new System.Collections.Generic.List<string>();
    public int maxMessages = 10; // Máximo de líneas a mostrar

    private void Awake()
    {
        if (consoleText == null)
        {
            Debug.LogError("Console Text UI no asignado en el Inspector.");
            return;
        }
        // Limpiar el texto inicial
        logMessages.Clear();
        consoleText.text = "";

        // Aquí es donde "enganchamos" nuestro método a Debug.Log
        Application.logMessageReceived += HandleLog;
        //Application.logMessageReceivedThreaded += HandleLog;
    }

    private void OnDestroy()
    {
        // Es importante desenganchar el listener al destruir
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        // Añadir el mensaje al historial
        logMessages.Add($"[{type}] {logString}");

        // Mantener solo los últimos 'maxMessages'
        if (logMessages.Count > maxMessages)
        {
            logMessages.RemoveAt(0); // Elimina el mensaje más antiguo
        }

        // Actualizar el texto del UI
        consoleText.text = string.Join("\n", logMessages);
    }
}
