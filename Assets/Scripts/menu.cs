using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] public TMP_InputField input_nombreUsuario;
    public string escena;

    private void Start()
    {
        input_nombreUsuario.text = PlayerPrefs.GetString("usuario");
    }
    public void setUsuario()
    {
        string user = input_nombreUsuario.text;

            if (string.IsNullOrEmpty(user))
            {
                Debug.Log("Sin nombre de usuario");
            }
            else
            {
                Debug.Log(user);
                PlayerPrefs.SetString("usuario", user);
                SceneManager.LoadScene(escena);
            }
      

        
    }
}
