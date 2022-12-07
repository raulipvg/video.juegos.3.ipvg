using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiocamara : MonoBehaviour
{
    public GameObject ARcamara;
    public GameObject CamaraJuego;
    // Start is called before the first frame update
    public void CambioCamara()
    {
        CamaraJuego.SetActive(true);
        ARcamara.SetActive(false);
        
    }

    public void InicioJuego()
    {
        SceneManager.LoadScene("Escenario 3");
    }
  
}
