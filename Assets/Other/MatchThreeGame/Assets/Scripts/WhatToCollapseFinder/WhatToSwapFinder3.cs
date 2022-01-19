﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class WhatToSwapFinder3
    {
            /*
            *   * * * * *
            *   & & * & *
            *   * * * * *
            *   * * * * *
            *   * * * * *
            *   * * * * *
            *
            * and 
            * 
            *   * * * * *
            *   * * * * *
            *   * & * & &
            *   * * * * *
            *   * * * * *
            *   * * * * *
            *
            */

        public static Optional<Tuple<GameObject, GameObject>> Find(List<GameObject> match, ShapesArray shapes)
        {
            var shapesArray = from go in match
                select go.GetComponent<Shape>()
                into shape select shape;

            var list = (
                from shape in shapesArray
                group shape by shape.Row
                into groupedByRow
                where groupedByRow.ToList().Count == match.Count
                select groupedByRow
            ).ToList();

            if (list.Count == 0)
            {
                return new Optional<Tuple<GameObject, GameObject>>();
            }

            var row = list[0].Key;

            /*
               2:1
               2:3
               2:4
               
               2:1
               2:2
               2:4
            
       
   
              1) найти какой из этих 2х вариантов: 
                1. отсортировать по column
                2. 1.column - 0.column == 1 ?
                  1. следующий элемент = 0.column + 1  
                  2. следующий элемент = 2.column - 1
             */

            var sortedShapes = (
                from shape in shapesArray
                orderby shape.Column
                select shape
            ).ToList();

            if (sortedShapes[1].Column - sortedShapes[0].Column != 1)
            {
                var targetRow = sortedShapes[0].Row;
                var targetColumn = sortedShapes[0].Column + 1; 
             
                var targetGo = shapes[targetRow, targetColumn];

                return new Optional<Tuple<GameObject, GameObject>>(
                    new Tuple<GameObject, GameObject>(sortedShapes[0].gameObject, targetGo));
            }
            else
            {
                var targetRow = sortedShapes[0].Row;
                var targetColumn = sortedShapes[sortedShapes.Count - 1].Column - 1;

                var targetGo = shapes[targetRow, targetColumn];

                return new Optional<Tuple<GameObject, GameObject>>(
                    new Tuple<GameObject, GameObject>(sortedShapes[sortedShapes.Count - 1].gameObject, targetGo));
            }
         
        }

    }
}