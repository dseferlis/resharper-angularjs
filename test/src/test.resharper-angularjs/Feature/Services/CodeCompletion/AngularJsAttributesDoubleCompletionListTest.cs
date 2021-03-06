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

using System;
using System.Collections.Generic;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.FeaturesTestFramework.Completion;
using JetBrains.ReSharper.TestFramework;
using JetBrains.Util;
using NUnit.Framework;

namespace JetBrains.ReSharper.Plugins.AngularJS.Feature.Services.CodeCompletion
{
    [Category("Code Completion")]
    [TestFileExtension(HtmlProjectFileType.HTML_EXTENSION)]
    public class AngularJsAttributesDoubleCompletionListTest : WebCodeCompletionTestBase
    {
        private Version currentVersion;

        protected override string RelativeTestDataPath { get { return @"CodeCompletion\Double\List"; } }

        protected override CodeCompletionTestType TestType
        {
            get { return CodeCompletionTestType.List; }
        }

        protected override string GetGoldTestDataPath(string fileName)
        {
            return base.GetGoldTestDataPath(fileName + AngularJsTestVersions.GetProductVersion(currentVersion));
        }

        [Test]
        [TestCaseSource(typeof (AngularJsTestVersions), "Versions")]
        public void TestShowAllItemsOnDoubleCompletionWithNoPrefix(Version version)
        {
            DoNamedTest2(version);
        }

        [Test]
        [TestCaseSource(typeof (AngularJsTestVersions), "Versions")]
        public void TestShowMatchingItemsOnDoubleCompletionWithPrefix(Version version)
        {
            DoNamedTest2(version);
        }

        private void DoNamedTest2(Version version)
        {
            currentVersion = version;
            DoNamedTest2();
        }

        protected override IEnumerable<FileSystemPath> GetFilesToIncludeInSolution(IEnumerable<FileSystemPath> files)
        {
            return files.Concat(FileSystemPath.Parse(AngularJsTestVersions.GetAngularJsVersion(BaseTestDataPath, currentVersion)));
        }
    }
}