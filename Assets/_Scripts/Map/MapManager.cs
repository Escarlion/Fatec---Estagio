using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField] List<GameObject> phases = new List<GameObject>();

    [SerializeField] GameObject introTransition;

    void Start()
    {
        CheckPhasesStatus();
        Destroy(Instantiate(introTransition, this.transform), 1.5f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ClearPhaseStatus();
        }
    }



    //Checa quais fases foram completadas e habilita o botão delas 
    private void CheckPhasesStatus()
    {
        DisableAllPhases();

        int phasesCompleted = PlayerPrefs.GetInt("PhasesCompleted"); ///Gerado na classe PhaseManager
        Debug.Log("valor na player prefs: "+phasesCompleted);

        for (int i = 0; i <= phasesCompleted; i++) //Sempre vai manter pelo menos a 1a fase habilitada
        {
            phases[i].GetComponent<Button>().interactable = true;
        }         
    }

    //Desabilita todos os botões das fases por segurança
    private void DisableAllPhases()
    {
        foreach (GameObject phase in phases) phase.GetComponent<Button>().interactable = false;
    }

    private void ClearPhaseStatus() //apenas para testes
    {
        PlayerPrefs.SetInt("PhasesCompleted", 0);
    }
}
