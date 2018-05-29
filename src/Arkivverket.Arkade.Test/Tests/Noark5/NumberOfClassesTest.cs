using Arkivverket.Arkade.Core;
using Arkivverket.Arkade.Tests.Noark5;
using FluentAssertions;
using Xunit;

namespace Arkivverket.Arkade.Test.Tests.Noark5
{
    public class NumberOfClassesTest
    {
        [Fact]
        public void NumberOfClassesIsTwoInEachArchivePart()
        {
            XmlElementHelper helper = new XmlElementHelper().Add("arkiv",
                new XmlElementHelper()
                    // Arkivdel 1
                    .Add("arkivdel", new XmlElementHelper()
                        .Add("systemID", "someSystemId_1")
                        // Prim�rt klassifikasjonssystem (inneholder registrering eller mappe)
                        .Add("klassifikasjonssystem", new XmlElementHelper()
                            .Add("systemID", "klassSys_1")
                            .Add("registrering", new XmlElementHelper()
                                .Add("klasse", string.Empty)
                                .Add("klasse", new XmlElementHelper()
                                    .Add("klasse", new XmlElementHelper()))))
                        // Sekund�rt klassifikasjonssystem
                        .Add("klassifikasjonssystem", new XmlElementHelper()
                            .Add("systemID", "klassSys_2")
                            .Add("klasse", string.Empty)
                            .Add("klasse", new XmlElementHelper()
                                .Add("klasse", new XmlElementHelper()))))
                    // Arkivdel 2
                    .Add("arkivdel", new XmlElementHelper()
                        .Add("systemID", "someSystemId_2")
                        // Prim�rt klassifikasjonssystem (inneholder registrering eller mappe)
                        .Add("klassifikasjonssystem", new XmlElementHelper()
                            .Add("systemID", "klassSys_1")
                            .Add("mappe", new XmlElementHelper()
                                .Add("klasse", string.Empty)
                                .Add("klasse", new XmlElementHelper()
                                    .Add("klasse", new XmlElementHelper()))))
                        // Sekund�rt klassifikasjonssystem
                        .Add("klassifikasjonssystem", new XmlElementHelper()
                            .Add("systemID", "klassSys_2")
                            .Add("klasse", string.Empty)
                            .Add("klasse", new XmlElementHelper()
                                .Add("klasse", new XmlElementHelper())))));

            TestRun testRun = helper.RunEventsOnTest(new NumberOfClasses());

            testRun.Results.Should().Contain(r =>
                r.Message.Equals("Arkivdel (systemID): someSystemId_1 - Prim�rt klassifikasjonssystem (systemID): klassSys_1 - Totalt antall klasser: 3"));
            testRun.Results.Should().Contain(r =>
                r.Message.Equals("Arkivdel (systemID): someSystemId_1 - Prim�rt klassifikasjonssystem (systemID): klassSys_1 - Klasser p� niv� 1: 2"));
            testRun.Results.Should().Contain(r =>
                r.Message.Equals("Arkivdel (systemID): someSystemId_1 - Prim�rt klassifikasjonssystem (systemID): klassSys_1 - Klasser p� niv� 2: 1"));

            testRun.Results.Should().Contain(r =>
                r.Message.Equals("Arkivdel (systemID): someSystemId_1 - Sekund�rt klassifikasjonssystem (systemID): klassSys_2 - Totalt antall klasser: 3"));
            testRun.Results.Should().Contain(r =>
                r.Message.Equals("Arkivdel (systemID): someSystemId_1 - Sekund�rt klassifikasjonssystem (systemID): klassSys_2 - Klasser p� niv� 1: 2"));
            testRun.Results.Should().Contain(r =>
                r.Message.Equals("Arkivdel (systemID): someSystemId_1 - Sekund�rt klassifikasjonssystem (systemID): klassSys_2 - Klasser p� niv� 2: 1"));

            testRun.Results.Should().Contain(r =>
                r.Message.Equals("Arkivdel (systemID): someSystemId_2 - Prim�rt klassifikasjonssystem (systemID): klassSys_1 - Totalt antall klasser: 3"));
            testRun.Results.Should().Contain(r =>
                r.Message.Equals("Arkivdel (systemID): someSystemId_2 - Prim�rt klassifikasjonssystem (systemID): klassSys_1 - Klasser p� niv� 1: 2"));
            testRun.Results.Should().Contain(r =>
                r.Message.Equals("Arkivdel (systemID): someSystemId_2 - Prim�rt klassifikasjonssystem (systemID): klassSys_1 - Klasser p� niv� 2: 1"));

            testRun.Results.Should().Contain(r =>
                r.Message.Equals("Arkivdel (systemID): someSystemId_2 - Sekund�rt klassifikasjonssystem (systemID): klassSys_2 - Totalt antall klasser: 3"));
            testRun.Results.Should().Contain(r =>
                r.Message.Equals("Arkivdel (systemID): someSystemId_2 - Sekund�rt klassifikasjonssystem (systemID): klassSys_2 - Klasser p� niv� 1: 2"));
            testRun.Results.Should().Contain(r =>
                r.Message.Equals("Arkivdel (systemID): someSystemId_2 - Sekund�rt klassifikasjonssystem (systemID): klassSys_2 - Klasser p� niv� 2: 1"));
        }
    }
}
