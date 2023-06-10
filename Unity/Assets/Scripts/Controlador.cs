using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using S7.Net;

public class Controlador : MonoBehaviour
{
    // PLC
    Plc plc;

    // Pesaje
    public GameObject pesaje;
    private Animator animPesaje;
    // Granulacion
    public GameObject granulacion;
    // Secado
    public GameObject secado;
    // Tamizado
    public GameObject tamizado;
    // Mezclado
    public GameObject mezclado;
    // CyR
    public GameObject cyr;
    private GameObject compactador;
    private Animator animCompactador;
    private GameObject recubrimiento;
    // Empaquetado
    public GameObject empaquetado;
    private Animator animEmpaquetado;
    // Indicadores
    public GameObject indicadores;
    // Hijos
    private GameObject indicadorPesaje;
    private GameObject indicadorGranulacion;
    private GameObject indicadorSecado;
    private GameObject indicadorTamizado;
    private GameObject indicadorMezclado;
    private GameObject indicadorCyR;
    private GameObject indicadorEmpaquetado;
    // Nietos
    private GameObject verde1, verde2, verde3, verde4, verde5, verde6, verde7;
    private GameObject naranja1, naranja2, naranja3, naranja4, naranja5, naranja6, naranja7;
    private GameObject rojo1, rojo2, rojo3, rojo4, rojo5, rojo6, rojo7;

    // Start is called before the first frame update
    void Start()
    {
        // PLC
        plc = new Plc(CpuType.S71500, "192.168.7.10", 0, 1);
        plc.Open();

        // Animaciones
        animPesaje = pesaje.GetComponentInChildren<Animator>(); // Pesaje
        compactador = cyr.transform.GetChild(0).gameObject;
        animCompactador = compactador.GetComponentInChildren<Animator>(); // Compactador
        animEmpaquetado = empaquetado.GetComponentInChildren<Animator>(); // Empaquetado

        // Indicadores
        indicadorPesaje = indicadores.transform.GetChild(0).gameObject;
        indicadorGranulacion = indicadores.transform.GetChild(1).gameObject;
        indicadorSecado = indicadores.transform.GetChild(2).gameObject;
        indicadorTamizado = indicadores.transform.GetChild(3).gameObject;
        indicadorMezclado = indicadores.transform.GetChild(4).gameObject;
        indicadorCyR = indicadores.transform.GetChild(5).gameObject;
        indicadorEmpaquetado = indicadores.transform.GetChild(6).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Stop
        if((bool)plc.Read("I10.0"))
        //if(Input.GetKey(KeyCode.Space))
        {
           rojo1 = indicadorPesaje.transform.GetChild(4).gameObject;
           rojo1.SetActive(true);
           rojo2 = indicadorGranulacion.transform.GetChild(4).gameObject;
           rojo2.SetActive(true);
           rojo3 = indicadorSecado.transform.GetChild(4).gameObject;
           rojo3.SetActive(true);
           rojo4 = indicadorTamizado.transform.GetChild(4).gameObject;
           rojo4.SetActive(true);
           rojo5 = indicadorMezclado.transform.GetChild(4).gameObject;
           rojo5.SetActive(true);
           rojo6 = indicadorCyR.transform.GetChild(4).gameObject;
           rojo6.SetActive(true);
           rojo7 = indicadorEmpaquetado.transform.GetChild(4).gameObject;
           rojo7.SetActive(true);
        }else
        {
           rojo1 = indicadorPesaje.transform.GetChild(4).gameObject;
           rojo1.SetActive(false);
           rojo2 = indicadorGranulacion.transform.GetChild(4).gameObject;
           rojo2.SetActive(false);
           rojo3 = indicadorSecado.transform.GetChild(4).gameObject;
           rojo3.SetActive(false);
           rojo4 = indicadorTamizado.transform.GetChild(4).gameObject;
           rojo4.SetActive(false);
           rojo5 = indicadorMezclado.transform.GetChild(4).gameObject;
           rojo5.SetActive(false);
           rojo6 = indicadorCyR.transform.GetChild(4).gameObject;
           rojo6.SetActive(false);
           rojo7 = indicadorEmpaquetado.transform.GetChild(4).gameObject;
           rojo7.SetActive(false);
        }

        // Paro
        if((bool)plc.Read("I10.1"))
        //if(Input.GetKey(KeyCode.Space))
        {
           naranja1 = indicadorPesaje.transform.GetChild(3).gameObject;
           naranja1.SetActive(true);
           naranja2 = indicadorGranulacion.transform.GetChild(3).gameObject;
           naranja2.SetActive(true);
           naranja3 = indicadorSecado.transform.GetChild(3).gameObject;
           naranja3.SetActive(true);
           naranja4 = indicadorTamizado.transform.GetChild(3).gameObject;
           naranja4.SetActive(true);
           naranja5 = indicadorMezclado.transform.GetChild(3).gameObject;
           naranja5.SetActive(true);
           naranja6 = indicadorCyR.transform.GetChild(3).gameObject;
           naranja6.SetActive(true);
           naranja7 = indicadorEmpaquetado.transform.GetChild(3).gameObject;
           naranja7.SetActive(true);
        }else
        {
           naranja1 = indicadorPesaje.transform.GetChild(3).gameObject;
           naranja1.SetActive(false);
           naranja2 = indicadorGranulacion.transform.GetChild(3).gameObject;
           naranja2.SetActive(false);
           naranja3 = indicadorSecado.transform.GetChild(3).gameObject;
           naranja3.SetActive(false);
           naranja4 = indicadorTamizado.transform.GetChild(3).gameObject;
           naranja4.SetActive(false);
           naranja5 = indicadorMezclado.transform.GetChild(3).gameObject;
           naranja5.SetActive(false);
           naranja6 = indicadorCyR.transform.GetChild(3).gameObject;
           naranja6.SetActive(false);
           naranja7 = indicadorEmpaquetado.transform.GetChild(3).gameObject;
           naranja7.SetActive(false);
        }
        
        // Pesaje
        if((bool)plc.Read("I10.2"))
        //if(Input.GetKey(KeyCode.Space))
        {
            pesaje.SetActive(true);
            animPesaje.Play("Ingredientes");
            verde1 = indicadorPesaje.transform.GetChild(2).gameObject;
            verde1.SetActive(true);
        }else
        {
            pesaje.SetActive(false);
            animPesaje.Play("Nada");
            verde1 = indicadorPesaje.transform.GetChild(2).gameObject;
            verde1.SetActive(false);
        }
        
        // Granulacion
        if((bool)plc.Read("M8.6"))
        //if(Input.GetKey(KeyCode.Space))
        {
            granulacion.SetActive(true);
            verde2 = indicadorGranulacion.transform.GetChild(2).gameObject;
            verde2.SetActive(true);
        }else
        {
           granulacion.SetActive(false);
           verde2 = indicadorGranulacion.transform.GetChild(2).gameObject;
           verde2.SetActive(false);
        }

        // Secado
        if((bool)plc.Read("Q4.6"))
        //if(Input.GetKey(KeyCode.Space))
        {
            secado.SetActive(true);
            verde3 = indicadorSecado.transform.GetChild(2).gameObject;
            verde3.SetActive(true);
        }else
        {
           secado.SetActive(false);
           verde3 = indicadorSecado.transform.GetChild(2).gameObject;
           verde3.SetActive(false);
        }

        // Tamizado
        if((bool)Input.GetKey(KeyCode.T))
        {
            tamizado.SetActive(true);
            verde4 = indicadorTamizado.transform.GetChild(2).gameObject;
            verde4.SetActive(true);
        }else
        {
           tamizado.SetActive(false);
           verde4 = indicadorTamizado.transform.GetChild(2).gameObject;
           verde4.SetActive(false);
        }

        // Mezclado
        if((bool)plc.Read("I10.5"))
        //if(Input.GetKey(KeyCode.Space))
        {
            mezclado.SetActive(true);
            verde5 = indicadorMezclado.transform.GetChild(2).gameObject;
            verde5.SetActive(true);
        }else
        {
           mezclado.SetActive(false);
           verde5 = indicadorMezclado.transform.GetChild(2).gameObject;
           verde5.SetActive(false);
        }

        // C y R
        if((bool)plc.Read("Q4.2"))
        //if(Input.GetKey(KeyCode.Space))  // Banda
        {
            cyr.SetActive(true);
            verde6 = indicadorCyR.transform.GetChild(2).gameObject;
            verde6.SetActive(true);

            //if((bool)plc.Read("Q4.3"))
            if(Input.GetKey(KeyCode.S))  // Compactador
            {
                compactador = cyr.transform.GetChild(0).gameObject;
                animCompactador.Play("Compactacion");
            }else
            {
                animCompactador.Play("Nada");
            }
            
            if((bool)plc.Read("Q4.4"))
            //if(Input.GetKey(KeyCode.D))  // Recubrimiento
            {
                recubrimiento = cyr.transform.GetChild(1).gameObject;
                recubrimiento.SetActive(true);
            }else
            {
                recubrimiento.SetActive(false);
            }
        }else
        {
            cyr.SetActive(false);
            verde6 = indicadorCyR.transform.GetChild(2).gameObject;
            verde6.SetActive(false);
        }       

        // Empaquetado
        if((bool)plc.Read("Q4.7"))
        //if(Input.GetKey(KeyCode.Space))
        {
            empaquetado.SetActive(true);
            animEmpaquetado.Play("Empaquetado");
            verde7 = indicadorEmpaquetado.transform.GetChild(2).gameObject;
            verde7.SetActive(false);
        }else
        {
            empaquetado.SetActive(false);
            animEmpaquetado.Play("Nada");
            verde7 = indicadorEmpaquetado.transform.GetChild(2).gameObject;
            verde7.SetActive(false);
        }   
    }
}





