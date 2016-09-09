// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="BaseEntity.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;

namespace App.Core.Domain{
    /// <summary>
    ///     Base class for entities
    /// </summary>
    public abstract class BaseEntity{
        /// <summary>
        ///     Gets or sets the entity identifier
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public int ID { get; set; }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj){
            return Equals(obj as BaseEntity);
        }

        /// <summary>
        ///     Determines whether the specified object is transient.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns><c>true</c> if the specified object is transient; otherwise, <c>false</c>.</returns>
        private static bool IsTransient(BaseEntity obj){
            return obj != null && Equals(obj.ID, default(int));
        }

        /// <summary>
        ///     Gets the type of the unproxied.
        /// </summary>
        /// <returns>Type.</returns>
        private Type GetUnproxiedType(){
            return GetType();
        }

        /// <summary>
        ///     Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool Equals(BaseEntity other){
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(ID, other.ID)){
                Type otherType = other.GetUnproxiedType();
                Type thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                       otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode(){
            if (Equals(ID, default(int)))
                return base.GetHashCode();
            return ID.GetHashCode();
        }

        /// <summary>
        ///     Implements the ==.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(BaseEntity x, BaseEntity y){
            return Equals(x, y);
        }

        /// <summary>
        ///     Implements the !=.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(BaseEntity x, BaseEntity y){
            return !(x == y);
        }
    }
}