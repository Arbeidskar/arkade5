﻿using System;
using System.IO;
using Arkivverket.Arkade.Core.Base;
using Arkivverket.Arkade.Core.ExternalModels.SubmissionDescription;
using Arkivverket.Arkade.Core.Metadata;
using FluentAssertions;
using Xunit;

namespace Arkivverket.Arkade.Core.Tests.Metadata
{
    public class SubmissionDecriptionLoaderTest
    {
        [Fact]
        public void DiasMetsIsSuccessfullyLoadedIntoArchiveMetadataObject()
        {
            string diasMetsFile = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "TestData", "Metadata", "SubmissionDescriptionLoader", "submissionDescription.xml"
            );

            ArchiveMetadata archiveMetadata = SubmissionDescriptionLoader.Load(diasMetsFile);

            archiveMetadata.Label.Should().Be("Some system name (2017 - 2020)");

            archiveMetadata.ArchiveDescription.Should().Be("Some archive description");

            archiveMetadata.AgreementNumber.Should().Be("XX 00-0000/0000; 0000-00-00");

            archiveMetadata.RecordStatus.Should().Be(metsTypeMetsHdrRECORDSTATUS.NEW.ToString());

            archiveMetadata.DeliveryType.Should().Be("Sak-/Arkivsystem");

            archiveMetadata.PackageNumber.Should().Be("1.0");

            archiveMetadata.ReferenceCode.Should().Be("Some reference code");

            archiveMetadata.ArchiveCreators.Should().Contain(a =>
                a.Entity.Equals("Entity 1") &&
                a.ContactPerson.Equals("Contactperson 1") &&
                a.Address.Equals("Road 1, 1000 City") &&
                a.Telephone.Equals("1-99999999") &&
                a.Email.Equals("post@entity-1.com")
            );
            archiveMetadata.ArchiveCreators.Should().Contain(a =>
                a.Entity.Equals("Entity 2") &&
                a.ContactPerson.Equals("Contactperson 2") &&
                a.Address.Equals("Road 2, 2000 City") &&
                a.Telephone.Equals("2-99999999") &&
                a.Email.Equals("post@entity-2.com")
            );

            archiveMetadata.Transferer.Entity.Should().Be("Entity 3");
            archiveMetadata.Transferer.ContactPerson.Should().Be("Contactperson 3");
            archiveMetadata.Transferer.Address.Should().Be("Road 3, 3000 City");
            archiveMetadata.Transferer.Telephone.Should().Be("3-99999999");
            archiveMetadata.Transferer.Email.Should().Be("post@entity-3.com");

            archiveMetadata.Producer.Entity.Should().Be("Entity 4");
            archiveMetadata.Producer.ContactPerson.Should().Be("Contactperson 4");
            archiveMetadata.Producer.Address.Should().Be("Road 4, 4000 City");
            archiveMetadata.Producer.Telephone.Should().Be("4-99999999");
            archiveMetadata.Producer.Email.Should().Be("post@entity-4.com");

            archiveMetadata.Owners.Should().Contain(a =>
                a.Entity.Equals("Entity 5") &&
                a.ContactPerson.Equals("Contactperson 5") &&
                a.Address.Equals("Road 5, 5000 City") &&
                a.Telephone.Equals("5-99999999") &&
                a.Email.Equals("post@entity-5.com")
            );
            archiveMetadata.Owners.Should().Contain(a =>
                a.Entity.Equals("Entity 6") &&
                a.ContactPerson.Equals("Contactperson 6") &&
                a.Address.Equals("Road 6, 6000 City") &&
                a.Telephone.Equals("6-99999999") &&
                a.Email.Equals("post@entity-6.com")
            );

            archiveMetadata.Creator.Entity.Should().Be("Entity 7");
            archiveMetadata.Creator.ContactPerson.Should().Be("Contactperson 7");
            archiveMetadata.Creator.Address.Should().Be("Road 7, 7000 City");
            archiveMetadata.Creator.Telephone.Should().Be("7-99999999");
            archiveMetadata.Creator.Email.Should().Be("post@entity-7.com");

            archiveMetadata.Recipient.Should().Be("Some recipient");

            archiveMetadata.System.Name.Should().Be("Some system name");
            archiveMetadata.System.Version.Should().Be("v1.0.0");
            archiveMetadata.System.Type.Should().Be("Noark5");
            archiveMetadata.System.TypeVersion.Should().Be("v3.1");

            archiveMetadata.ArchiveSystem.Name.Should().Be("Some archive system name");
            archiveMetadata.ArchiveSystem.Version.Should().Be("v2.0.0");
            archiveMetadata.ArchiveSystem.Type.Should().Be("Noark5");
            archiveMetadata.ArchiveSystem.TypeVersion.Should().BeNull(); // Applies to Noark5 only

            archiveMetadata.StartDate.Should().Be(new DateTime(2017, 01, 01));
            archiveMetadata.EndDate.Should().Be(new DateTime(2020, 01, 01));
            archiveMetadata.ExtractionDate.Should().NotHaveValue();
        }
    }
}
