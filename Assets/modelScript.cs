using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class modelScript : MonoBehaviour
{
    public GameObject phoneModel;

    public bool startRotate = false;
    public Vector3 startLocation;

    public bool switchPhone = false;

    private void Start()
    {
        phoneModel.transform.localPosition = startLocation;
    }

    private void Update()
    {
        rotatePhoneModel();
    }

    void rotatePhoneModel()
    {
        if (startRotate)
        {
            phoneModel.transform.DOLocalRotate(new Vector3(0f, 360f, 0f), 1f, RotateMode.FastBeyond360)
                .SetLoops(1, LoopType.Restart);

            phoneModel.transform.DOMoveX(0f, 1f).SetEase(Ease.Linear);
        }
    }
}
