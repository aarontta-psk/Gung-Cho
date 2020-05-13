﻿using UnityEngine;
using UnityEngine.UI;


public class Estadisticas : MonoBehaviour
{
    private int numSaltos = 0;
    private int numDash = 0;
    private int numGanchos = 0;
    private int numEnemigosDerrotados = 0;
    private int numMuertes = 0;
    [SerializeField] float tiempoJugado = 0;
    static Estadisticas instance = null;

    private void Awake()
    {
        //SINGLETON
        if (instance == null) //si no hay instancia
        {
            instance = this; //la creamos
            DontDestroyOnLoad(gameObject); //evitamos que se destruya entre escenas
        }
        else //en caso contrario
        {
            Destroy(gameObject); //destruimos la instancia
        }

        if (!PlayerPrefs.HasKey("saltos")) PlayerPrefs.SetInt("saltos", 0);
        else numSaltos = PlayerPrefs.GetInt("saltos");

        if (!PlayerPrefs.HasKey("dash")) PlayerPrefs.SetInt("dash", 0);
        else numDash = PlayerPrefs.GetInt("dash");

        if (!PlayerPrefs.HasKey("ganchos")) PlayerPrefs.SetInt("ganchos", 0);
        else numGanchos = PlayerPrefs.GetInt("ganchos");

        if (!PlayerPrefs.HasKey("enemigos")) PlayerPrefs.SetInt("enemigos", 0);
        else numEnemigosDerrotados = PlayerPrefs.GetInt("enemigos");

        if (!PlayerPrefs.HasKey("muertes")) PlayerPrefs.SetInt("muertes", 0);
        else numMuertes = PlayerPrefs.GetInt("muertes");

        if (!PlayerPrefs.HasKey("tiempo")) PlayerPrefs.SetFloat("tiempo", 0);
        else tiempoJugado = PlayerPrefs.GetFloat("tiempo");
    }

    public void Salto()
    {
        numSaltos++;
        PlayerPrefs.SetInt("saltos", numSaltos);
    }

    public void Dash()
    {
        numDash++;
        PlayerPrefs.SetInt("dash", numDash);
    }

    public void Gancho()
    {
        numGanchos++;
        PlayerPrefs.SetInt("ganchos", numGanchos);
    }

    public void Muerte()
    {
        numMuertes++;
        PlayerPrefs.SetInt("muertes", numMuertes);
    }

    public void Enemigo()
    {
        numEnemigosDerrotados++;
        PlayerPrefs.SetInt("muertes", numMuertes);
    }

    //public Text saltos;
    //private void Update()
    //{
    //    //saltos.text = ""+ numSaltos;
    //}

    public void Guardar()
    {
        PlayerPrefs.SetInt("saltos", numSaltos);
        PlayerPrefs.SetInt("dash", numDash);
        PlayerPrefs.SetInt("ganchos", numGanchos);
        PlayerPrefs.SetInt("enemigos", numEnemigosDerrotados);
        PlayerPrefs.SetInt("muertes", numMuertes);
        PlayerPrefs.SetFloat("tiempo", tiempoJugado);

        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        Guardar();
    }
}
