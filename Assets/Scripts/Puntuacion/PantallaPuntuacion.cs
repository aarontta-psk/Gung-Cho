using UnityEngine;
using UnityEngine.UI;

public class PantallaPuntuacion : MonoBehaviour
{
    [SerializeField] Text muertes, enemigos, puntuacionNivel1, puntuacionNivel2;
    bool reset = false;

    void Start()
    {
        SetEstadisticas();
    }

    void Update()
    {
        if (reset)
        {
            SetEstadisticas();
            reset = false;
        }
    }

    void SetEstadisticas()
    {
<<<<<<< HEAD
        //muertes.text = Puntuacion.GetMuertes().ToString();
        //enemigos.text = Puntuacion.GetEnemEliminados().ToString();
=======
>>>>>>> cb52dded081d2defb0d63bda6727a14191a85599
        puntuacionNivel1.text = Puntuacion.GetPuntuacionNivel1().ToString();
        puntuacionNivel2.text = Puntuacion.GetPuntuacionNivel2().ToString();
    }

    public void ResetPantallaPuntuación()
    {
        Puntuacion.ResetPuntuacion();
        reset = true;
    }
}
