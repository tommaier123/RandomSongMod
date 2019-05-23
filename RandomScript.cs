using UnityEngine;
using System.Collections;
using UMod;
using Synth.mods.utils;
using Synth.mods.events;
using Synth.mods.info;
using System.Collections.Generic;
using Synth.mods.interactions;
using System;

public class RandomScript : ModScript, ISynthRidersEvents, ISynthRidersInfo, ISynthRidersInteractions {

	public override void OnModLoaded()
	{
        GameObject obj = ModAssets.Instantiate<GameObject>("RandomButton_pre");
	}

    public override void OnModUnload()
    {		
        RandomButton.DestroyRandomButton();
	}

    public void OnRoomLoaded()
    {
        RandomButton.Show();
    }

    public void OnRoomUnloaded()
    {
        RandomButton.Hide();
    }

    public void OnGameStageLoaded(TrackData trackData)
    {

    }

    public void OnGameStageUnloaded()
    {
  
    }	

    public void OnScoreStageLoaded()
    {

    }

    public void OnScoreStageUnloaded()
    {

    }

    public void OnNoteFail(PointsData pointsData)
    {

    }

    public void OnPointScored(PointsData pointsData)
    {

    }

    public void OnSongFinished(SongFinishedData songFinishedData)
    {

    }

    public void OnSongFailed(TrackData trackData)
    {

    }

    public void SetLoadedTracks(List<TrackData> tracks)
    {
        RandomButton.LoadedTracks = tracks;
    }

    public void SetLoadedStages(List<StageData> stages)
    {

    }

    public void SetUserSelectedColors(Color leftHandColor, Color rightHandColor, Color oneHandSpecialColor, Color bothHandSpecialColor)
    {

    }

    public void SetUICanvasCallback(Action<GameObject> callback)
    {
        RandomButton.UICallback = callback;
        RandomButton.InitCanvasVRTK();
    }

    public void SetGameOverCallback(Action callback)
    {

    }

    public void SetPlayTrackCallback(Action<int, int, int> callback)
    {
        
    }

    public void SetCurrentSongSelected(int CurrentSong)
    {

    }

    public void SetSelectedTrackCallback(Action<int> callback)
    {
        RandomButton.SelectedCallback = callback;
    }

    public void SetRefreshCallback(Action<Action, bool> callback)
    {
        
    }

    public void SetFilterTrackCallback(Action<List<string>, Action, bool> callback)
    {
        
    }
}
