using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MenuPanel;
    public bool EstaPausado = false;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(EstaPausado)
            {
                MenuPanel.SetActive(true);
                Time.timeScale = 0f;
                EstaPausado = false;
            }

            else
            {
                MenuPanel.SetActive(false);
                Time.timeScale = 1f;
                EstaPausado = true;

            }
        }
    }

    public void Pausa()
    {
        MenuPanel.SetActive(true);
        Time.timeScale = 0f;
        EstaPausado = false;

    }

    public void Continuar()
    {
        MenuPanel.SetActive(false);
        Time.timeScale = 1f;
        EstaPausado = true;

    }

    public void Salir()
    {
      Application.Quit();
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("MenúPrincipal");

    }

    public void VolverJuego()
    {
        SceneManager.LoadScene(1);
    }
}
