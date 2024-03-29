﻿using System;
using System.Collections.Generic;
using Other.MatchThreeGame.Assets.Scripts.UI;
using UnityEngine;

namespace DefaultNamespace.Common
{
    public class GlobalSerializedState
    {
        public Observable<int> CoinCount = new PrefsIntObservable("CoinCount");
        public Observable<string> CurrentSceneId = new PrefsStringObservable("CurrentSceneId");
        public Observable<bool> IsGameStarted = new PrefsBoolObservable("IsGameStarted");
        public Observable<int> ThreeInARowLifes = new PrefsIntObservable("ThreeInARowLifes");
        public Observable<DateTime> LastLifeCountdownUpdate = new PrefsDateTimeObservable("LastLifeCountdownUpdate");
        public ListObservable<string> OpenedJournalItemIds = new PrefsListOfStringObservable("OpenedJournalItems");
        public DictionaryObservable<string, int> AddedInventoryItems = new PrefsDictionaryObservable("AddedInventoryItems1");        
        public ListObservable<string> HiddenQuestNodeIds = new PrefsListOfStringObservable("HiddenQuestNodes");
        public ListObservable<string> UnseenJournalItemIds = new PrefsListOfStringObservable("UnseenJournalItems");
        public ListObservable<string> UnseenInventoryItemIds = new PrefsListOfStringObservable("UnseenInventoryItems");

        private static GlobalSerializedState _instance;

        private GlobalSerializedState() { }
        
        public static GlobalSerializedState Get()
        {
            if (_instance == null)
            {
                _instance = new GlobalSerializedState();
            }

            return _instance;
        }

        public void Reset()
        {
            CoinCount.Value = PrefsDefaultValues.CoinCount;
            CurrentSceneId.Value = PrefsDefaultValues.CurrentSceneId;
            IsGameStarted.Value = PrefsDefaultValues.IsGameStarted;
            ThreeInARowLifes.Value = PrefsDefaultValues.ThreeInARowLifes;
            LastLifeCountdownUpdate.Value = PrefsDefaultValues.LastLifeCountdownUpdate; 
            OpenedJournalItemIds.SetValues(PrefsDefaultValues.OpenedJournalItemIds);
            AddedInventoryItems.SetValues(PrefsDefaultValues.AddedInventoryItemIds);
            HiddenQuestNodeIds.SetValues(PrefsDefaultValues.HiddenQuestNodeIds);
            UnseenJournalItemIds.SetValues(PrefsDefaultValues.UnseenJournalItemIds);
            UnseenInventoryItemIds.SetValues(PrefsDefaultValues.UnseenInventoryItemIds);
            PlayerPrefs.SetString("AddedInventoryItems", "");
        }
    }
}