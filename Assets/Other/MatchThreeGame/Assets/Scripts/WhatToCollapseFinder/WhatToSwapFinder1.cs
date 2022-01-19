using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public static class WhatToSwapFinder1
    {
        /*
                    *   * * * * *
                    *   * * * * *
                    *   * & & * *
                    *   * * * & *
                    *   * * * * *
                    *   * * * * *
                    *
                    * and 
                    * 
                    *   * * * * *
                    *   * * * & *
                    *   * & & * *
                    *   * * * * *
                    *   * * * * *
                    *   * * * * *
                    *
                    * and
                    * 
                    *   * * * * *
                    *   * * * * *
                    *   * & & * *
                    *   & * * * *
                    *   * * * * *
                    *   * * * * *
                    *
                    * and
                    *
                    *   * * * * *
                    *   & * * * *
                    *   * & & * *
                    *   * * * * *
                    *   * * * * *
                    *   * * * * *
                    */
        public static Optional<Tuple<GameObject, GameObject>> Find(List<GameObject> match, ShapesArray shapes)
        {
            var list = (
                from go in match
                select go.GetComponent<Shape>() into shape 
                group shape by shape.Row
                into NewGroup
                where NewGroup.ToList().Count == 2
                select NewGroup
            ).ToList();
            
            if (list.Count == 0)
            {
                return new Optional<Tuple<GameObject, GameObject>>();
            }
            
            int row = list[0].Key;
            GameObject goToMove = (
                from gameObject in match
                where gameObject.GetComponent<Shape>().Row != row
                select new {gameObject}
            ).Single().gameObject;

            int column = goToMove.GetComponent<Shape>().Column;
            
            GameObject targetGo = shapes[row, column];

            return new Optional<Tuple<GameObject, GameObject>>(new Tuple<GameObject, GameObject>(goToMove, targetGo));
        }
    }
}