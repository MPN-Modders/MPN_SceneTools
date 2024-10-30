﻿using UnityEngine;

public class SceneEditorHelpers
{
    // A collection of values that should not appear as Scripts, and a place to
    // set up static classes for editor functions if any ever arrise.
}

// INACCESIBLE PARENT CLASSES

public class Marker : MonoBehaviour
{
    [Tooltip("Used by the Event System to target this MarkerObj.")]
    public string SerialNumber = ""; // NOTE: UNUSED UNTIL EVENT SYSTEM IS IMPLEMENTED // 
}

public class ProxyObj : MonoBehaviour
{
    [Tooltip("Used by the Event System to target this ProxyObj.")]
    public string SerialNumber = ""; // NOTE: UNUSED UNTIL EVENT SYSTEM IS IMPLEMENTED // 
}
public class ProxyObj_Base : ProxyObj
{
    // Non-Room Proxies
}


public enum AlertStatus { Unaware, Hunting, Combat, Match = 100 }
public enum ControllerType { Empty, Player, Network, NPC, Boss, Simple, Bot, Turret, DEFAULT = 100 }
public enum Factions { Player, TwoShoes, AAHW, Nexus, MERCs, Bandits, Daisies, Zeds, None, Environment, Neutral, Enemy, Toughs, Spaghett, Vampires, N51, PrivSec, Machine, Any = 100, }
public enum CharacterTypes
{
    AAHW0_Grunt, AAHW1_Agent, AAHW2_Engineer, AAHW3_Soldat, AAHW4_HalfMag, AAHW_Mag, Abomination, Abomination_Lamenter, Abomination_Odium, Arena_Airman, Arena_Bossman, Arena_Doctor, Arena_Pilot, Arena_Quartermaster, Arena_Troop_A, Arena_Troop_B, Arena_Troop_C,
    Asylum_Harmacist, Asylum_Harmacist_Brute, Asylum_Orderly, Bandit_Brute, Bandit_Cyber, Bandit_Cyber_Brute, Bandit_Fanatic, Bandit_Fanatic__Prophet, Bandit_Graveseeker, Bandit_Grunt, Bandit_Mag, Bandit_Survivor, Boo_Demoniac, Boo_Demoniac_Demonstrator, Boo_HuskMan,
    Boo_WildLander, Chef, Cityboy, CityBoy_Raver, Cityboy_Vagrant, Clock_Brute, Clock_Brute_Static, Clock_Brute_Thaum, Clock_Grunt, Clock_Grunt_Acid, Clock_Grunt_Cryo, Clock_Grunt_Fire, Crackpot, Deimos, DJ_Cheshyre, DJ_Locknarr, Doc, DrChristoff, DrCrackpot, DrGonne,
    DrGonne_Holo, DrHofnarr, G03LM, G03LM__Dissonant, G03LM__Mk1, G03LM__Mk2, G03LM__Mk3, G03LM__MkZ, G03LM__Sleepwalker, Gang1a_Tough, Gang1b_Tony, Gang1c_NightTough, Gang2a_Toady, Gang2b_Button, Gang3a_VampPunk, Gang3b_VampPunk_Big, Gestalt, Gestalt__V2, Gestalt__V3,
    Ghost, Goyle, Halloween_Bloodsucker, Hank, Hank_P, Hank_W, Heister0_BanditConscript, Heister1_Rifleman, Heister1b_Lineman, Heister2_Pugilist, Heister3_Lawman, Heister3b_Ranger, Hiveslug, Jeb, Merc0_Grunt, Merc0_Grunt_laborer, Merc1_Zerker, Merc2_Sniper, Merc3_HvyGunner,
    Merc4_Sarge, Merc5_Captain, Mercenary, N51_0_Recon, N51_1_Assassin, N51_2_Commando, N51_3_Overwatch, N51_4_Delta, N51_5_Officer, N51_6_Mortar, Nexus1_Agent, Nexus2_Scout, Nexus3_Support, Nexus4_Riot__Guard, Nexus5_Engineer, Nexus6_Soldat, Nexus_MagUnfinished,
    Nexus_Scientist, Patient_Asylum, Patient_Sleepwalker, Rich, Robot_1, Robot_2, Robot_3, Robot_G03LM, Sanford, Santabot, Scientist, Sheriff, Slayer, Specter, Specter2, Specter3, Specter_Offering, TowerGuard0__Red, TowerGuard1__Blue, TowerGuard2__Yellow, TowerGuard3__Black,
    Training_0, Training_1, Training_2, Training_3, Tricky, Twin__Church__v1, Twin__Church__v2, Twin__Church__v3, Twin__Church__v4, Twin__Jorge__v1, Twin__Jorge__v2, Twin__Jorge__v3, Twin__Jorge__v4, VG0_Swarmer, VG1_Knife, VG2_Commando, VG3_Hunter, VG4_Elf, VG5_Bully,
    VG6_Rook, VG7_Moosher, Victor, Z_TestVictim, Zed, Zed_Gil, Zed_Honk, Zed_Swamp,
}

public enum VocationList { Nimble, Demolition, Hacker, Dissonant, Zed, Mag,Medical, Service,Swimmer, Civilian, Excavator, Ghost, Occult, Loner, Mechanic,Security, Digital, Clockwork, NONE = 100, IMPOSSIBLE, DEFAULT = 1000 }

public enum AffectCharacters { None, Everyone, NonEssentials, Essentials, PlayerSquad, Bosses, NotWaterproof }