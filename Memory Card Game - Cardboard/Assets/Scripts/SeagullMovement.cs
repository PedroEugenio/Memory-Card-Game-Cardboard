﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullMovement : MonoBehaviour {

    public GameObject seagull;
    public Transform origin;
    

    private Transform target;
    private int pointIndex=0;

    public float velocity = 10f;
    public int numberOfSeagulls=20;
    public float distance = 5;

    private int[] order;
    private static int rangeMax;

    private int [] generateOrderArray()
    {
        int numObjects = SeagullPoints.points.Length;
        rangeMax = numObjects;
        order = new int[numObjects];
        for (int i = 0; i < numObjects; i++)
        {
            order[i] = i;
        }
        return order;
    }

    private void Start()
    {
        order = generateOrderArray();
        //ManagerGame.Shuffle(order, SeagullPoints.points.Length);
        target = SeagullPoints.points[0];
    }

    private void Update()
    {
        Vector3 directions = target.position - transform.position;
        transform.Translate(directions.normalized * velocity * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.FromToRotation(Vector3.up, directions);
        if (Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            NextPoint();
        }

    }

    void NextPoint()
    {
        pointIndex++;
        if (pointIndex == SeagullPoints.points.Length)
            pointIndex = 0;
        target = SeagullPoints.points[order[pointIndex]];
    }
}