using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class WhatToSwapFinder4
    {
        /*
            *   * * * * *
            *   * * * & *
            *   * * * * *
            *   * * * & *
            *   * * * & *
            *   * * * * *
            *
            * and 
            * 
            *   * * * * *
            *   * * * * *
            *   * * * & *
            *   * * * & *
            *   * * * * *
            *   * * * & *
            *
            */
        public static Optional<Tuple<GameObject, GameObject>> Find(List<GameObject> match, ShapesArray shapes)
        {

            var shapesArray = from go in match
                select go.GetComponent<Shape>()
                into shape select shape;

            var list = (
                from shape in shapesArray
                group shape by shape.Column
                into groupedByRow
                where groupedByRow.ToList().Count == match.Count
                select groupedByRow
            ).ToList();

            if (list.Count == 0)
            {
                Debug.Log("Find4: nothing");
                return new Optional<Tuple<GameObject, GameObject>>();
            }

            var column = list[0].Key;

            /*
               1:2
               3:2
               4:2
               
               1:2
               2:2
               4:2
   
              1) найти какой из этих 2х вариантов: 
                1. отсортировать по column
                2. 1.column - 0.column == 1 ?
                  1. следующий элемент = 0.column + 1  
                  2. следующий элемент = 2.column - 1
             */

            var sortedShapes = (
                from shape in shapesArray
                orderby shape.Row
                select shape
            ).ToList();

            if (sortedShapes[1].Row - sortedShapes[0].Row != 1)
            {
                var targetRow = sortedShapes[0].Row + 1;
                var targetColumn = sortedShapes[0].Column;
             
                var targetGo = shapes[targetRow, targetColumn];

                Debug.Log("Find4: row=" + targetRow + ", column=" + targetColumn);
                
                return new Optional<Tuple<GameObject, GameObject>>(
                    new Tuple<GameObject, GameObject>(sortedShapes[0].gameObject, targetGo));
            }
            else
            {
                var targetRow = sortedShapes[sortedShapes.Count - 1].Row - 1;
                var targetColumn = sortedShapes[0].Column;
             
                var targetGo = shapes[targetRow, targetColumn];

                Debug.Log("Find4: row=" + targetRow + ", column=" + targetColumn);

                return new Optional<Tuple<GameObject, GameObject>>(new Tuple<GameObject, GameObject>(sortedShapes[sortedShapes.Count - 1].gameObject, targetGo));
            }
         
        }

    }
}