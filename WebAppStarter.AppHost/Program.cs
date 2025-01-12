var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WebAppStarter>("webappstarter");

builder.Build().Run();
