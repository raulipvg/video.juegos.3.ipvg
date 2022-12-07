using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public TMP_Text Tiempo;
    [SerializeField] public TMP_Text Nombre;
    private int time = 30;
    private int tiempoInicial;
    public string escena;


    void Start()
    {
        Nombre.text = PlayerPrefs.GetString("usuario");
        tiempoInicial = time;
        PlayerPrefs.SetInt("tiempo", tiempoInicial);

        Time.timeScale = 1;  //Juego Iniciado
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        PlayerPrefs.SetInt("tiempo", time);
        yield return new WaitForSeconds(1);
        time--;
        //PlayerPrefs.SetInt("tiempo", tiempoInicial - time);
        // SI PASA DEL TIEMPO ESTABLECIDO, FIN DEL JUEGO
        if (time <= 0)
        {
            StopCoroutine(timer());
            Fin(2);
        }
        Tiempo.text = Convert.ToString(PlayerPrefs.GetInt("tiempo"));
        //Debug.Log("Te quedan: " + time);
        yield return timer();
    }
    public void Fin(int i)
    {
        if(i ==1)
        {
            Debug.Log("Llegaste a la meta");
            FindObjectOfType<Audio>().PlayFinGanar();
            FindObjectOfType<Audio>().StopSound();
            new WaitForSeconds(2);

        }
        else if( i == 2)
        {
            Debug.Log("Fin del tiempo");
            FindObjectOfType<Audio>().PlayFinPerder();
            FindObjectOfType<Audio>().StopSound();
            new WaitForSeconds(2);
        }
        SceneManager.LoadScene(escena);
    }
}
