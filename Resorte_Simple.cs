﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resorte_Simple : MonoBehaviour
{
    public float m = 1.5f;
    public float am = 0.08f;
    public float k = 60f;

    float t = 0;
    public float vx = 100f;
    float K1, K2, K3, K4, L1, L2, L3, L4;
    float h = 0.1f;
    Vector3 posx;

    // Start is called before the first frame update
    void Start()
    {
        posx = new Vector3(30, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        runge();
        gameObject.GetComponent<Transform>().position = posx;

    }

    void runge()
    {
        K1 = h * vx;
        L1 = h * func(t, posx.x, vx);
        K2 = h * (vx + (L1 / 2));
        L2 = h * func(t + (h / 2), posx.x + (K1 / 2), vx + (L1 / 2));
        K3 = h * (vx + (L2 / 2));
        L3 = h * func(t + (h / 2), posx.x + (K2 / 2), vx + (L2 / 2));
        K4 = h * (vx + L3);
        L4 = h * func(t + h, posx.x + K3, vx + L3);

        t = t + h;

        posx.x = posx.x + ((K1 + 2 * K2 + 2 * K3 + K4) / 6);
        vx = vx + ((L1 + 2 * L2 + 2 * L3 + L4) / 6);
    }

    float func(float t, float x1, float vx1)
    {
        float res;
        res = (-am * vx1 - k * x1) / m;
        return res;
    }


}
