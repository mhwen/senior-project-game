﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public int numBullets = 10;
    public override void Attack()
    {
        Vector3 point = GetAimPoint();

        if (point.Equals(Vector3.zero))
            return;

        Shoot(point);
        player.ApplyForce(-(point - this.transform.position).normalized * recoil);
    }

    private void Shoot(Vector3 point)
    {
        Vector3 direction = point - this.transform.position;
        Ray shootRay = new Ray(this.transform.position, direction);
        Debug.DrawRay(shootRay.origin, shootRay.direction * 100f, Color.green, 1);

        for(int i = 0; i < numBullets; i++)
        {
            Projectile projectile = Instantiate(projectilePrefab);
            Vector3 spreadAngle = new Vector3(Random.Range(-spread.x, spread.x), Random.Range(-spread.y, spread.y), Random.Range(-spread.z, spread.z));
            projectile.FireProjectile(shootRay, spreadAngle);
        }
        
    }
}