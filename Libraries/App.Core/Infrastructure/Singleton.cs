// ***********************************************************************
// Assembly         : ADA.Core
// Author           : Hung Le
// Created          : 08-18-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-18-2016
// ***********************************************************************
// <copyright file="Singleton.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace ADA.Core.Infrastructure
{
    /// <summary>
    /// A statically compiled "singleton" used to store objects throughout the
    /// lifetime of the app domain. Not so much singleton in the pattern's
    /// sense of the word as a standardized way to store single instances.
    /// </summary>
    /// <typeparam name="T">The type of object to store.</typeparam>
    /// <remarks>Access to the instance is not synchrnoized.</remarks>
    public class Singleton<T> : Singleton
    {
        /// <summary>
        /// The instance
        /// </summary>
        static T instance;

        /// <summary>
        /// The singleton instance for the specified type T. Only one instance (at the time) of this object for each type of T.
        /// </summary>
        /// <value>The instance.</value>
        public static T Instance
        {
            get { return instance; }
            set
            {
                instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }

    /// <summary>
    /// Provides a singleton list for a certain type.
    /// </summary>
    /// <typeparam name="T">The type of list to store.</typeparam>
    public class SingletonList<T> : Singleton<IList<T>>
    {
        /// <summary>
        /// Initializes static members of the <see cref="SingletonList{T}"/> class.
        /// </summary>
        static SingletonList()
        {
            Singleton<IList<T>>.Instance = new List<T>();
        }

        /// <summary>
        /// The singleton instance for the specified type T. Only one instance (at the time) of this list for each type of T.
        /// </summary>
        /// <value>The instance.</value>
        public new static IList<T> Instance
        {
            get { return Singleton<IList<T>>.Instance; }
        }
    }

    /// <summary>
    /// Provides a singleton dictionary for a certain key and vlaue type.
    /// </summary>
    /// <typeparam name="TKey">The type of key.</typeparam>
    /// <typeparam name="TValue">The type of value.</typeparam>
    public class SingletonDictionary<TKey, TValue> : Singleton<IDictionary<TKey, TValue>>
    {
        /// <summary>
        /// Initializes static members of the <see cref="SingletonDictionary{TKey, TValue}"/> class.
        /// </summary>
        static SingletonDictionary()
        {
            Singleton<Dictionary<TKey, TValue>>.Instance = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// The singleton instance for the specified type T. Only one instance (at the time) of this dictionary for each type of T.
        /// </summary>
        /// <value>The instance.</value>
        public new static IDictionary<TKey, TValue> Instance
        {
            get { return Singleton<Dictionary<TKey, TValue>>.Instance; }
        }
    }

    /// <summary>
    /// Provides access to all "singletons" stored by <see cref="Singleton{T}" />.
    /// </summary>
    public class Singleton
    {
        /// <summary>
        /// Initializes static members of the <see cref="Singleton"/> class.
        /// </summary>
        static Singleton()
        {
            allSingletons = new Dictionary<Type, object>();
        }

        /// <summary>
        /// All singletons
        /// </summary>
        static readonly IDictionary<Type, object> allSingletons;

        /// <summary>
        /// Dictionary of type to singleton instances.
        /// </summary>
        /// <value>All singletons.</value>
        public static IDictionary<Type, object> AllSingletons
        {
            get { return allSingletons; }
        }
    }
}
