using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class modelScript : MonoBehaviour
{
    public GameObject phoneModel;
    [Header("start rotate")]
    public bool startTransition1 = false;
    [Header("switch rotate")]
    public bool startTransition2 = false;

    [Header("cameras")]
    public GameObject vCam_1;

    private void Start()
    {
        vCam_1.transform.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        transition_1(); 
        transition_2();
    }

    void transition_1()
    {
        if (startTransition1)
        {
            phoneModel.transform.DOLocalRotate(new Vector3(0f, 360f, 0f), 2f, RotateMode.FastBeyond360)
                .SetLoops(1);

            phoneModel.transform.DOMoveX(0f, 1f).SetEase(Ease.Linear);
            vCam_1.transform.DOMoveZ(-900f, 1f).SetEase(Ease.Linear);

        }
    }
    void transition_2()
    {
        if(startTransition2)
        {
            phoneModel.transform.DOMoveX(-900, 2f).SetEase(Ease.Linear);
        }
    }
}
