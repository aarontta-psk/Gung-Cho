﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionesTutorial : MonoBehaviour
{
    [SerializeField] Transform jugador = null, seccion2 = null, seccion3 = null, seccion4 = null;
    [SerializeField] ActivacionTextosTutorial actTexts = null;
    bool seccion2Esta = false, seccion3Esta = false, seccion4Esta = false;

    public void Continuar()
    {
        if (seccion4Esta) SceneManager.LoadScene(1);
        else
        {
            AsignacionTransform();
            Camera.main.transform.position = new Vector3(jugador.position.x, jugador.position.y + 4, Camera.main.transform.position.z);
        }
    }

    private void AsignacionTransform()
    {
        if (seccion2Esta)
        {
            if (seccion3Esta)
            {
                jugador.transform.position = seccion4.transform.position;
                actTexts.ActivarTextoSeccion4();
                seccion4Esta = true;
            }
            else
            {
                jugador.transform.position = seccion3.transform.position;
                actTexts.ActivarTextoSeccion3();
                seccion3Esta = true;
            }
        }
        else
        {
            jugador.transform.position = seccion2.transform.position;
            actTexts.ActivarTextoSeccion2();
            seccion2Esta = true;
        }
    }
}