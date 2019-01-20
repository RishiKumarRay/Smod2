﻿using System.Collections.Generic;

namespace Smod2.API
{
	public abstract class Map
	{
		public abstract List<Item> GetItems(ItemType type, bool world_only);
		public abstract Vector GetRandomSpawnPoint(Role role);
		public abstract List<Vector> GetSpawnPoints(Role role);
		public abstract List<Vector> GetBlastDoorPoints();
		public abstract List<Door> GetDoors();
		public abstract List<PocketDimensionExit> GetPocketDimensionExits();
		public abstract Dictionary<Vector, Vector> GetElevatorTeleportPoints();
		public abstract Generator[] GetGenerators();
		public abstract void Shake();
		public abstract bool WarheadDetonated { get; }
		public abstract bool LCZDecontaminated { get; }
		public abstract void SpawnItem(ItemType type, Vector position, Vector rotation);
		/// <summary>  
		/// Note: When FemurBreaker is enabled, SCP-106 can't be contained. This might break the lure configs and mechanism.
		/// </summary> 
		public abstract void FemurBreaker(bool enable);
		public abstract List<Elevator> GetElevators();
		public abstract void SetIntercomContent(IntercomStatus intercomStatus, string content);
		public abstract string GetIntercomContent(IntercomStatus intercomStatus);
		public abstract List<TeslaGate> GetTeslaGates();
		public abstract void AnnounceNtfEntrance(int scpsLeft, int mtfNumber, char mtfLetter);
		public abstract void AnnounceScpKill(string scpNumber, Player killer = null);
		public abstract void AnnounceCustomMessage(string words);
		public abstract void SetIntercomSpeaker(Player player);
		public abstract Player GetIntercomSpeaker();
		public abstract void Broadcast(uint duration, string message, bool isMonoSpaced);
		public abstract void ClearBroadcasts();
	}

	public abstract class Door
	{
		public abstract bool Open { get; set; }
		public abstract bool Destroyed { get; set; }
		public abstract bool DontOpenOnWarhead { get; set; }
		public abstract bool BlockAfterWarheadDetonation { get; set; }
		public abstract bool Locked { get; set; }
		public abstract float LockCooldown { get; set; }
		public abstract Vector Position { get; }
		public abstract string Name { get; }
		public abstract string Permission { get; }
		public abstract object GetComponent();
	}

	public abstract class TeslaGate
	{
		public abstract void Activate(bool instant = false);
		public abstract float TriggerDistance { get; set; }
		public abstract Vector Position { get; }
		public abstract object GetComponent();
	}

	public enum ElevatorType
	{
		LiftA = 0,
		LiftB = 1,
		GateA = 2,
		GateB = 3,
		WarheadRoom = 4,
		SCP049Chamber = 5
	}

	public enum ElevatorStatus
	{
		Up,
		Down,
		Moving
	}

	public enum IntercomStatus
	{
		Muted,
		Restarting,
		Transmitting_Admin,
		Transmitting_Bypass,
		Transmitting,
		Ready
	}

	public abstract class Elevator
	{
		public abstract ElevatorType ElevatorType { get; }
		public abstract ElevatorStatus ElevatorStatus { get; }
		public abstract void Use();
		public abstract bool Locked { get; set; }
		public abstract bool Lockable { get; set; }
		public abstract float MovingSpeed { get; set; }
		public abstract List<Vector> GetPositions();
	}

	public enum PocketDimensionExitType
	{
		Killer = 0,
		Exit = 1
	}

	public abstract class PocketDimensionExit
	{
		public abstract PocketDimensionExitType ExitType { get; set; }
		public abstract Vector Position { get; }
	}

	public enum GeneratorType
	{
		UNDEFINED = -1,
		ENTRANCE_CHECKPOINT = 0,
		HCZ_ARMORY = 1,
		SERVER_ROOM = 2,
		MICROHID = 3,
		NUKE = 4,
		SCP_049 = 5,
		SCP_079 = 6,
		SCP_096 = 7,
		SCP_106 = 8,
		SCP_939 = 9
	}

	public abstract class Generator
	{
		public abstract bool Open { get; set; }
		public abstract bool Locked { get; set; }
		public abstract bool HasTablet { get; set; }
		public abstract bool Engaged { get; set; }
		public abstract GeneratorType Type { get; }
		public abstract float TimeLeft { get; set; }
		public abstract Vector Position { get; }
	}

	public enum ZoneType
	{
		UNDEFINED = -1,
		LCZ = 0,
		HCZ = 1
	}

	public abstract class Room
	{
		public abstract string ZoneName { get; }
		public abstract ZoneType Zone { get; }
		public abstract string Name { get; }

		public abstract void FlickerLights();
	}
}
