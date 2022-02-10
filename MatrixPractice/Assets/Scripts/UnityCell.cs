using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCell : MonoBehaviour
{
    public GameObject[] cubeStatus;
    NoMonoCell nonMono = new NoMonoCell();
    public void SetStatus(NoMonoCell.Status status)
    {
        for (int i = 0; i < cubeStatus.Length; i++)
        {
            if (i == (int)status)
            {
                cubeStatus[i].SetActive(true);
            }
            else
            {
                cubeStatus[i].SetActive(false);
            }
        }
    //    Debug.Log("setStatus Working");
    }
    void Start()
    {
        nonMono.statusUpdated += SetStatus;
       // nonMono.setStatus(NoMonoCell.Status.None);
      //  Debug.Log((int)nonMono.getStatus());

        SetStatus(NoMonoCell.Status.None);
    }

    public void setNonMono(NoMonoCell nonmono)
    {
        this.nonMono = nonmono;
    }    

    private void OnMouseDown()
    {
        nonMono.statusUpdated += SetStatus;
        nonMono.CellInteraction();

    }
    private void OnDestroy()
    {
        nonMono.statusUpdated -= SetStatus;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
