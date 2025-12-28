using Corwarx_Project.Features.UpdateInjector.Attributies;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Updater : MonoBehaviour {
    public static Updater Instance;

    private static readonly List<Action> _updates = new List<Action>();

    public void Init() {
        Log.Debug("Updater inicialized");
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
            Log.Debug($"Processing assembly: {assembly.FullName}");
            foreach (Type type in assembly.GetTypes()) {
                foreach (MethodInfo method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Where(x => x.GetCustomAttribute<UpdateAttribute>() != null)) {
                    Action action = (Action)Delegate.CreateDelegate(typeof(Action), method);
                    _updates.Add(action);
                    Log.Send($"[Corwarx_Core] Register Method: {action.Method.Name}", Discord.LogLevel.Debug, ConsoleColor.Cyan);
                }
            }
        }
        Log.Debug($"Registered methods: {_updates.Count}");
    }

    private void OnEnable() {
        Instance = this;
    }

    private void Update() {
        for (int i = 0; i < _updates.Count; i++)
            _updates[i]();
    }

    private void OnDisable() {
        Instance = null;
    }
}