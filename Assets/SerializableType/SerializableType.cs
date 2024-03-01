using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableType<T> : ISerializationCallbackReceiver, IEquatable<SerializableType<T>>
{
    [field: System.NonSerialized] public System.Type Type { get; private set; } = null;
    [SerializeField, HideInInspector] string AssemblyQualifiedName = null;

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        // NOTE: This runs BEFORE Unity saves this object out

        AssemblyQualifiedName = Type == null ? null : Type.AssemblyQualifiedName;
    }

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        // NOTE: This runs AFTER Unity loads the object

        Type = string.IsNullOrEmpty(AssemblyQualifiedName) ? null : System.Type.GetType(AssemblyQualifiedName);
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as SerializableType<T>);
    }

    public bool Equals(SerializableType<T> other)
    {
        return other is not null &&
               AssemblyQualifiedName == other.AssemblyQualifiedName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(AssemblyQualifiedName);
    }

    public static bool operator ==(SerializableType<T> left, SerializableType<T> right)
    {
        return EqualityComparer<SerializableType<T>>.Default.Equals(left, right);
    }

    public static bool operator !=(SerializableType<T> left, SerializableType<T> right)
    {
        return !(left == right);
    }
}
