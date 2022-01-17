using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class WhatToSwapFinder2
    {
        
        /*
         *   * * * * *
         *   * * * * *
         *   * * & * *
         *   * * * & *
         *   * * * & *
         *   * * * * *
         *
         * and 
         * 
         *   * * * * *
         *   * * * * *
         *   * * * * &
         *   * * * & *
         *   * * * & *
         *   * * * * *
         *
         * and
         * 
         *   * * * * *
         *   * * * * *
         *   * * * * *
         *   * * * & *
         *   * * * & *
         *   * * & * *
         *
         * and
         
         *   * * * * *
         *   * * * * *
         *   * * * * *
         *   * * * & *
         *   * * * & *
         *   * * * * &
         * 
         */
        public static Optional<Tuple<GameObject, GameObject>> Find(List<GameObject> match, ShapesArray shapes)
        {
            var list = (
                from go in match
                select go.GetComponent<Shape>() into shape 
                group shape by shape.Column
                into NewGroup
                where NewGroup.ToList().Count == 2
                select NewGroup
            ).ToList();
    
            if (list.Count == 0)
            {
            Debug.Log("Find2: nothing");
                return new Optional<Tuple<GameObject, GameObject>>();
            }
            
            int column = list[0].Key;
            GameObject goToMove = (
                from gameObject in match
                where gameObject.GetComponent<Shape>().Column != column 
                select new {gameObject}
            ).Single().gameObject;

            var row = goToMove.GetComponent<Shape>().Row;
            
            GameObject targetGo = shapes[row, column];
            
            Debug.Log("Find2: row=" + row + ", column=" + column);
            
            return new Optional<Tuple<GameObject, GameObject>>(new Tuple<GameObject, GameObject>(goToMove, targetGo));
        }
    }
}