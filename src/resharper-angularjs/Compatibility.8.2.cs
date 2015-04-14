﻿#region license
// Copyright 2014 JetBrains s.r.o.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion


// Compatibility shims to get a clean compile for both 8.2 and 9.0

using JetBrains.ReSharper.Feature.Services.CodeCompletion;
using JetBrains.ReSharper.Feature.Services.Lookup;

public static class CompatibilityExtensions
{
    public static bool IsAutomaticCompletion(this CodeCompletionParameters parameters)
    {
        return parameters.LastCodeCompletionType == CodeCompletionType.AutomaticCompletion;
    }

    public static void Add(this GroupedItemsCollector collector, ILookupItem item)
    {
        collector.AddAtDefaultPlace(item);
    }
}

#region Namespaces in 9.0 that don't exist in 8.2

// ReSharper disable once CheckNamespace
namespace JetBrains.ReSharper
{
    namespace Feature.Services.CodeCompletion.Infrastructure
    {
        namespace LookupItems
        {
            namespace Impl
            {
            }
        }

        namespace Match
        {
        }
    }

    namespace Features.Intellisense.CodeCompletion.Html
    {
    }
}

#endregion

// IParameterInfoProvidingLookupItem has been replaced with IParameterInfoCandidatesProvider. Fortunately, exactly the
// same signature
namespace JetBrains.ReSharper.Feature.Services.CodeCompletion.Infrastructure.LookupItems
{
    public interface IParameterInfoCandidatesProvider :
        Lookup.IParameterInfoProvidingLookupItem
    {
    }
}