// ***********************************************************************
// Assembly         : ADA.Core
// Author           : Hung Le
// Created          : 08-18-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-18-2016
// ***********************************************************************
// <copyright file="AppDomainTypeFinder.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ADA.Core.Infrastructure {
    /// <summary>
    /// A class that finds types needed by App by looping assemblies in the
    /// currently executing AppDomain. Only assemblies whose names matches
    /// certain patterns are investigated and an optional list of assemblies
    /// referenced by 
    /// <see cref="AssemblyNames" /> are always investigated.
    /// </summary>
    public class AppDomainTypeFinder: ITypeFinder {
        #region Fields

        /// <summary>
        /// The ignore reflection errors
        /// </summary>
        private bool ignoreReflectionErrors = true;
        /// <summary>
        /// The load application domain assemblies
        /// </summary>
        private bool loadAppDomainAssemblies = true;
        /// <summary>
        /// The assembly skip loading pattern
        /// </summary>
        private string assemblySkipLoadingPattern = "^System|^mscorlib|^Microsoft|^AjaxControlToolkit|^Antlr3|^Autofac|^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|^EntityFramework|^EPPlus|^FluentValidation|^ImageResizer|^itextsharp|^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|^Remotion|^RestSharp|^Rhino|^Telerik|^Iesi|^TestDriven|^TestFu|^UserAgentStringLibrary|^VJSharpCodeProvider|^WebActivator|^WebDev|^WebGrease";
        /// <summary>
        /// The assembly restrict to loading pattern
        /// </summary>
        private string assemblyRestrictToLoadingPattern = ".*";
        /// <summary>
        /// The assembly names
        /// </summary>
        private IList<string> assemblyNames = new List<string>();

        #endregion

        #region Properties

        /// <summary>
        /// The app domain to look for types in.
        /// </summary>
        /// <value>The application.</value>
        public virtual AppDomain App {
            get { return AppDomain.CurrentDomain; }
        }

        /// <summary>
        /// Gets or sets whether App should iterate assemblies in the app domain when loading App types. Loading patterns are applied when loading these assemblies.
        /// </summary>
        /// <value><c>true</c> if [load application domain assemblies]; otherwise, <c>false</c>.</value>
        public bool LoadAppDomainAssemblies {
            get { return loadAppDomainAssemblies; }
            set { loadAppDomainAssemblies = value; }
        }

        /// <summary>
        /// Gets or sets assemblies loaded a startup in addition to those loaded in the AppDomain.
        /// </summary>
        /// <value>The assembly names.</value>
        public IList<string> AssemblyNames {
            get { return assemblyNames; }
            set { assemblyNames = value; }
        }

        /// <summary>
        /// Gets the pattern for dlls that we know don't need to be investigated.
        /// </summary>
        /// <value>The assembly skip loading pattern.</value>
        public string AssemblySkipLoadingPattern {
            get { return assemblySkipLoadingPattern; }
            set { assemblySkipLoadingPattern = value; }
        }

        /// <summary>
        /// Gets or sets the pattern for dll that will be investigated. For ease of use this defaults to match all but to increase performance you might want to configure a pattern that includes assemblies and your own.
        /// </summary>
        /// <value>The assembly restrict to loading pattern.</value>
        /// <remarks>If you change this so that App assemblies arn't investigated (e.g. by not including something like "^App|..." you may break core functionality.</remarks>
        public string AssemblyRestrictToLoadingPattern {
            get { return assemblyRestrictToLoadingPattern; }
            set { assemblyRestrictToLoadingPattern = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the type of the classes of.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="onlyConcreteClasses">if set to <c>true</c> [only concrete classes].</param>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        public IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true) {
            return FindClassesOfType(typeof(T), onlyConcreteClasses);
        }

        /// <summary>
        /// Finds the type of the classes of.
        /// </summary>
        /// <param name="assignTypeFrom">The assign type from.</param>
        /// <param name="onlyConcreteClasses">if set to <c>true</c> [only concrete classes].</param>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true) {
            return FindClassesOfType(assignTypeFrom, GetAssemblies(), onlyConcreteClasses);
        }

        /// <summary>
        /// Finds the type of the classes of.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblies">The assemblies.</param>
        /// <param name="onlyConcreteClasses">if set to <c>true</c> [only concrete classes].</param>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        public IEnumerable<Type> FindClassesOfType<T>(IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true) {
            return FindClassesOfType(typeof(T), assemblies, onlyConcreteClasses);
        }

        /// <summary>
        /// Finds the type of the classes of.
        /// </summary>
        /// <param name="assignTypeFrom">The assign type from.</param>
        /// <param name="assemblies">The assemblies.</param>
        /// <param name="onlyConcreteClasses">if set to <c>true</c> [only concrete classes].</param>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true) {
            var result = new List<Type>();
            try {
                foreach(var a in assemblies) {
                    Type[] types = null;
                    try {
                        types = a.GetTypes();
                    } catch {
                        //Entity Framework 6 doesn't allow getting types (throws an exception)
                        if(!ignoreReflectionErrors) {
                            throw;
                        }
                    }
                    if(types != null) {
                        foreach(var t in types) {
                            if(assignTypeFrom.IsAssignableFrom(t) || (assignTypeFrom.IsGenericTypeDefinition && DoesTypeImplementOpenGeneric(t, assignTypeFrom))) {
                                if(!t.IsInterface) {
                                    if(onlyConcreteClasses) {
                                        if(t.IsClass && !t.IsAbstract) {
                                            result.Add(t);
                                        }
                                    } else {
                                        result.Add(t);
                                    }
                                }
                            }
                        }
                    }
                }
            } catch(ReflectionTypeLoadException ex) {
                var msg = string.Empty;
                foreach(var e in ex.LoaderExceptions)
                    msg += e.Message + Environment.NewLine;

                var fail = new Exception(msg, ex);
                Debug.WriteLine(fail.Message, fail);

                throw fail;
            }
            return result;
        }

        /// <summary>
        /// Gets the assemblies related to the current implementation.
        /// </summary>
        /// <returns>A list of assemblies that should be loaded by the App factory.</returns>
        public virtual IList<Assembly> GetAssemblies() {
            var addedAssemblyNames = new List<string>();
            var assemblies = new List<Assembly>();

            if(LoadAppDomainAssemblies)
                AddAssembliesInAppDomain(addedAssemblyNames, assemblies);
            AddConfiguredAssemblies(addedAssemblyNames, assemblies);

            return assemblies;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Iterates all assemblies in the AppDomain and if it's name matches the configured patterns add it to our list.
        /// </summary>
        /// <param name="addedAssemblyNames">The added assembly names.</param>
        /// <param name="assemblies">The assemblies.</param>
        private void AddAssembliesInAppDomain(List<string> addedAssemblyNames, List<Assembly> assemblies) {
            foreach(Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                if(Matches(assembly.FullName)) {
                    if(!addedAssemblyNames.Contains(assembly.FullName)) {
                        assemblies.Add(assembly);
                        addedAssemblyNames.Add(assembly.FullName);
                    }
                }
            }
        }

        /// <summary>
        /// Adds specifically configured assemblies.
        /// </summary>
        /// <param name="addedAssemblyNames">The added assembly names.</param>
        /// <param name="assemblies">The assemblies.</param>
        protected virtual void AddConfiguredAssemblies(List<string> addedAssemblyNames, List<Assembly> assemblies) {
            foreach(string assemblyName in AssemblyNames) {
                Assembly assembly = Assembly.Load(assemblyName);
                if(!addedAssemblyNames.Contains(assembly.FullName)) {
                    assemblies.Add(assembly);
                    addedAssemblyNames.Add(assembly.FullName);
                }
            }
        }

        /// <summary>
        /// Check if a dll is one of the shipped dlls that we know don't need to be investigated.
        /// </summary>
        /// <param name="assemblyFullName">The name of the assembly to check.</param>
        /// <returns>True if the assembly should be loaded into Nop.</returns>
        public virtual bool Matches(string assemblyFullName) {
            return !Matches(assemblyFullName, AssemblySkipLoadingPattern)
                   && Matches(assemblyFullName, AssemblyRestrictToLoadingPattern);
        }

        /// <summary>
        /// Check if a dll is one of the shipped dlls that we know don't need to be investigated.
        /// </summary>
        /// <param name="assemblyFullName">The assembly name to match.</param>
        /// <param name="pattern">The regular expression pattern to match against the assembly name.</param>
        /// <returns>True if the pattern matches the assembly name.</returns>
        protected virtual bool Matches(string assemblyFullName, string pattern) {
            return Regex.IsMatch(assemblyFullName, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        /// <summary>
        /// Makes sure matching assemblies in the supplied folder are loaded in the app domain.
        /// </summary>
        /// <param name="directoryPath">The physical path to a directory containing dlls to load in the app domain.</param>
        protected virtual void LoadMatchingAssemblies(string directoryPath) {
            var loadedAssemblyNames = new List<string>();
            foreach(Assembly a in GetAssemblies()) {
                loadedAssemblyNames.Add(a.FullName);
            }

            if(!Directory.Exists(directoryPath)) {
                return;
            }

            foreach(string dllPath in Directory.GetFiles(directoryPath, "*.dll")) {
                try {
                    var an = AssemblyName.GetAssemblyName(dllPath);
                    if(Matches(an.FullName) && !loadedAssemblyNames.Contains(an.FullName)) {
                        App.Load(an);
                    }

                    //old loading stuff
                    //Assembly a = Assembly.ReflectionOnlyLoadFrom(dllPath);
                    //if (Matches(a.FullName) && !loadedAssemblyNames.Contains(a.FullName))
                    //{
                    //    App.Load(a.FullName);
                    //}
                } catch(BadImageFormatException ex) {
                    Trace.TraceError(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Does type implement generic?
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="openGeneric">The open generic.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected virtual bool DoesTypeImplementOpenGeneric(Type type, Type openGeneric) {
            try {
                var genericTypeDefinition = openGeneric.GetGenericTypeDefinition();
                foreach(var implementedInterface in type.FindInterfaces((objType, objCriteria) => true, null)) {
                    if(!implementedInterface.IsGenericType)
                        continue;

                    var isMatch = genericTypeDefinition.IsAssignableFrom(implementedInterface.GetGenericTypeDefinition());
                    return isMatch;
                }
                return false;
            } catch {
                return false;
            }
        }

        #endregion
    }
}
