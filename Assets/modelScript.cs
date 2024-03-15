using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class modelScript : MonoBehaviour
{
    public GameObject phoneModel;
    [Header("transition 1")]
    public bool startTransition1 = false;

    [Header("transition 2")]
    public bool startTransition2 = false;
    public GameObject[] transition2textFeatures;

    [Header("transition 3")]
    public bool startTransition3 = false;

    [Header("transition 4")]
    public bool startTransition4 = false;

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
        transition_3();
        transition_4();
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
        if (startTransition2)
        {
            // Move the phone model
            phoneModel.transform.DOMoveX(-250, 2f).SetEase(Ease.Linear);

            // Sequentially move each text element with a delay
            for (int i = 0; i < transition2textFeatures.Length; i++)
            {
                float delay = i * 0.5f;

                RectTransform rectTransform = transition2textFeatures[i].GetComponent<RectTransform>();
                rectTransform.DOAnchorPosX(-500, 1f).SetDelay(delay).SetEase(Ease.Linear);
            }

            startTransition1 = false;
        }
    }
    void transition_3()
    {
        if(startTransition3)
        {
            phoneModel.transform.DOMoveX(-800, 1.5f).SetEase(Ease.Linear);

            startTransition2 = false;

            for (int i = 0; i < transition2textFeatures.Length; i++)
            {
                float delay = i * 0.5f; 

                RectTransform rectTransform = transition2textFeatures[i].GetComponent<RectTransform>();
                rectTransform.DOAnchorPosX(500, 1f).SetDelay(delay).SetEase(Ease.Linear);
            }
        }
    }
    void transition_4()
    {

    }



}
