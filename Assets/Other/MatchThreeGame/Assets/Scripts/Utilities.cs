using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Object = System.Object;


public static class Utilities
{
    /// <summary>
    /// Helper method to animate potential matches
    /// </summary>
    /// <param name="potentialMatches"></param>
    /// <returns></returns>
    public static IEnumerator AnimatePotentialMatches(IEnumerable<GameObject> potentialMatches)
    {
        for (float i = 1f; i >= 0.3f; i -= 0.1f)
        {
            foreach (var item in potentialMatches)
            {
                Color c = item.GetComponent<SpriteRenderer>().color;
                c.a = i;
                item.GetComponent<SpriteRenderer>().color = c;
            }
            yield return new WaitForSeconds(Constants.OpacityAnimationFrameDelay);
        }
        for (float i = 0.3f; i <= 1f; i += 0.1f)
        {
            foreach (var item in potentialMatches)
            {
                Color c = item.GetComponent<SpriteRenderer>().color;
                c.a = i;
                item.GetComponent<SpriteRenderer>().color = c;
            }
            yield return new WaitForSeconds(Constants.OpacityAnimationFrameDelay);
        }
    }

    /// <summary>
    /// Checks if a shape is next to another one
    /// either horizontally or vertically
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public static bool AreVerticalOrHorizontalNeighbors(Shape s1, Shape s2)
    {
        return (s1.Column == s2.Column ||
                        s1.Row == s2.Row)
                        && Mathf.Abs(s1.Column - s2.Column) <= 1
                        && Mathf.Abs(s1.Row - s2.Row) <= 1;
    }

    /// <summary>
    /// Will check for potential matches vertically and horizontally
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<GameObject> GetPotentialMatches(ShapesArray shapes)
    {
        //list that will contain all the matches we find
        List<List<GameObject>> matches = new List<List<GameObject>>();
       
        for (int row = 0; row < Constants.Rows; row++)
        {
            for (int column = 0; column < Constants.Columns; column++)
            {

                var matches1 = CheckHorizontal1(row, column, shapes);
                var matches2 = CheckHorizontal2(row, column, shapes);
                var matches3 = CheckHorizontal3(row, column, shapes);
                var matches4 = CheckVertical1(row, column, shapes);
                var matches5 = CheckVertical2(row, column, shapes);
                var matches6 = CheckVertical3(row, column, shapes);

                if (matches1 != null) matches.Add(matches1);
                if (matches2 != null) matches.Add(matches2);
                if (matches3 != null) matches.Add(matches3);
                if (matches4 != null) matches.Add(matches4);
                if (matches5 != null) matches.Add(matches5);
                if (matches6 != null) matches.Add(matches6);

                //if we have >= 3 matches, return a random one
                if (matches.Count >= 3)
                    return matches[UnityEngine.Random.Range(0, matches.Count - 1)];

                //if we are in the middle of the calculations/loops
                //and we have less than 3 matches, return a random one
                if(row >= Constants.Rows / 2 && matches.Count > 0 && matches.Count <=2)
                    return matches[UnityEngine.Random.Range(0, matches.Count - 1)];
            }
        }
        return null;
    }

    public static List<GameObject> CheckHorizontal1(int row, int column, ShapesArray shapes)
    {
        if (column <= Constants.Columns - 2)
        {
            if (shapes[row, column].GetComponent<Shape>().
                IsSameType(shapes[row, column + 1].GetComponent<Shape>()))
            {
                if (row >= 1 && column >= 1)
                    if (shapes[row, column].GetComponent<Shape>().
                    IsSameType(shapes[row - 1, column - 1].GetComponent<Shape>()))
                        return new List<GameObject>()
                                {
                                    shapes[row, column],
                                    shapes[row, column + 1],
                                    shapes[row - 1, column - 1]
                                };

                /* example *\
                 * * * * *
                 * * * * *
                 * * * * *
                 * & & * *
                 & * * * *
                \* example  */

                if (row <= Constants.Rows - 2 && column >= 1)
                    if (shapes[row, column].GetComponent<Shape>().
                    IsSameType(shapes[row + 1, column - 1].GetComponent<Shape>()))
                        return new List<GameObject>()
                                {
                                    shapes[row, column],
                                    shapes[row, column + 1],
                                    shapes[row + 1, column - 1]
                                };

                /* example *\
                 * * * * *
                 * * * * *
                 & * * * *
                 * & & * *
                 * * * * *
                \* example  */
            }
        }
        return null;
    }


    public static List<GameObject> CheckHorizontal2(int row, int column, ShapesArray shapes)
    {
        if (column <= Constants.Columns - 3)
        {
            if (shapes[row, column].GetComponent<Shape>().
                IsSameType(shapes[row, column + 1].GetComponent<Shape>()))
            {

                if (row >= 1 && column <= Constants.Columns - 3)
                    if (shapes[row, column].GetComponent<Shape>().
                    IsSameType(shapes[row - 1, column + 2].GetComponent<Shape>()))
                        return new List<GameObject>()
                                {
                                    shapes[row, column],
                                    shapes[row, column + 1],
                                    shapes[row - 1, column + 2]
                                };

                /* example *\
                 * * * * *
                 * * * * *
                 * * * * *
                 * & & * *
                 * * * & *
                \* example  */

                if (row <= Constants.Rows - 2 && column <= Constants.Columns - 3)
                    if (shapes[row, column].GetComponent<Shape>().
                    IsSameType(shapes[row + 1, column + 2].GetComponent<Shape>()))
                        return new List<GameObject>()
                                {
                                    shapes[row, column],
                                    shapes[row, column + 1],
                                    shapes[row + 1, column + 2]
                                };

                /* example *\
                 * * * * *
                 * * * * *
                 * * * & *
                 * & & * *
                 * * * * *
                \* example  */
            }
        }
        return null;
    }

    public static List<GameObject> CheckHorizontal3(int row, int column, ShapesArray shapes)
    {
        if (column <= Constants.Columns - 4)
        {
            if (shapes[row, column].GetComponent<Shape>().
               IsSameType(shapes[row, column + 1].GetComponent<Shape>()) &&
               shapes[row, column].GetComponent<Shape>().
               IsSameType(shapes[row, column + 3].GetComponent<Shape>()))
            {
                return new List<GameObject>()
                                {
                                    shapes[row, column],
                                    shapes[row, column + 1],
                                    shapes[row, column + 3]
                                };
            }

            /* example *\
              * * * * *  
              * * * * *
              * * * * *
              * & & * &
              * * * * *
            \* example  */
        }
        if (column >= 2 && column <= Constants.Columns - 2)
        {
            if (shapes[row, column].GetComponent<Shape>().
               IsSameType(shapes[row, column + 1].GetComponent<Shape>()) &&
               shapes[row, column].GetComponent<Shape>().
               IsSameType(shapes[row, column - 2].GetComponent<Shape>()))
            {
                return new List<GameObject>()
                                {
                                    shapes[row, column],
                                    shapes[row, column + 1],
                                    shapes[row, column -2]
                                };
            }

            /* example *\
              * * * * * 
              * * * * *
              * * * * *
              * & * & &
              * * * * *
            \* example  */
        }
        return null;
    }

    public static List<GameObject> CheckVertical1(int row, int column, ShapesArray shapes)
    {
        if (row <= Constants.Rows - 2)
        {
            if (shapes[row, column].GetComponent<Shape>().
                IsSameType(shapes[row + 1, column].GetComponent<Shape>()))
            {
                if (column >= 1 && row >= 1)
                    if (shapes[row, column].GetComponent<Shape>().
                    IsSameType(shapes[row - 1, column - 1].GetComponent<Shape>()))
                        return new List<GameObject>()
                                {
                                    shapes[row, column],
                                    shapes[row + 1, column],
                                    shapes[row - 1, column -1]
                                };

                /* example *\
                  * * * * *
                  * * * * *
                  * & * * *
                  * & * * *
                  & * * * *
                \* example  */

                if (column <= Constants.Columns - 2 && row >= 1)
                    if (shapes[row, column].GetComponent<Shape>().
                    IsSameType(shapes[row - 1, column + 1].GetComponent<Shape>()))
                        return new List<GameObject>()
                                {
                                    shapes[row, column],
                                    shapes[row + 1, column],
                                    shapes[row - 1, column + 1]
                                };

                /* example *\
                  * * * * *
                  * * * * *
                  * & * * *
                  * & * * *
                  * * & * *
                \* example  */
            }
        }
        return null;
    }

    public static List<GameObject> CheckVertical2(int row, int column, ShapesArray shapes)
    {
        if (row <= Constants.Rows - 3)
        {
            if (shapes[row, column].GetComponent<Shape>().
                IsSameType(shapes[row + 1, column].GetComponent<Shape>()))
            {
                if (column >= 1)
                    if (shapes[row, column].GetComponent<Shape>().
                    IsSameType(shapes[row + 2, column - 1].GetComponent<Shape>()))
                        return new List<GameObject>()
                                {
                                    shapes[row, column],
                                    shapes[row + 1, column],
                                    shapes[row + 2, column -1]
                                };

                /* example *\
                  * * * * *
                  & * * * *
                  * & * * *
                  * & * * *
                  * * * * *
                \* example  */

                if (column <= Constants.Columns - 2)
                    if (shapes[row, column].GetComponent<Shape>().
                    IsSameType(shapes[row + 2, column + 1].GetComponent<Shape>()))
                        return new List<GameObject>()
                                {
                                    shapes[row, column],
                                    shapes[row+1, column],
                                    shapes[row + 2, column + 1]
                                };

                /* example *\
                  * * * * *
                  * * & * *
                  * & * * *
                  * & * * *
                  * * * * *
                \* example  */

            }
        }
        return null;
    }

    public static List<GameObject> CheckVertical3(int row, int column, ShapesArray shapes)
    {
        if (row <= Constants.Rows - 4)
        {
            if (shapes[row, column].GetComponent<Shape>().
               IsSameType(shapes[row + 1, column].GetComponent<Shape>()) &&
               shapes[row, column].GetComponent<Shape>().
               IsSameType(shapes[row + 3, column].GetComponent<Shape>()))
            {
                return new List<GameObject>()
                                {
                                    shapes[row, column],
                                    shapes[row + 1, column],
                                    shapes[row + 3, column]
                                };
            }
        }

        /* example *\
          * & * * *
          * * * * *
          * & * * *
          * & * * *
          * * * * *
        \* example  */

        if (row >= 2 && row <= Constants.Rows - 2)
        {
            if (shapes[row, column].GetComponent<Shape>().
               IsSameType(shapes[row + 1, column].GetComponent<Shape>()) &&
               shapes[row, column].GetComponent<Shape>().
               IsSameType(shapes[row - 2, column].GetComponent<Shape>()))
            {
                return new List<GameObject>()
                                {
                                    shapes[row, column],
                                    shapes[row + 1, column],
                                    shapes[row - 2, column]
                                };
            }
        }

        /* example *\
          * * * * *
          * & * * *
          * & * * *
          * * * * *
          * & * * *
        \* example  */
        return null;
    }

    public static Tuple<GameObject, GameObject> FindItemsToSwap(ShapesArray shapes, IEnumerable<GameObject> matchedGameObjects)
    {
        try
        {
            var match = matchedGameObjects.ToList();
            
            var optionalPair = FindWhatToCollapse1(match, shapes);
            if (!optionalPair.IsEmpty)
            {
                return optionalPair.Value;
            }
            
            optionalPair = FindWhatToCollapse2(match, shapes);
            if (!optionalPair.IsEmpty)
            {
                return optionalPair.Value;
            }
            
            optionalPair = FindWhatToCollapse3(match, shapes);
            if (!optionalPair.IsEmpty)
            {
                return optionalPair.Value;
            }
            
            optionalPair = FindWhatToCollapse4(match, shapes);
            if (!optionalPair.IsEmpty)
            {
                return optionalPair.Value;
            }

            throw new Exception();

        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return null;
        }
    }

    private static Optional<int> GetRowNumberIfThereAreTwoItemsWithSameRow(IEnumerable<GameObject> match)
    {
        var v = (
            from gameObject in match
            group gameObject by gameObject.GetComponent<Shape>().Row
            into NewGroup
            where NewGroup.Key >= 2
                select NewGroup
            ).ToList();

        if (v.Count > 0)
        {
            return new Optional<int>(v[0].Key);
        }
        else
        {
            return new Optional<int>();
        }
    }
    
    private static Optional<int> GetColumnNumberIfThereAreTwoItemsWithSameColumn(IEnumerable<GameObject> match)
    {
        var v = (
            from gameObject in match
            group gameObject by gameObject.GetComponent<Shape>().Column
            into NewGroup
            where NewGroup.Key >= 2
            select NewGroup
        ).ToList();

        if (v.Count > 0)
        {
            return new Optional<int>(v[0].Key);
        }
        else
        {
            return new Optional<int>();
        }
    }
    

    public class Optional<T>
    {
        public T Value;
        public bool IsEmpty;

        public static Optional<object> Empty()
        {
            return new Optional<object>();
        }

        public static Optional<T> Of(T v)
        {
            return new Optional<T>();
        }

        public Optional(T value)
        {
            this.Value = value;
            IsEmpty = false;
        }

        public Optional()
        {
            IsEmpty = true;
        }
    }
    
    private static Optional<Tuple<GameObject, GameObject>> FindWhatToCollapse1(List<GameObject> match, ShapesArray shapes)
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
    
        var list = (
            from go in match
            select go.GetComponent<Shape>() into shape 
            group shape by shape.Row
            into NewGroup
            where NewGroup.ToList().Count >= 2
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
        
        GameObject targetGo = shapes[row, goToMove.GetComponent<Shape>().Column];
        
        return new Optional<Tuple<GameObject, GameObject>>(new Tuple<GameObject, GameObject>(goToMove, targetGo));
    }
    
        private static Optional<Tuple<GameObject, GameObject>> FindWhatToCollapse2(List<GameObject> match, ShapesArray shapes)
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
            var list = (
                from go in match
                select go.GetComponent<Shape>() into shape 
                group shape by shape.Column
                into NewGroup
                where NewGroup.ToList().Count >= 2
                select NewGroup
            ).ToList();
    
            if (list.Count == 0)
            {
                return new Optional<Tuple<GameObject, GameObject>>();
            }
            
            int column = list[0].Key;
            GameObject goToMove = (
                from gameObject in match
                where gameObject.GetComponent<Shape>().Column != column 
                select new {gameObject}
            ).Single().gameObject;

            GameObject targetGo = shapes[goToMove.GetComponent<Shape>().Row, column];
            
            return new Optional<Tuple<GameObject, GameObject>>(new Tuple<GameObject, GameObject>(goToMove, targetGo));
        }

        public static Optional<Tuple<GameObject, GameObject>> FindWhatToCollapse3(List<GameObject> match, ShapesArray shapes)
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
            1:2
            2:2
            4:2
         
            1:2
            3:2
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

         if (sortedShapes[1].Row - sortedShapes[0].Row == 1)
         {
             var targetRow = sortedShapes[0].Row + 1;
             var targetColumn = sortedShapes[0].Column; 
             
             var targetGo = shapes[targetRow, targetColumn];

             return new Optional<Tuple<GameObject, GameObject>>(
                 new Tuple<GameObject, GameObject>(sortedShapes[0].gameObject, targetGo));
         }
         else
         {
             var targetRow = sortedShapes[sortedShapes.Count - 1].Row - 1;
             var targetColumn = sortedShapes[0].Column; 
             
             var targetGo = shapes[targetRow, targetColumn];

             return new Optional<Tuple<GameObject, GameObject>>(
                 new Tuple<GameObject, GameObject>(sortedShapes[0].gameObject, targetGo));
         }
         
        }
        
        public static Optional<Tuple<GameObject, GameObject>> FindWhatToCollapse4(List<GameObject> match, ShapesArray shapes)
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
             return new Optional<Tuple<GameObject, GameObject>>();
         }

         var column = list[0].Key;

         /*
            1:2
            2:2
            4:2
         
            1:2
            3:2
            4:2

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

         if (sortedShapes[1].Column - sortedShapes[0].Column == 1)
         {
             var targetRow = sortedShapes[0].Column;
             var targetColumn = sortedShapes[0].Column + 1;
             
             var targetGo = shapes[targetRow, targetColumn];

             return new Optional<Tuple<GameObject, GameObject>>(
                 new Tuple<GameObject, GameObject>(sortedShapes[0].gameObject, targetGo));
         }
         else
         {
             var targetRow = sortedShapes[0].Column;
             var targetColumn = sortedShapes[sortedShapes.Count - 1].Column - 1;
             
             var targetGo = shapes[targetRow, targetColumn];

             return new Optional<Tuple<GameObject, GameObject>>(new Tuple<GameObject, GameObject>(sortedShapes[0].gameObject, targetGo));
         }
         
        }
}

