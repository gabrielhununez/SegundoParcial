var builder = DistributedApplication.CreateBuilder(args);

var backend = builder.AddProject<Projects.SegundoParcial_Backend>("segundoParcialBackend");
builder.AddProject<Projects.SegundoParcial_Consumer>("segundoParcialConsumer").WithReference(backend);

builder.Build().Run();