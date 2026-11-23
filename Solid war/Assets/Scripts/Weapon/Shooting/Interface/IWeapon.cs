using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon.Shooting.Interface
{
    public interface IWeapon
    {
        void ShootingReg(UnityEngine.Vector2 direction);
        void ShootingVisual(UnityEngine.Vector2 direction, RaycastHit2D hit);

    }
}
