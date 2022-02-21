using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenFun : GameBehaviour
{
    public GameObject player;
    public float moveDistance = 3f;
    public float tweenTime = 0.5f;
    public Ease moveEase;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.transform.DOMoveZ(player.transform.position.z + moveDistance, tweenTime).SetEase(moveEase);

            DOEffects();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.transform.DOMoveZ(player.transform.position.z - moveDistance, tweenTime).SetEase(moveEase);
            DOEffects();
        }

        if (Input.GetKeyDown(KeyCode.U))
            {
            _UI.UpdateScore(10);
        }
    }


    void DOEffects()
    {
        ChangeColour();
        CameraShake();
        ChangeScale();
    }

    void ChangeColour()
    {
        player.GetComponent<Renderer>().material.DOColor(GetRandomColour(), tweenTime);
    }

    void CameraShake()
    {
        Camera.main.DOShakePosition(tweenTime * 2, 0.4f);
    }

    void ChangeScale()
    {
        player.transform.DOPunchScale(Vector3.one * 2, tweenTime).OnComplete(() => player.transform.DOPunchScale(Vector3.one, tweenTime/2));

    }
}
