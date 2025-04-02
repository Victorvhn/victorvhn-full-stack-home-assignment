using System.Globalization;
using Bogus;
using FamilyTree.Domain.Persons.Enums;
using FamilyTree.Domain.Trees;
using Person = FamilyTree.Domain.Persons.Person;

namespace FamilyTree.Infrastructure.Databases;

internal static class SeedData
{
    public static (Tree[] Tress, Person[] Persons) Initialize()
    {
        return (GenerateTrees(), GeneratePersons());
    }

    public static Tree[] GenerateTrees()
    {
        Guid[] treeIds =
        [
            new Guid("0195f373-c5e5-70b6-95be-7e7e003b4b7a"),
            new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a"),
            new Guid("0195f373-c5e5-7593-9b26-9af5b901817a"),
            new Guid("0195f373-c5e5-76a2-a287-a46836ddaa72"),
            new Guid("0195f373-c5e5-7933-8d29-eccefc32f5fa"),
            new Guid("0195f373-c756-72e6-81bf-d85ad7a2a321")
        ];

        Faker<Tree> treeBuilder = new Faker<Tree>()
            .CustomInstantiator(f => (Tree)Activator.CreateInstance(typeof(Tree), true)!);

        Tree[] trees = treeIds
            .Select(treeId =>
                treeBuilder
                    .RuleFor(t => t.Id, _ => treeId)
                    .Generate(1)[0]
            )
            .ToArray();

        return trees;
    }

    public static Person[] GeneratePersons()
    {
        #region Dummy data

        dynamic[] personData =
        [
            new
            {
                Id = new Guid("0195f373-c76d-740e-87f2-ad0e9d43d7ca"),
                GivenName = "Kenton",
                Surname = "Block",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("2013-05-09 05:41:06.332908+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "North Natalieborough",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2015-09-27 00:19:22.942795+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "Johathanstad",
                FamilyTreeId = new Guid("0195f373-c5e5-70b6-95be-7e7e003b4b7a")
            },
            new
            {
                Id = new Guid("0195f373-c775-701b-a1fc-1734826579b0"),
                GivenName = "Kyler",
                Surname = "Johns",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("2003-05-17 02:44:02.078258+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Lake Ovaburgh",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2014-03-04 22:13:36.126376+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "Carminefort",
                FamilyTreeId = new Guid("0195f373-c5e5-70b6-95be-7e7e003b4b7a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7085-a540-55e757253372"),
                GivenName = "Bethel",
                Surname = "Waters",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1968-02-28 07:19:37.515816+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-70b6-95be-7e7e003b4b7a")
            },
            new
            {
                Id = new Guid("0195f373-c775-70c1-bf72-69dc05c9476c"),
                GivenName = "Schuyler",
                Surname = "Brakus",
                Gender = PersonGender.Male,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2013-09-01 12:54:56.138273+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "New Grant",
                FamilyTreeId = new Guid("0195f373-c5e5-70b6-95be-7e7e003b4b7a")
            },
            new
            {
                Id = new Guid("0195f373-c775-70d9-98ef-7735d2435cb8"),
                GivenName = "Elnora",
                Surname = "Lindgren",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1971-05-18 10:06:21.593325+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Port Kenny",
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-70b6-95be-7e7e003b4b7a")
            },
            new
            {
                Id = new Guid("0195f373-c775-70e1-b1a4-6f7e19252104"),
                GivenName = "Hollis",
                Surname = "Morar",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1967-11-11 20:31:10.226493+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Port Dorris",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("1995-08-13 03:53:10.528261+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "New Medashire",
                FamilyTreeId = new Guid("0195f373-c5e5-70b6-95be-7e7e003b4b7a")
            },
            new
            {
                Id = new Guid("0195f373-c775-719f-83e9-554316f5b2f3"),
                GivenName = "Colleen",
                Surname = "Lowe",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1983-06-25 17:57:20.591822+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2021-07-15 07:20:20.175244+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "Lake Colleen",
                FamilyTreeId = new Guid("0195f373-c5e5-70b6-95be-7e7e003b4b7a")
            },
            new
            {
                Id = new Guid("0195f373-c775-71ad-83ea-446a61782559"),
                GivenName = "Henry",
                Surname = "Kris",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1933-10-14 06:53:47.432639+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("1985-03-18 12:07:49.552214+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-70b6-95be-7e7e003b4b7a")
            },
            new
            {
                Id = new Guid("0195f373-c775-71c9-9f0e-4f3485b5d521"),
                GivenName = "Wallace",
                Surname = "Schmeler",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1987-07-31 03:09:43.479793+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-70b6-95be-7e7e003b4b7a")
            },
            new
            {
                Id = new Guid("0195f373-c775-721a-8c57-6cefbf9b5b62"),
                GivenName = "Blanche",
                Surname = "Schmidt",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1987-01-22 17:33:02.776638+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2012-04-08 05:09:34.298284+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-70b6-95be-7e7e003b4b7a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7243-81cf-1ec28b652ead"),
                GivenName = "Easter",
                Surname = "Brekke",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1926-02-25 18:30:38.118828+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("1996-10-24 11:36:27.357156+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-724c-9926-b5c3a16c3e95"),
                GivenName = "Verlie",
                Surname = "Effertz",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1967-10-22 19:46:52.911222+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2001-09-28 00:23:27.282227+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7267-9d05-4007d8414fd2"),
                GivenName = "Napoleon",
                Surname = "Stehr",
                Gender = PersonGender.Male,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7331-a3d8-d675e3c98628"),
                GivenName = "Casimir",
                Surname = "Swaniawski",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("2005-02-12 13:21:01.908015+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2008-07-20 12:06:07.226297+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "South Joshuamouth",
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7348-a2fa-bb5f00979bbc"),
                GivenName = "Laurel",
                Surname = "Klocko",
                Gender = PersonGender.Female,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2020-09-18 02:54:37.355558+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "Port Robertamouth",
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-737b-bb1e-e1c3dcd9f453"),
                GivenName = "Elfrieda",
                Surname = "Lakin",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("2006-07-05 12:59:27.545383+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7388-bb36-7272eee23964"),
                GivenName = "Evan",
                Surname = "Schmidt",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1979-02-11 15:00:33.663171+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "New Kaylieton",
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-739d-8c39-82add365df14"),
                GivenName = "Mireya",
                Surname = "Zboncak",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1944-12-26 09:42:47.640914+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2015-01-29 03:15:52.98437+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7407-8362-a1c81ae966a6"),
                GivenName = "Paul",
                Surname = "Ortiz",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1937-04-04 16:26:04.15101+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("1977-05-12 08:32:47.797301+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7419-91f5-57279cc427cf"),
                GivenName = "Griffin",
                Surname = "Murray",
                Gender = PersonGender.Male,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2004-11-29 00:54:40.377318+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7453-8175-1d28187d5c2f"),
                GivenName = "Paxton",
                Surname = "Nader",
                Gender = PersonGender.Female,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-74d0-b765-3541b37140d4"),
                GivenName = "Alta",
                Surname = "Kreiger",
                Gender = PersonGender.Female,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-74eb-8dc3-c720ebd1446c"),
                GivenName = "Jacklyn",
                Surname = "Kunde",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("2008-11-21 04:12:13.274833+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Gennaroside",
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7559-8783-e187c62f02ff"),
                GivenName = "Michaela",
                Surname = "Botsford",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1946-02-04 09:48:34.248489+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Turnerfort",
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-757b-a3be-9ee222f43d9d"),
                GivenName = "Dayana",
                Surname = "O'Reilly",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1998-10-27 22:31:25.183669+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7583-a21c-6c4e136099c2"),
                GivenName = "Irma",
                Surname = "Kassulke",
                Gender = PersonGender.Male,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-758d-a99b-10f53834eda6"),
                GivenName = "Theresia",
                Surname = "Moore",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("2005-10-23 12:35:30.900457+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-75a0-8187-ec2595a04b01"),
                GivenName = "Reynold",
                Surname = "Schinner",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1960-11-29 03:26:25.537829+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("1964-12-27 13:39:59.642493+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-75ef-b18e-6c261e908b62"),
                GivenName = "Kris",
                Surname = "Hermiston",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1943-11-23 14:09:39.584282+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Turnerbury",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("1956-01-29 05:39:28.703813+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "Pattiefurt",
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7611-80ba-1f182c6b583a"),
                GivenName = "Christop",
                Surname = "Kertzmann",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1962-12-09 15:19:27.804722+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-735c-9a59-b323f0f7092a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7612-920c-88e0a9aee6d4"),
                GivenName = "Loma",
                Surname = "Kris",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("2004-10-29 22:36:41.110701+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Steuberfort",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2014-12-25 06:40:53.883539+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "South Cordell",
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-764c-899c-c196ab5dc186"),
                GivenName = "Xzavier",
                Surname = "Hegmann",
                Gender = PersonGender.Male,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("1998-02-14 13:27:45.740736+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "New Fannyport",
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-764d-ae64-4c1840729aae"),
                GivenName = "Alexandre",
                Surname = "Smith",
                Gender = PersonGender.Male,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-76a4-a392-9ca892b757ca"),
                GivenName = "Giovani",
                Surname = "Gibson",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1965-02-09 07:52:52.369503+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "New Kayleeburgh",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("1997-12-07 07:26:36.233198+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "North Jo",
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-76b8-9e0b-cf2b18e71f1b"),
                GivenName = "Esteban",
                Surname = "Romaguera",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1944-05-07 05:05:48.32891+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "West Crawford",
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-773c-935d-a2c9dffe7b9d"),
                GivenName = "Dave",
                Surname = "Kemmer",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1959-01-22 23:03:55.338671+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Krajcikfurt",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("1986-12-05 22:22:26.797489+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7752-9cf9-9c9dfaffe013"),
                GivenName = "Waino",
                Surname = "Little",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1995-06-07 11:30:37.21125+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Dietrichstad",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2009-06-16 06:52:11.442886+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-77c0-bb4f-4f58be2ec185"),
                GivenName = "Litzy",
                Surname = "Abshire",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("2010-06-26 11:08:06.691812+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Hannashire",
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-77c8-81c1-23659a1ad4ab"),
                GivenName = "Gwendolyn",
                Surname = "Schroeder",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1948-06-28 03:00:42.679028+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Port Rydermouth",
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7837-af85-552bfd0f61ca"),
                GivenName = "Gene",
                Surname = "Herzog",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1957-03-02 11:30:42.308473+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Welchborough",
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7867-9716-383c63125bfb"),
                GivenName = "Creola",
                Surname = "Kuphal",
                Gender = PersonGender.Male,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2006-08-06 14:00:44.579725+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "New Rosina",
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-78d0-a917-04a38fa57d18"),
                GivenName = "Josefina",
                Surname = "Prohaska",
                Gender = PersonGender.Male,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2012-01-29 08:33:30.14724+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-78d6-9dc8-2863cb64a980"),
                GivenName = "Queen",
                Surname = "Lebsack",
                Gender = PersonGender.Male,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2018-02-07 16:28:05.696437+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "New Winifred",
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7916-b78c-ad733461744b"),
                GivenName = "Edison",
                Surname = "O'Conner",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1946-10-04 11:35:15.617011+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-792a-b160-7ec52d7f8627"),
                GivenName = "Helmer",
                Surname = "Graham",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1937-05-12 10:16:01.825158+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Port Kim",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("1984-12-26 19:44:16.011283+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7941-af19-cfbf18a46ede"),
                GivenName = "Jessyca",
                Surname = "Effertz",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("2018-01-20 09:05:22.404342+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Swiftview",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2021-07-28 19:37:12.087933+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "Lamontside",
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-795b-9822-20625d529f55"),
                GivenName = "Arlene",
                Surname = "Harris",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1998-01-04 07:58:01.497066+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2021-03-13 15:34:38.402212+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "Cummeratafurt",
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7963-a0b0-476323e40a1e"),
                GivenName = "Jackeline",
                Surname = "Wolff",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1937-07-09 14:38:37.188878+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-79b9-aac6-09b6a9647992"),
                GivenName = "Alexandra",
                Surname = "Sanford",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1994-10-24 14:36:03.326604+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "East Amelieside",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2019-07-11 14:07:00.987641+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-79f0-9e5b-ccf5d862b4dd"),
                GivenName = "Madyson",
                Surname = "Grant",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1957-01-24 03:40:20.47904+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "East Kaylieborough",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2003-07-31 12:57:03.087508+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-79f3-afc7-23ff7b44ef78"),
                GivenName = "Xzavier",
                Surname = "Beier",
                Gender = PersonGender.Male,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-79f5-9657-01404849607d"),
                GivenName = "Darryl",
                Surname = "Skiles",
                Gender = PersonGender.Female,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7a9e-a16c-d04ed707ba38"),
                GivenName = "Hester",
                Surname = "Funk",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1944-09-22 06:08:36.673911+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Jastburgh",
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7ad2-aac6-2bd48040c51f"),
                GivenName = "Kylee",
                Surname = "Jaskolski",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1949-07-15 13:33:36.778467+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2007-12-11 03:33:57.530903+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7b0d-b17c-e4059b907c71"),
                GivenName = "Donato",
                Surname = "Strosin",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1958-03-25 02:28:56.820323+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Kossfurt",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2011-10-03 05:43:58.581295+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7b5e-a1e3-13529fcc12c0"),
                GivenName = "Noah",
                Surname = "Auer",
                Gender = PersonGender.Female,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7b7f-a66c-013ec9c340db"),
                GivenName = "Green",
                Surname = "Lind",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1986-12-28 06:51:54.922516+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("1994-06-26 12:31:48.530612+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "New Guiseppeburgh",
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7b95-901d-00262da79d70"),
                GivenName = "Cale",
                Surname = "Ziemann",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("2000-08-07 20:45:10.859658+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "West Stephaniachester",
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7ba5-b2ac-972cc28887c7"),
                GivenName = "Enrico",
                Surname = "Prosacco",
                Gender = PersonGender.Male,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2014-03-20 21:51:16.216196+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "McLaughlinshire",
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7bac-b54a-c28ff7323464"),
                GivenName = "Verna",
                Surname = "Schimmel",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1985-02-23 14:08:27.873308+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "West Lenora",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("1990-11-12 06:15:22.710819+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "North Yvonneland",
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7bb8-be47-e9a36a8b3d40"),
                GivenName = "Vaughn",
                Surname = "Ankunding",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1931-08-02 23:52:56.857504+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7593-9b26-9af5b901817a")
            },
            new
            {
                Id = new Guid("0195f373-c775-7c07-a1fb-0be2852dc55c"),
                GivenName = "Aiyana",
                Surname = "Bahringer",
                Gender = PersonGender.Female,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2005-10-31 04:26:02.899118+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "Cynthiafurt",
                FamilyTreeId = new Guid("0195f373-c5e5-76a2-a287-a46836ddaa72")
            },
            new
            {
                Id = new Guid("0195f373-c775-7c3c-ad47-a60809475b56"),
                GivenName = "Jammie",
                Surname = "Bauch",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1951-02-20 02:07:56.590643+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-76a2-a287-a46836ddaa72")
            },
            new
            {
                Id = new Guid("0195f373-c775-7c52-9c06-1d3e5230fc85"),
                GivenName = "Antonetta",
                Surname = "Leffler",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("2008-09-16 18:37:13.701033+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "West Saigeborough",
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-76a2-a287-a46836ddaa72")
            },
            new
            {
                Id = new Guid("0195f373-c775-7ca8-854f-3f64ff6f972b"),
                GivenName = "Lia",
                Surname = "Russel",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("2016-06-18 09:12:21.513927+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2024-03-14 05:13:50.304198+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "Grahamburgh",
                FamilyTreeId = new Guid("0195f373-c5e5-76a2-a287-a46836ddaa72")
            },
            new
            {
                Id = new Guid("0195f373-c775-7ca9-9f36-31697a7fe3a1"),
                GivenName = "Brooke",
                Surname = "Powlowski",
                Gender = PersonGender.Male,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2001-07-17 06:08:17.406468+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "Corkerytown",
                FamilyTreeId = new Guid("0195f373-c5e5-76a2-a287-a46836ddaa72")
            },
            new
            {
                Id = new Guid("0195f373-c775-7cd6-ae22-5945174448e4"),
                GivenName = "Mckenzie",
                Surname = "Williamson",
                Gender = PersonGender.Male,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-76a2-a287-a46836ddaa72")
            },
            new
            {
                Id = new Guid("0195f373-c775-7cd6-af83-6ff484fae579"),
                GivenName = "Makenzie",
                Surname = "Buckridge",
                Gender = PersonGender.Male,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2005-09-14 09:02:08.991587+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-76a2-a287-a46836ddaa72")
            },
            new
            {
                Id = new Guid("0195f373-c775-7cdb-85cb-6205d266a4e5"),
                GivenName = "Jada",
                Surname = "Jones",
                Gender = PersonGender.Female,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-76a2-a287-a46836ddaa72")
            },
            new
            {
                Id = new Guid("0195f373-c775-7dd5-adf8-1702213bc5c9"),
                GivenName = "Chesley",
                Surname = "Bailey",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1964-05-21 20:13:27.692218+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "South Jessieview",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2013-09-04 12:49:41.859559+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-76a2-a287-a46836ddaa72")
            },
            new
            {
                Id = new Guid("0195f373-c775-7def-99a9-6ea0964b674a"),
                GivenName = "Aileen",
                Surname = "Romaguera",
                Gender = PersonGender.Female,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2008-05-04 02:17:23.723216+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "Boehmview",
                FamilyTreeId = new Guid("0195f373-c5e5-7933-8d29-eccefc32f5fa")
            },
            new
            {
                Id = new Guid("0195f373-c775-7e58-a08e-ff67742dde68"),
                GivenName = "Monica",
                Surname = "Haag",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1951-10-08 22:31:59.833056+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7933-8d29-eccefc32f5fa")
            },
            new
            {
                Id = new Guid("0195f373-c775-7e84-b7fa-385b10ff65c1"),
                GivenName = "Enos",
                Surname = "Hermiston",
                Gender = PersonGender.Male,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2004-05-19 18:03:33.162863+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7933-8d29-eccefc32f5fa")
            },
            new
            {
                Id = new Guid("0195f373-c775-7ebe-b5d8-56b3bcee9032"),
                GivenName = "Alysha",
                Surname = "Bernhard",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1941-02-02 16:55:51.048402+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Federicofort",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("1952-06-27 22:30:58.954261+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c5e5-7933-8d29-eccefc32f5fa")
            },
            new
            {
                Id = new Guid("0195f373-c775-7ee5-aeaf-318095afeac1"),
                GivenName = "Vito",
                Surname = "Mertz",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1956-04-08 14:23:53.616519+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Denesikland",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2000-06-17 08:58:15.494947+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "West Cleveland",
                FamilyTreeId = new Guid("0195f373-c5e5-7933-8d29-eccefc32f5fa")
            },
            new
            {
                Id = new Guid("0195f373-c775-7f01-818f-e99f92dcb6a7"),
                GivenName = "Ethel",
                Surname = "Hirthe",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1978-11-01 17:13:38.030514+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "West Cassandramouth",
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c756-72e6-81bf-d85ad7a2a321")
            },
            new
            {
                Id = new Guid("0195f373-c775-7f48-bc68-1167877eeabf"),
                GivenName = "Clementina",
                Surname = "Conroy",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1954-08-24 17:54:48.169075+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c756-72e6-81bf-d85ad7a2a321")
            },
            new
            {
                Id = new Guid("0195f373-c775-7f4f-af00-49f3d77b6853"),
                GivenName = "Kareem",
                Surname = "Herman",
                Gender = PersonGender.Female,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c756-72e6-81bf-d85ad7a2a321")
            },
            new
            {
                Id = new Guid("0195f373-c775-7fb7-a311-407c750bceea"),
                GivenName = "Isadore",
                Surname = "Bauch",
                Gender = PersonGender.Female,
                BirthDate = (DateTime?)null,
                BirthLocation = (string)null,
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2005-12-19 02:43:30.494949+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "Roweview",
                FamilyTreeId = new Guid("0195f373-c756-72e6-81bf-d85ad7a2a321")
            },
            new
            {
                Id = new Guid("0195f373-c775-7fbd-a6e0-df1d8f194556"),
                GivenName = "Emmett",
                Surname = "Green",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1932-09-08 03:13:07.820377+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Gusikowskiburgh",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("2002-09-22 12:36:51.768141+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = "West Hendersonton",
                FamilyTreeId = new Guid("0195f373-c756-72e6-81bf-d85ad7a2a321")
            },
            new
            {
                Id = new Guid("0195f373-c775-7fe9-a634-3168f875d118"),
                GivenName = "Irma",
                Surname = "Reilly",
                Gender = PersonGender.Male,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("2010-10-20 07:44:31.243894+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "North Garretchester",
                DeathDate = (DateTime?)null,
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c756-72e6-81bf-d85ad7a2a321")
            },
            new
            {
                Id = new Guid("0195f373-c775-7fee-ae7b-46e635b09e2e"),
                GivenName = "Ferne",
                Surname = "Torp",
                Gender = PersonGender.Female,
                BirthDate = DateTime.SpecifyKind(
                    DateTime.Parse("1962-06-28 09:32:09.926057+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                BirthLocation = "Joelleview",
                DeathDate = DateTime.SpecifyKind(
                    DateTime.Parse("1976-12-06 23:35:27.685892+00", CultureInfo.InvariantCulture), DateTimeKind.Utc),
                DeathLocation = (string)null,
                FamilyTreeId = new Guid("0195f373-c756-72e6-81bf-d85ad7a2a321")
            }
        ];

        #endregion

        Faker<Person> personBuilder = new Faker<Person>()
            .CustomInstantiator(f => (Person)Activator.CreateInstance(typeof(Person), true)!);

        Person[] persons = personData
            .Select(dummyData =>
                personBuilder
                    .RuleFor(person => person.Id, _ => dummyData.Id)
                    .RuleFor(person => person.GivenName, _ => dummyData.GivenName)
                    .RuleFor(person => person.Surname, _ => dummyData.Surname)
                    .RuleFor(person => person.Gender, _ => dummyData.Gender)
                    .RuleFor(person => person.BirthDate, _ => dummyData.BirthDate)
                    .RuleFor(person => person.BirthLocation, _ => dummyData.BirthLocation)
                    .RuleFor(person => person.DeathDate, _ => dummyData.DeathDate)
                    .RuleFor(person => person.DeathLocation, _ => dummyData.DeathLocation)
                    .RuleFor(person => person.FamilyTreeId, _ => dummyData.FamilyTreeId)
                    .Generate(1)[0]
            )
            .ToArray();

        return persons;
    }
}
