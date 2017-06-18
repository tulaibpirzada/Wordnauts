using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants : MonoBehaviour {
	public enum Screens {
		SPLASH_SCREEN,
		MAIN_MENU_SCREEN,
		SINGLE_CLUE_PUZZLE_PACK_SELECTION_SCREEN,
		SINGLE_CLUE_LEVEL_SELECTION_SCREEN,
		MULTI_CLUE_LEVEL_SELECTION_SCREEN,
        LEVEL_START_SCREEN,
        GAME_PLAY_SCREEN,
		LEVEL_END_SCREEN,
        SETTINGS_SCREEN,
        NO_MORE_DAILY_LEVELS_POPUP,
        PUZZLE_PACK_LOCKED_BY_PRESTIGE_POPUP
	}
}
