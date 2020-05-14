﻿using UnityEngine;

//Control de la vida del jugador

public class VidaJugador : MonoBehaviour
{
    [SerializeField] float tiempoInvulnerable = 3f; //tiempo de invulnerabilidad
    [SerializeField] AgitarCamara cameraShake = null;
    EfectoJugadorDañado efectoJugadorDañado;
    bool invulnerable = false; //booleano de invulnerabilidad 

    private void Start()
    {
        efectoJugadorDañado = GetComponent<EfectoJugadorDañado>();
        //efectoJugadorDañado.SetTiempoInvulnerable(tiempoInvulnerable); //se indica el tiempo de invulnerabilidad al script que lo indica en pantalla
    }

    public void EliminaVidaJugador() //método para la eliminación de vidas
    {
        Estados estados = GetComponent<Estados>();

        //si el jugador no es invulnerable, y no está moviendose con el dash/gancho
        if (estados != null && !invulnerable && estados.Estado() != estado.Dash)
        {
            if (GameManager.instance != null) //si hay GM
            {
                GameManager.instance.EliminaVidaJugador(); //quita una vida

                cameraShake.enabled = true;

                if (transform.position != GameManager.instance.CheckPoint()) //si no ha muerto
                {
                    invulnerable = true; //lo hacemos invulnerable
                    efectoJugadorDañado.enabled = true;  //mostramos la invulnerabilidad en pantalla
                    Invoke("HacerVulnerable", tiempoInvulnerable); //en 'x' tiempo, volverá a ser vulnerable
                }
            }
        }
    }

    public void EliminaVidaObstaculos()
    {
        if (!invulnerable)
        {
            if (GameManager.instance != null) //si hay GM
            {
                GameManager.instance.EliminaVidaJugador(); //quita una vida

                cameraShake.enabled = true;

                if (transform.position != GameManager.instance.CheckPoint()) //si no ha muerto
                {
                    invulnerable = true; //lo hacemos invulnerable
                    efectoJugadorDañado.enabled = true;
                    Invoke("HacerVulnerable", tiempoInvulnerable); //en 'x' tiempo, volverá a ser vulnerable
                }
            }
        }
    }

    public void HacerVulnerable() //método que permite hacer que el jugador vuelva a ser vulnerable
    {
        invulnerable = false; //pasa a ser vulnerable
        efectoJugadorDañado.enabled = false;
    }

    //NO SE PARA QUE ES ESTO LOL
    //public void HacerVulnerable2() //método que permite hacer que el jugador vuelva a ser vulnerable
    //{
    //    invulnerable = false; //pasa a ser vulnerable
    //    efectoJugadorDañado.enabled  = false;
    //}

    public void HacerInvulnerable() //método que permite hacer que el jugador vuelva a ser invulnerable
    {
        invulnerable = true; //pasa a ser invulnerable
    }

    public float GetTiempoInvulnerable()
    {
        return tiempoInvulnerable;
    }
}
