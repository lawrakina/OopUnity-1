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
            CollisionDetectionMode                            collisionDetectionMode)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody>();
            component.mass = mass;
            component.collisionDetectionMode = collisionDetectionMode;
            return gameObject;
        }

        public static GameObject AddSphereCollider(this GameObject gameObject, float radius)
        {
            var component = gameObject.GetOrAddComponent<SphereCollider>();
            component.radius = radius;
            return gameObject;
        }

        public static GameObject AddBonusView(this GameObject gameObject, InteractiveObjectType type, int value)
        {
            var component = gameObject.GetOrAddComponent<BonusView>();
            component.Init(type, value);
            return gameObject;
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
    }
}