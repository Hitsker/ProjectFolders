using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform[] _hands;
    [SerializeField] private Transform[] _legs;

    [SerializeField] private Renderer _hair;

    public void ScaleHead(float value)
    {
        _head.localScale=new Vector3(value, value, value);
    }

    public void ScaleHands(float value)
    {
        foreach (var hand in _hands)
        {
            hand.localScale=new Vector3(value, value, value);
        }
    }

    public void ScaleLegs(float value)
    {
        foreach (var leg in _legs)
        {
            leg.localScale=new Vector3(value, value, value);
        }
    }

    public void SetHairTexture(Texture2D tex)
    {
        _hair.material.SetTexture("_MainTex", tex);
    }
}
