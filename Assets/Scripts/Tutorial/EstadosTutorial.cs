﻿using UnityEngine;
using UnityEngine.UI;

//Script 

public class EstadosTutorial : MonoBehaviour
{
    public enum estadoTutorial { primeraSecc, segundaSecc, terceraSecc, cuartaSecc };

    [SerializeField] GameObject button = null, enemigo = null;
    [SerializeField] Estados estados = null;
    //referencia al jugador (y su rigidBody), a los pies, y a todos los powerups
    GameObject jugador = null;
    Rigidbody2D rb = null;
    Suelo pies = null;
    Escudo escudo = null;
    AlargaGancho alargaGancho = null;
    PlataformaNube nube = null;
    SaltoPotenciado botasSalto = null;

    estadoTutorial estadoTuto;
    bool space, aButton, dButton, rightClick, leftClick, wButton, eButton, ganchoAct, botasAct;

    void Start()
    {
        jugador = estados.gameObject;
        pies = jugador.GetComponentInChildren<Suelo>();
        rb = jugador.GetComponent<Rigidbody2D>();
        escudo = jugador.GetComponent<Escudo>();
        alargaGancho = jugador.GetComponent<AlargaGancho>();
        nube = jugador.GetComponent<PlataformaNube>();
        botasSalto = jugador.GetComponent<SaltoPotenciado>();

        estadoTuto = estadoTutorial.primeraSecc;
        button.SetActive(false);
    }

    void Update()
    {
        ComprobacionesTeclas();
    }

    void ComprobacionesTeclas()
    {
        switch (estadoTuto)
        {
            case estadoTutorial.primeraSecc:
                {
                    if (Input.GetKeyDown(KeyCode.Space)) space = true;
                    else if (Input.GetKeyDown(KeyCode.A)) aButton = true;
                    else if (Input.GetKeyDown(KeyCode.D)) dButton = true;

                    if (space && aButton && dButton && rb.velocity.magnitude == 0 && pies.EnSuelo())
                        ActivarBoton();
                }
                break;
            case estadoTutorial.segundaSecc:
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0)) leftClick = true;
                    else if (Input.GetKeyDown(KeyCode.Mouse1)) rightClick = true;

                    if (leftClick && rightClick && jugador.transform.position.y > 35f && pies.EnSuelo()) 
                        ActivarBoton();
                }
                break;
            case estadoTutorial.terceraSecc:
                {
                    if (Input.GetKeyDown(KeyCode.W) && escudo.enabled) wButton = true;
                    else if (Input.GetKeyDown(KeyCode.Q) && nube.enabled) eButton = true;
                    else if (alargaGancho.enabled) ganchoAct = true;
                    else if (botasSalto.enabled) botasAct = true;

                    if (wButton && eButton && ganchoAct && botasAct && pies.EnSuelo())
                        ActivarBoton();
                }
                break;
            case estadoTutorial.cuartaSecc:
                {
                    if ((!enemigo.activeSelf || GameManager.instance.getVidas() == 1) && pies.EnSuelo())
                        ActivarBoton();
                }
                break;
        }
    }

    public void CambioEstado()
    {
        switch (estadoTuto)
        {
            case estadoTutorial.primeraSecc:
                estadoTuto = estadoTutorial.segundaSecc;
                button.SetActive(false);
                break;
            case estadoTutorial.segundaSecc:
                estadoTuto = estadoTutorial.terceraSecc;
                button.SetActive(false);
                break;
            case estadoTutorial.terceraSecc:
                estadoTuto = estadoTutorial.cuartaSecc;
                button.SetActive(false);
                escudo.enabled = false;
                break;
        }
    }

    void ActivarBoton()
    {
        button.SetActive(true);
        rb.velocity = Vector2.zero;
        estados.CambioEstado(estado.Inactivo);
        if (estadoTuto == estadoTutorial.cuartaSecc)
        {
            button.GetComponentInChildren<Text>().text = "NIVEL 1 >>";
            enemigo.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
