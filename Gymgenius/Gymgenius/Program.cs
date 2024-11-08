using Gymgenius.bo;
using Gymgenius.dal;
using GymGenius.BLL;
using GymGenius.BO;
using GymGenius.dal;
using GymGenius.DAL;
using GymGenius.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<DapperContext>();

builder.Services.AddSingleton<UserManagment>();
builder.Services.AddSingleton<ExerciseManagment>();
builder.Services.AddSingleton<TrainingProgramManagment>();
builder.Services.AddSingleton<ExerciseToProgramManagment>();
builder.Services.AddSingleton<UserToProgramManagment>();
builder.Services.AddSingleton<RoleManagement>();
builder.Services.AddSingleton<TrainingLogManagement>();

//builder.Services.AddSingleton<IUserRepository, UserMemoryRepository>();
//builder.Services.AddSingleton<IExerciseRepository, ExerciseMemoryRepository>();
//builder.Services.AddSingleton<ITrainingProgramRepository, TrainingProgramMemoryRepository>();
//builder.Services.AddSingleton<IExerciseToProgramRepository, ExerciseToProgramMemoryRepository>();
//builder.Services.AddSingleton<IUserToProgramRepository, UserToProgramMemoryRepository>();

builder.Services.AddSingleton<IUserRepository, UserMSSQLRepository>();
builder.Services.AddSingleton<IExerciseRepository, ExerciseMSSQLRepository>();
builder.Services.AddSingleton<ITrainingProgramRepository, TrainingProgramMSSQLRepository>();
builder.Services.AddSingleton<IExerciseToProgramRepository, ExerciseToProgramMSSQLRepository>();
builder.Services.AddSingleton<IUserToProgramRepository, UserToProgramMSSQLRepository>();
builder.Services.AddSingleton<IRoleRepository, RoleMSSQLRepository>();
builder.Services.AddSingleton<ITrainingLogRepository, TrainingLogMSSQLRepository>();
builder.Services.AddSingleton<IExerciseLogRepository, ExerciseLogMSSQLRepository>();


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
