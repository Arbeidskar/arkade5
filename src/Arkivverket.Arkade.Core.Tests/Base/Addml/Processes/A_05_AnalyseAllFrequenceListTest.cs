﻿using System.Collections.Generic;
using Arkivverket.Arkade.Core.Base;
using Arkivverket.Arkade.Core.Base.Addml;
using Arkivverket.Arkade.Core.Base.Addml.Definitions;
using Arkivverket.Arkade.Core.Base.Addml.Processes;
using Arkivverket.Arkade.Core.Tests.Base.Addml.Builders;
using FluentAssertions;
using Xunit;

namespace Arkivverket.Arkade.Core.Tests.Base.Addml.Processes
{
    public class A_05_AnalyseAllFrequenceListTest : LanguageDependentTest
    {
        [Fact]
        public void ShouldOnlyCreateFrequencyListOfCodeDefinitions()
        {
            AddmlFieldDefinition fieldDefinitionWithCodeList = new AddmlFieldDefinitionBuilder()
                .WithCodeList(new List<AddmlCode>
                {
                    new AddmlCode("A", ""),
                    new AddmlCode("B", ""),
                    new AddmlCode("C", ""),
                })
                .Build();
            AddmlFieldDefinition fieldDefinitionWithoutCodeList = new AddmlFieldDefinitionBuilder()
                .WithRecordDefinition(fieldDefinitionWithCodeList.AddmlRecordDefinition)
                .Build();
            FlatFile flatFile = new FlatFile(fieldDefinitionWithCodeList.GetAddmlFlatFileDefinition());

            A_05_AnalyseAllFrequenceList test = new A_05_AnalyseAllFrequenceList();
            test.Run(flatFile);
            test.Run(new Field(fieldDefinitionWithCodeList, "A"), 1);
            test.Run(new Field(fieldDefinitionWithCodeList, "A"), 1);
            test.Run(new Field(fieldDefinitionWithCodeList, "B"), 1);
            test.Run(new Field(fieldDefinitionWithCodeList, "B"), 1);
            test.Run(new Field(fieldDefinitionWithCodeList, "B"), 1);
            test.Run(new Field(fieldDefinitionWithCodeList, "C"), 1);
            test.Run(new Field(fieldDefinitionWithoutCodeList, "A"), 1);
            test.Run(new Field(fieldDefinitionWithoutCodeList, "A"), 1);
            test.Run(new Field(fieldDefinitionWithoutCodeList, "B"), 1);
            test.Run(new Field(fieldDefinitionWithoutCodeList, "B"), 1);
            test.Run(new Field(fieldDefinitionWithoutCodeList, "C"), 1);
            test.EndOfFile();

            TestRun testRun = test.GetTestRun();
            testRun.IsSuccess().Should().BeTrue();
            testRun.TestResults.GetNumberOfResults().Should().Be(3);
            testRun.TestResults.TestsResults[0].Location.ToString().Should().Be(fieldDefinitionWithCodeList.GetIndex().ToString());
            testRun.TestResults.TestsResults[0].Message.Should().Be("2 forekomster av A");
            testRun.TestResults.TestsResults[1].Location.ToString().Should().Be(fieldDefinitionWithCodeList.GetIndex().ToString());
            testRun.TestResults.TestsResults[1].Message.Should().Be("3 forekomster av B");
            testRun.TestResults.TestsResults[2].Location.ToString().Should().Be(fieldDefinitionWithCodeList.GetIndex().ToString());
            testRun.TestResults.TestsResults[2].Message.Should().Be("1 forekomster av C");
        }
    }
}