using UnityEngine;
using static UnityEngine.Debug;


namespace Healper
{
    public static class Dbg
    {
        public static void Log(Object obj)
        {
            Debug.Log(obj);
        }

        public static void Log(string st)
        {
            Debug.Log(st);
        }
    }
}