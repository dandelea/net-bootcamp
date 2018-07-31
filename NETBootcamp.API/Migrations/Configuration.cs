namespace NETBootcamp.API.Migrations
{
    using NETBootcamp.DataModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NETBootcamp.API.Context.NETBootcampAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NETBootcamp.API.Context.NETBootcampAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // PRUEBAS 09:30

            context.Projects.AddOrUpdate(
                new Project { ID = 1, Title = "Lorem", Detail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non libero porttitor, tempor nisl at, ultricies leo", ProjectType = ProjectType.Default },
                new Project { ID = 2, Title = "Ipsum", Detail = "Duis est diam, volutpat sit amet sem nec, gravida auctor sapien.", ProjectType = ProjectType.Private },
                new Project { ID = 3, Title = "Dolor Sit", Detail = "Nulla libero lectus, porttitor nec mattis eget, dictum non libero.", ProjectType = ProjectType.Work },
                new Project { ID = 4, Title = "Amet", Detail = "Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.", ProjectType = ProjectType.Default }
            );

            context.Tasks.AddOrUpdate(
                new Task { ID = 1, ProjectID = 1, Title = "Task Lorem - 01", Detail = "Morbi ut justo eu sem malesuada congue et id nulla.", TaskType = TaskType.ToDo, Priority = 1, StartTime = new DateTime(2018, 01, 01), DueTime = new DateTime(2018, 10, 1) },
                new Task { ID = 2, ProjectID = 1, Title = "Task Lorem - 02", Detail = "", TaskType = TaskType.ToDo, Priority = 2, StartTime = new DateTime(2018, 02, 01), DueTime = new DateTime(2018, 11, 1) },
                new Task { ID = 3, ProjectID = 2, Title = "Task Ipsum - 01", Detail = "Maecenas at tempor nunc, vitae suscipit felis.", TaskType = TaskType.ToDo, Priority = 3, StartTime = new DateTime(2018, 03, 01), DueTime = new DateTime(2018, 12, 1) },
                new Task { ID = 4, ProjectID = 2, Title = "Task Ipsum - 02", Detail = "Integer non mollis mauris. Sed consectetur quam nec bibendum volutpat.", TaskType = TaskType.ToDo, Priority = 1, StartTime = new DateTime(2018, 04, 01), DueTime = new DateTime(2018, 12, 1) },
                new Task { ID = 5, ProjectID = 2, Title = "Task Ipsum - 03", Detail = "", TaskType = TaskType.ToDo, Priority = 2, StartTime = new DateTime(2018, 05, 01), DueTime = new DateTime(2018, 5, 1) },
                new Task { ID = 6, ProjectID = 3, Title = "Task Dolor Sit - 01", Detail = "Donec urna ligula, tincidunt eu tempor eget, fringilla eget enim. Nulla euismod faucibus dapibus.", TaskType = TaskType.ToDo, Priority = 3, StartTime = new DateTime(2018, 3, 01), DueTime = new DateTime(2018, 5, 20) },
                new Task { ID = 7, ProjectID = 3, Title = "Task Dolor Sit - 02", Detail = "", TaskType = TaskType.ToDo, Priority = 1, StartTime = new DateTime(2018, 6, 01), DueTime = new DateTime(2018, 8, 1) },
                new Task { ID = 8, ProjectID = 3, Title = "Task Dolor Sit - 03", TaskType = TaskType.ToDo, Priority = 2, StartTime = new DateTime(2018, 07, 01), DueTime = new DateTime(2018, 7, 1) },
                new Task { ID = 9, ProjectID = 3, Title = "Task Dolor Sit - 04", TaskType = TaskType.ToDo, Priority = 3, StartTime = new DateTime(2018, 08, 01), DueTime = new DateTime(2018, 10, 1) }
            );
        }
    }
}
