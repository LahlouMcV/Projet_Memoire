using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField] VehicleManager _VehicleManager;
    [SerializeField] Camera WeaponCamera;
    [SerializeField] GameObject WeaponBullet;
    RaycastHit hit;
    private bool Shot = true;

    public void ShootWeapon(float input)
    {
        Ray ray = WeaponCamera.ScreenPointToRay(new Vector3(WeaponCamera.pixelWidth / 2, WeaponCamera.pixelHeight / 2));
        if (Physics.Raycast(ray, out hit, _VehicleManager._VehicleStats.WeaponRange, LayerMask.GetMask("Ground")) && Shot && input != 0)
        {
            Shot = false;

            //Spawn Shot Feedback

            Invoke("SpawnExplosion", 0.25f);
            Invoke("Reload", _VehicleManager._VehicleStats.RateOfFire);
        }
    }

    private void SpawnExplosion()
    {
        Instantiate(WeaponBullet, hit.point, Quaternion.identity);
    }

    private void Reload()
    {
        Shot = true;
    }
}