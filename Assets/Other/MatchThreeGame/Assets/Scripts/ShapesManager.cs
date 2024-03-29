﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Other.MatchThreeGame.Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ShapesManager : MonoBehaviour, IEndDragHandler
{
    public Text DebugText;
    public bool ShowDebugInfo = false;
    //candy graphics taken from http://opengameart.org/content/candy-pack-1

    public ShapesArray shapes;
    
    private StateManager _stateManager;
    private GameLifecycleObservables _gameLifecycleObservables;

    public readonly Vector2 BottomRight = new Vector2(-2f, -4.73f + 0.7f);
    public readonly Vector2 CandySize = new Vector2(0.7f * 0.8f, 0.7f * 0.8f);
    
    private GameObject hitGo = null;
    private Vector2[] SpawnPositions;
    public GameObject[] CandyPrefabs;
    public GameObject[] ExplosionPrefabs;
    public GameObject[] BonusPrefabs;

    private IEnumerator CheckPotentialMatchesCoroutine;
    private IEnumerator AnimatePotentialMatchesCoroutine;

    IEnumerable<GameObject> potentialMatches;

    public SoundManager soundManager;
    void Awake()
    {
        DebugText.enabled = ShowDebugInfo;
    }

    // Use this for initialization
    void Start()
    {
        
        InitializeTypesOnPrefabShapesAndBonuses();

        InitializeCandyAndSpawnPositions();

        StartCheckForPotentialMatches();

        SwipeDetector.OnSwipe.Subscribe(tuple =>
        {
            var (position, direction) = tuple;
            
            Debug.Log("position: " + position + ", direction: " + direction);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(position), Vector2.zero);
            if (hit.collider != null)
            {
                var go1 = hit.collider.gameObject;
                var go2 = GetNeighbourShape(go1, direction);
                
                StopCheckForPotentialMatches();
                _stateManager.GameState = GameState.Animating;
                FixSortingLayer(go1, go2);
                StartCoroutine(FindMatchesAndCollapse(go1, go2,  then: () => StartCoroutine(StartEnemyTurn())));
            }
        });
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("start: " + eventData.pressPosition);
        Debug.Log("end: " + eventData.position);
        var directionVector = (eventData.position - eventData.pressPosition).normalized;
        Debug.Log("vectorDirection: " + directionVector);
        Debug.Log("Direction: " + GetDragDirection(directionVector));
    }

    private enum DraggedDirection
    {
        Up,
        Down,
        Right,
        Left
    }

    private DraggedDirection GetDragDirection(Vector3 dragVector)
    {
        float positiveX = Mathf.Abs(dragVector.x);
        float positiveY = Mathf.Abs(dragVector.y);
        DraggedDirection draggedDir;
        if (positiveX > positiveY)
        {
            draggedDir = (dragVector.x > 0) ? DraggedDirection.Right : DraggedDirection.Left;
        }
        else
        {
            draggedDir = (dragVector.y > 0) ? DraggedDirection.Up : DraggedDirection.Down;
        }
        Debug.Log(draggedDir);
        return draggedDir;
    }
    

    /// <summary>
    /// Initialize shapes
    /// </summary>
    private void InitializeTypesOnPrefabShapesAndBonuses()
    {
        //just assign the name of the prefab
        foreach (var item in CandyPrefabs)
        {
            item.GetComponent<Shape>().Type = item.name;
        }

        //assign the name of the respective "normal" candy as the type of the Bonus
        foreach (var item in BonusPrefabs)
        {
            item.GetComponent<Shape>().Type = CandyPrefabs.
                Where(x => x.GetComponent<Shape>().Type.Contains(item.name.Split('_')[1].Trim())).Single().name;
        }
    }

    public void InitializeCandyAndSpawnPositionsFromPremadeLevel()
    {
        InitializeVariables();

        var premadeLevel = DebugUtilities.FillShapesArrayFromResourcesData();

        if (shapes != null)
            DestroyAllCandy();

        shapes = new ShapesArray();
        SpawnPositions = new Vector2[Constants.Columns];

        for (int row = 0; row < Constants.Rows; row++)
        {
            for (int column = 0; column < Constants.Columns; column++)
            {

                GameObject newCandy = null;

                newCandy = GetSpecificCandyOrBonusForPremadeLevel(premadeLevel[row, column]);

                InstantiateAndPlaceNewCandy(row, column, newCandy);

            }
        }

        SetupSpawnPositions();
    }


    public void InitializeCandyAndSpawnPositions()
    {
        InitializeVariables();

        if (shapes != null)
            DestroyAllCandy();

        shapes = new ShapesArray();
        SpawnPositions = new Vector2[Constants.Columns];

        for (int row = 0; row < Constants.Rows; row++)
        {
            for (int column = 0; column < Constants.Columns; column++)
            {

                GameObject newCandy = GetRandomCandy();

                //check if two previous horizontal are of the same type
                while (column >= 2 && shapes[row, column - 1].GetComponent<Shape>()
                                       .IsSameType(newCandy.GetComponent<Shape>())
                                   && shapes[row, column - 2].GetComponent<Shape>().IsSameType(newCandy.GetComponent<Shape>()))
                {
                    newCandy = GetRandomCandy();
                }

                //check if two previous vertical are of the same type
                while (row >= 2 && shapes[row - 1, column].GetComponent<Shape>()
                                    .IsSameType(newCandy.GetComponent<Shape>())
                                && shapes[row - 2, column].GetComponent<Shape>().IsSameType(newCandy.GetComponent<Shape>()))
                {
                    newCandy = GetRandomCandy();
                }

                InstantiateAndPlaceNewCandy(row, column, newCandy);

            }
        }

        SetupSpawnPositions();
    }



    private void InstantiateAndPlaceNewCandy(int row, int column, GameObject newCandy)
    {
        GameObject go = Instantiate(newCandy,
                BottomRight + new Vector2(column * CandySize.x, row * CandySize.y), Quaternion.identity)
            as GameObject;

        //assign the specific properties
        go.GetComponent<Shape>().Assign(newCandy.GetComponent<Shape>().Type, row, column);
        shapes[row, column] = go;
    }

    private void SetupSpawnPositions()
    {
        //create the spawn positions for the new shapes (will pop from the 'ceiling')
        for (int column = 0; column < Constants.Columns; column++)
        {
            SpawnPositions[column] = BottomRight
                                     + new Vector2(column * CandySize.x, Constants.Rows * CandySize.y);
        }
    }




    /// <summary>
    /// Destroy all candy gameobjects
    /// </summary>
    private void DestroyAllCandy()
    {
        for (int row = 0; row < Constants.Rows; row++)
        {
            for (int column = 0; column < Constants.Columns; column++)
            {
                Destroy(shapes[row, column]);
            }
        }
    }


    // Update is called once per frame
    // void Update()
    // {
    //     if (ShowDebugInfo)
    //         DebugText.text = DebugUtilities.GetArrayContents(shapes);
    //
    //     if (_stateManager.GameState == GameState.EnemyTurn && !_stateManager.IsAnyPanelDisplayedOnUI)
    //     {
    //         return;
    //     }
    //     
    //     if (_stateManager.GameState == GameState.None && !_stateManager.IsAnyPanelDisplayedOnUI)
    //     {
    //         // user has clicked or touched
    //          if (Input.GetMouseButtonDown(0))
    //          {
    //              //get the hit position
    //              Debug.Log("Click: " + Input.mousePosition + ", translated: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
    //
    //              RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    //              if (hit.collider != null) //we have a hit!!!
    //              {
    //                  hitGo = hit.collider.gameObject;
    //                  _stateManager.GameState = GameState.SelectionStarted;
    //              }
    //          }
    //     }
    //     else if (_stateManager.GameState == GameState.SelectionStarted)
    //     {
    //         //user dragged
    //         if (Input.GetMouseButton(0))
    //         {
    //             
    //             RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    //             //we have a hit
    //             if (hit.collider != null && hitGo != hit.collider.gameObject)
    //             {
    //             
    //                 //user did a hit, no need to show him hints 
    //                 StopCheckForPotentialMatches();
    //             
    //                 //if the two shapes are diagonally aligned (different row and column), just return
    //                 if (!Utilities.AreVerticalOrHorizontalNeighbors(hitGo.GetComponent<Shape>(),
    //                     hit.collider.gameObject.GetComponent<Shape>()))
    //                 {
    //                     _stateManager.GameState = GameState.None;
    //                 }
    //                 else
    //                 {
    //                     _stateManager.GameState = GameState.Animating;
    //                     FixSortingLayer(hitGo, hit.collider.gameObject);
    //                     StartCoroutine(FindMatchesAndCollapse(hit.collider.gameObject, () => StartCoroutine(StartEnemyTurn())));
    //                 }
    //             }
    //         }
    //     }
    // }

    /// <summary>
    /// Modifies sorting layers for better appearance when dragging/animating
    /// </summary>
    /// <param name="hitGo"></param>
    /// <param name="hitGo2"></param>
    private void FixSortingLayer(GameObject hitGo1, GameObject hitGo2)
    {
        SpriteRenderer sp1 = hitGo1.GetComponent<SpriteRenderer>();
        SpriteRenderer sp2 = hitGo2.GetComponent<SpriteRenderer>();
        if (sp1.sortingOrder <= sp2.sortingOrder)
        {
            sp1.sortingOrder = 1;
            sp2.sortingOrder = 0;
        }
    }




    private IEnumerator FindMatchesAndCollapse(GameObject hitGo1, GameObject hitGo2, Action then)
    {
        bool turnMade = false;
        
        //get the second item that was part of the swipe
        shapes.Swap(hitGo1, hitGo2);

        //move the swapped ones
        hitGo1.transform.positionTo(Constants.SwapDuration, hitGo2.transform.position);
        hitGo2.transform.positionTo(Constants.SwapDuration, hitGo1.transform.position);
        yield return new WaitForSeconds(Constants.SwapDuration);

        //get the matches via the helper methods
        var hitGomatchesInfo = shapes.GetMatches(hitGo1);
        var hitGo2matchesInfo = shapes.GetMatches(hitGo2);

        var totalMatches = hitGomatchesInfo.MatchedCandy
            .Union(hitGo2matchesInfo.MatchedCandy).Distinct().ToList();

        //if user's swap didn't create at least a 3-match, undo their swap
        if (totalMatches.Count() < Constants.MinimumMatches)
        {
            hitGo1.transform.positionTo(Constants.SwapDuration, hitGo2.transform.position);
            hitGo2.transform.positionTo(Constants.SwapDuration, hitGo1.transform.position);
            yield return new WaitForSeconds(Constants.SwapDuration);

            shapes.UndoSwap();
        }
        else
        {
            turnMade = true;

            if (_stateManager.IsPlayersTurn)
            {
                _gameLifecycleObservables.BeforeSuccessfulShapeSwapByPlayer.Emit();
                _stateManager.TurnsLeft -= 1;
                _stateManager.SequentialTurnsForPlayer.Value -= 1;
            }
            else
            {
                _stateManager.SequentialTurnsForEnemy.Value -= 1;
            }
        }

        //if more than 3 matches and no Bonus is contained in the line, we will award a new Bonus
        bool addBonus = Constants.BonusEnabled && (totalMatches.Count() >= Constants.MinimumMatchesForBonus &&
                                                   !BonusTypeUtilities.ContainsDestroyWholeRowColumn(hitGomatchesInfo.BonusesContained) &&
                                                   !BonusTypeUtilities.ContainsDestroyWholeRowColumn(hitGo2matchesInfo.BonusesContained));

        Shape hitGoCache = null;
        if (addBonus)
        {
            //get the game object that was of the same type
            var sameTypeGo = hitGomatchesInfo.MatchedCandy.Count() > 0 ? hitGo : hitGo2;
            hitGoCache = sameTypeGo.GetComponent<Shape>();
        }

        int timesRun = 1;
        while (totalMatches.Count() >= Constants.MinimumMatches)
        {
            //increase score
            IncreaseScore((totalMatches.Count() - 2) * Constants.Match3Score);
            
            _gameLifecycleObservables.OnCollapse.Emit(new Tuple<bool, List<GameObject>>(_stateManager.IsPlayersTurn, totalMatches));

            if (timesRun >= 2)
                IncreaseScore(Constants.SubsequentMatchScore);

            // soundManager.PlayCrincle();

            foreach (var item in totalMatches)
            {
                item.transform.scaleTo(Constants.CollapseDuration, 0f);
            }
            yield return new WaitForSeconds(Constants.CollapseDuration);
            
            foreach (var item in totalMatches)
            {
                shapes.Remove(item);
                RemoveFromScene(item);
            }

            //check and instantiate Bonus if needed
            if (addBonus)
                CreateBonus(hitGoCache);

            addBonus = false;

            //get the columns that we had a collapse
            var columns = totalMatches.Select(go => go.GetComponent<Shape>().Column).Distinct();

            //the order the 2 methods below get called is important!!!
            //collapse the ones gone
            var collapsedCandyInfo = shapes.Collapse(columns);
            //create new ones
            var newCandyInfo = CreateNewCandyInSpecificColumns(columns);

            int maxDistance = Mathf.Max(collapsedCandyInfo.MaxDistance, newCandyInfo.MaxDistance);

            // yield return new WaitForSeconds(Constants.ExplosionDuration);
            MoveAndAnimate(newCandyInfo.AlteredCandy, maxDistance);
            MoveAndAnimate(collapsedCandyInfo.AlteredCandy, maxDistance);



            //will wait for both of the above animations
            yield return new WaitForSeconds(Constants.MoveAnimationMinDuration * maxDistance);

            //search if there are matches with the new/collapsed items
            totalMatches = shapes.GetMatches(collapsedCandyInfo.AlteredCandy).
                Union(shapes.GetMatches(newCandyInfo.AlteredCandy)).Distinct().ToList();



            timesRun++;
        }

        _stateManager.GameState = GameState.None;
        // StartCheckForPotentialMatches();

        if (turnMade)
        {
            then.Invoke();
        }
    }

    /*
     * 1. Найти подходящие комбинации
     * 2. Синициировать ход
     */
    private IEnumerator StartEnemyTurn()
    {
        _stateManager.BeforeEnemyTurn();

        _gameLifecycleObservables.AfterPlayerTurn.Emit();
        _gameLifecycleObservables.BeforeEnemyTurn.Emit();

        if (!_stateManager.IsPlayersTurn)
        {
            _stateManager.GameState = GameState.EnemyTurn;
            
            yield return new WaitForSeconds(1);

            IEnumerable<GameObject> match = Utilities.GetPotentialMatches(shapes);
            Tuple<GameObject, GameObject> itemsToSwap = Utilities.FindItemsToSwap(shapes, match);

            hitGo = itemsToSwap.Item1;

            StartCoroutine(FindMatchesAndCollapse(itemsToSwap.Item1, itemsToSwap.Item2, () =>
            {
                _stateManager.GameState = GameState.None;
                _stateManager.AfterEnemyTurn();
                _gameLifecycleObservables.AfterEnemyTurn.Emit();
                _gameLifecycleObservables.BeforePlayerTurn.Emit();
            }));
        }
    }

    /// <summary>
    /// Creates a new Bonus based on the shape parameter
    /// </summary>
    /// <param name="hitGoCache"></param>
    private void CreateBonus(Shape hitGoCache)
    {
        GameObject Bonus = Instantiate(GetBonusFromType(hitGoCache.Type), BottomRight
                                                                          + new Vector2(hitGoCache.Column * CandySize.x,
                                                                              hitGoCache.Row * CandySize.y), Quaternion.identity)
            as GameObject;
        shapes[hitGoCache.Row, hitGoCache.Column] = Bonus;
        var BonusShape = Bonus.GetComponent<Shape>();
        //will have the same type as the "normal" candy
        BonusShape.Assign(hitGoCache.Type, hitGoCache.Row, hitGoCache.Column);
        //add the proper Bonus type
        BonusShape.Bonus |= BonusType.DestroyWholeRowColumn;
    }




    /// <summary>
    /// Spawns new candy in columns that have missing ones
    /// </summary>
    /// <param name="columnsWithMissingCandy"></param>
    /// <returns>Info about new candies created</returns>
    private AlteredCandyInfo CreateNewCandyInSpecificColumns(IEnumerable<int> columnsWithMissingCandy)
    {
        AlteredCandyInfo newCandyInfo = new AlteredCandyInfo();

        //find how many null values the column has
        foreach (int column in columnsWithMissingCandy)
        {
            var emptyItems = shapes.GetEmptyItemsOnColumn(column);
            foreach (var item in emptyItems)
            {
                var go = GetRandomCandy();
                GameObject newCandy = Instantiate(go, SpawnPositions[column], Quaternion.identity)
                    as GameObject;

                newCandy.GetComponent<Shape>().Assign(go.GetComponent<Shape>().Type, item.Row, item.Column);

                if (Constants.Rows - item.Row > newCandyInfo.MaxDistance)
                    newCandyInfo.MaxDistance = Constants.Rows - item.Row;

                shapes[item.Row, item.Column] = newCandy;
                newCandyInfo.AddCandy(newCandy);
            }
        }
        return newCandyInfo;
    }

    /// <summary>
    /// Animates gameobjects to their new position
    /// </summary>
    /// <param name="movedGameObjects"></param>
    private void MoveAndAnimate(IEnumerable<GameObject> movedGameObjects, int distance)
    {
        foreach (var item in movedGameObjects)
        {
            item.transform.positionTo(Constants.MoveAnimationMinDuration * distance, BottomRight +
                new Vector2(item.GetComponent<Shape>().Column * CandySize.x, item.GetComponent<Shape>().Row * CandySize.y));
        }
    }

    /// <summary>
    /// Destroys the item from the scene and instantiates a new explosion gameobject
    /// </summary>
    /// <param name="item"></param>
    private void RemoveFromScene(GameObject item)
    {
        GameObject explosion = GetRandomExplosion();
        var newExplosion = Instantiate(explosion, item.transform.position, Quaternion.identity) as GameObject;
        Destroy(newExplosion, Constants.ExplosionDuration);
        Destroy(item, Constants.ExplosionDuration);
    }

    /// <summary>
    /// Get a random candy
    /// </summary>
    /// <returns></returns>
    private GameObject GetRandomCandy()
    {
        return CandyPrefabs[Random.Range(0, CandyPrefabs.Length)];
    }

    private void InitializeVariables()
    {
        _stateManager = StateManager.Get();
        _gameLifecycleObservables = _stateManager.GameLifecycleObservables;
    }

    private void IncreaseScore(int amount)
    {
        //_stateManager.IncreaseScore(amount);
    }

    /// <summary>
    /// Get a random explosion
    /// </summary>
    /// <returns></returns>
    private GameObject GetRandomExplosion()
    {
        return ExplosionPrefabs[Random.Range(0, ExplosionPrefabs.Length)];
    }

    /// <summary>
    /// Gets the specified Bonus for the specific type
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private GameObject GetBonusFromType(string type)
    {
        string color = type.Split('_')[1].Trim();
        foreach (var item in BonusPrefabs)
        {
            if (item.GetComponent<Shape>().Type.Contains(color))
                return item;
        }
        throw new Exception("Wrong type");
    }

    /// <summary>
    /// Starts the coroutines, keeping a reference to stop later
    /// </summary>
    private void StartCheckForPotentialMatches()
    {
        StopCheckForPotentialMatches();
        //get a reference to stop it later
        CheckPotentialMatchesCoroutine = CheckPotentialMatches();
        StartCoroutine(CheckPotentialMatchesCoroutine);
    }

    /// <summary>
    /// Stops the coroutines
    /// </summary>
    private void StopCheckForPotentialMatches()
    {
        if (AnimatePotentialMatchesCoroutine != null)
            StopCoroutine(AnimatePotentialMatchesCoroutine);
        if (CheckPotentialMatchesCoroutine != null)
            StopCoroutine(CheckPotentialMatchesCoroutine);
        ResetOpacityOnPotentialMatches();
    }

    /// <summary>
    /// Resets the opacity on potential matches (probably user dragged something?)
    /// </summary>
    private void ResetOpacityOnPotentialMatches()
    {
        if (potentialMatches != null)
            foreach (var item in potentialMatches)
            {
                if (item == null) break;

                Color c = item.GetComponent<SpriteRenderer>().color;
                c.a = 1.0f;
                item.GetComponent<SpriteRenderer>().color = c;
            }
    }

    /// <summary>
    /// Finds potential matches
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckPotentialMatches()
    {
        yield return new WaitForSeconds(Constants.WaitBeforePotentialMatchesCheck);
        potentialMatches = Utilities.GetPotentialMatches(shapes);
        if (potentialMatches != null)
        {
            while (true)
            {

                AnimatePotentialMatchesCoroutine = Utilities.AnimatePotentialMatches(potentialMatches);
                StartCoroutine(AnimatePotentialMatchesCoroutine);
                yield return new WaitForSeconds(Constants.WaitBeforePotentialMatchesCheck);
            }
        }
    }

    /// <summary>
    /// Gets a specific candy or Bonus based on the premade level information.
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    private GameObject GetSpecificCandyOrBonusForPremadeLevel(string info)
    {
        var tokens = info.Split('_');

        if (tokens.Count() == 1)
        {
            foreach (var item in CandyPrefabs)
            {
                if (item.GetComponent<Shape>().Type.Contains(tokens[0].Trim()))
                    return item;
            }

        }
        else if (tokens.Count() == 2 && tokens[1].Trim() == "B")
        {
            foreach (var item in BonusPrefabs)
            {
                if (item.name.Contains(tokens[0].Trim()))
                    return item;
            }
        }

        throw new Exception("Wrong type, check your premade level");
    }

    private GameObject GetNeighbourShape(GameObject go, Direction direction)
    {
        var shape = go.GetComponent<Shape>();
        
        int row = -1, 
            column = -1; 
        
        switch (direction)
        {
            case Direction.Down:
                row = shape.Row - 1;
                column = shape.Column;
                break;
            case Direction.Right:
                row = shape.Row;
                column = shape.Column + 1;
                break;
            case Direction.Up:
                row = shape.Row + 1;
                column = shape.Column;
                break;
            case Direction.Left:
                row = shape.Row;
                column = shape.Column - 1;
                break;
        }

        if (row >= 0 && column >= 0 && row < Constants.Rows && column < Constants.Columns)
        {
            return shapes[row, column];
        }
        else
        {
            return null;
        }
    }
}