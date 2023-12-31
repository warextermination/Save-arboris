using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DaņoPersonaje : MonoBehaviour
{

    public int MaxVida = 100;
    public int SaludActual;

    public float knockbackForce = 5.0f;
    public float DuracionRetroceso = 0.5f;

    private Rigidbody playerRigidbody;
    private bool TomandoDaņo;

    private void Start()
    {
        SaludActual = MaxVida;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void TomarDaņo(int Daņo)
    {
        if (!TomandoDaņo)
        {
            SaludActual -= Daņo;
            TomandoDaņo = true;


            Vector3 RetrocesoDirection = -(transform.forward + Vector3.up).normalized;
            playerRigidbody.AddForce(RetrocesoDirection * knockbackForce, ForceMode.Impulse);

            Invoke(nameof(FinaliceRetroceso), DuracionRetroceso);
        }
    }

    private void FinaliceRetroceso()
    {
        TomandoDaņo = false;
    }

    private void Update()
    {
        if (SaludActual <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}