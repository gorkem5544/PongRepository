using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Statics
{
    public static class Utils
    {
        /// <summary>
        /// Verilern Collider Parameteresinin uzuncuğunu ve yüksekliğini alarak bu değerler arasuında random sayı üretmeyi sağlayan kod parçası
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public static Vector2 GetRandomPoint(BoxCollider2D box)
        {

            Vector2 extents = box.size * 0.5f;

            Vector2 localPoint = new Vector2(
                Random.Range(-extents.x, extents.x),
                Random.Range(-extents.y, extents.y)
            );

            localPoint += box.offset;

            return box.transform.TransformPoint(localPoint);
        }
    }

}