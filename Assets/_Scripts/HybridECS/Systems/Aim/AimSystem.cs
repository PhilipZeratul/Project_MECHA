﻿using Unity.Entities;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;


namespace ProjectMecha
{
    [UpdateInGroup(typeof(CalculatePosition))]
    public class AimSystem : ComponentSystem
    {
        private struct Group
        {
            public int Length;
            public ComponentArray<Rotation2D> Rotation;
            [ReadOnly] public ComponentArray<Position2D> Position;
            [ReadOnly] public ComponentArray<Aim> Aim;
        }
        [Inject] private Group group;


        protected override void OnUpdate()
        {
            for (int i = 0; i < group.Length; i++)
            {
                group.Aim[i].RotationZ = Mathf.Rad2Deg * math.atan2(group.Aim[i].Position.y - group.Position[i].Global.y, group.Aim[i].Position.x - group.Position[i].Global.x);
                group.Rotation[i].GlobalZ = group.Aim[i].RotationZ;
            }
        }
    }
}