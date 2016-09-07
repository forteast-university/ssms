// ***********************************************************************
// Assembly         : ADA.Core
// Author           : Hung Le
// Created          : 08-18-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-18-2016
// ***********************************************************************
// <copyright file="ITypeFinder.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ADA.Core.Infrastructure
{
    /// <summary>
    /// Classes implementing this interface provide information about types
    /// to various services in the App engine.
    /// </summary>
    public interface ITypeFinder
    {
        /// <summary>
        /// Gets the assemblies.
        /// </summary>
        /// <returns>IList&lt;Assembly&gt;.</returns>
        IList<Assembly> GetAssemblies();

        /// <summary>
        /// Finds the type of the classes of.
        /// </summary>
        /// <param name="assignTypeFrom">The assign type from.</param>
        /// <param name="onlyConcreteClasses">if set to <c>true</c> [only concrete classes].</param>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true);

        /// <summary>
        /// Finds the type of the classes of.
        /// </summary>
        /// <param name="assignTypeFrom">The assign type from.</param>
        /// <param name="assemblies">The assemblies.</param>
        /// <param name="onlyConcreteClasses">if set to <c>true</c> [only concrete classes].</param>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);

        /// <summary>
        /// Finds the type of the classes of.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="onlyConcreteClasses">if set to <c>true</c> [only concrete classes].</param>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true);

        /// <summary>
        /// Finds the type of the classes of.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblies">The assemblies.</param>
        /// <param name="onlyConcreteClasses">if set to <c>true</c> [only concrete classes].</param>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        IEnumerable<Type> FindClassesOfType<T>(IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);
    }
}
