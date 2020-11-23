using System;
using System.Collections.Generic;
using System.Linq;
using Enum;
using Interface;
using UnityEngine;
using View;

namespace Extension
{
    public static partial class BuilderExtension
    {
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject AddRigitBody(this GameObject gameObject, float mass,
            CollisionDetectionMode                            collisionDetectionMode, bool isKinematic)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody>();
            component.mass = mass;
            component.collisionDetectionMode = collisionDetectionMode;
            return gameObject;
        }

        public static GameObject AddSphereCollider(this GameObject gameObject, float radius, bool isTrigger)
        {
            var component = gameObject.GetOrAddComponent<SphereCollider>();
            component.radius = radius;
            component.isTrigger = isTrigger;
            return gameObject;
        }
        
        public static BonusView AddBonusView(this GameObject gameObject, InteractiveObjectType type, int value)
        {
            var component = gameObject.GetOrAddComponent<BonusView>();
            component.Init(type, value);
            return component;
        }

        public static GameObject AddCode<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetOrAddComponent<T>();
            return gameObject;
        }

        private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }

            return result;
        }
        
        public static bool TryBool(this string self)
        {
            return Boolean.TryParse(self, out var res) && res;
        }
    }
}