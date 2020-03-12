using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sam Ferstein
 * RedBullet.cs
 * Assignment 8
 * This is one of the conrete classes for the Template Pattern.
 */

public class RedBullet : Bullet
{
    public bool isRed;

    public override bool IsRed()
    {
        return isRed;
    }
}
