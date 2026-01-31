var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddPostgres("database");

var server = builder.AddProject<Projects.MSK_AbySalto_OMP_Server>("server")
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints()
    .WithReference(db)
    .WaitFor(db);

var webfrontend = builder.AddViteApp("webfrontend", "../frontend")
    .WithReference(server)
    .WaitFor(server);

server.PublishWithContainerFiles(webfrontend, "wwwroot");

builder.Build().Run();
