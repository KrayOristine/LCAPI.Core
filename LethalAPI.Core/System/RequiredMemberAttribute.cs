﻿// -----------------------------------------------------------------------
// <copyright file="RequiredMemberAttribute.cs" company=".NET Foundation">
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

#pragma warning disable
// ReSharper disable CheckNamespace
namespace System.Runtime.CompilerServices;

/// <summary>Specifies that a type has required members or that a member is required.</summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
internal sealed class RequiredMemberAttribute : Attribute { }
#pragma warning restore
