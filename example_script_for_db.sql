INSERT INTO [GymGenius].[dbo].[Users]
    ([DateCreated], [UserName], [FirstName], [LastName], [Password], [Age], [Email], [RoleId])
VALUES
    -- Admins
    (GETDATE(), 'admin', 'Admin', 'One', 'hJg8YPfarcHLhphiH4AsDZ+aPDwpXIEHSPsEgRXBhuw=', 30, 'admin1@example.com', 1),
    -- Trainers
    (GETDATE(), 'trainer', 'Trainer', 'One', 'hJg8YPfarcHLhphiH4AsDZ+aPDwpXIEHSPsEgRXBhuw=', 25, 'trainer1@example.com', 2),
    -- Trainees
    (GETDATE(), 'trainee', 'Trainee', 'One', 'hJg8YPfarcHLhphiH4AsDZ+aPDwpXIEHSPsEgRXBhuw=', 20, 'trainee1@example.com', 3);

    INSERT INTO [GymGenius].dbo.Exercises (Name)
VALUES 
    ('Push-up'),
    ('Pull-up'),
    ('Squat'),
    ('Deadlift'),
    ('Bench Press'),
    ('Overhead Press'),
    ('Bicep Curl'),
    ('Tricep Dip'),
    ('Lunge'),
    ('Leg Press'),
    ('Lat Pulldown'),
    ('Dumbbell Row'),
    ('Chest Fly'),
    ('Shoulder Press'),
    ('Seated Row'),
    ('Leg Extension'),
    ('Leg Curl'),
    ('Calf Raise'),
    ('Crunch'),
    ('Plank'),
    ('Russian Twist'),
    ('Mountain Climber'),
    ('Burpee'),
    ('Kettlebell Swing'),
    ('Clean and Jerk'),
    ('Snatch'),
    ('Medicine Ball Slam'),
    ('Box Jump'),
    ('Battle Ropes'),
    ('Farmer''s Walk'),
    ('Incline Bench Press'),
    ('Decline Bench Press'),
    ('Hammer Curl'),
    ('Cable Crossover'),
    ('Dumbbell Shrug'),
    ('Face Pull'),
    ('Hanging Leg Raise'),
    ('T-Bar Row'),
    ('Front Squat'),
    ('Zercher Squat'),
    ('Hip Thrust'),
    ('Romanian Deadlift'),
    ('Power Clean'),
    ('Turkish Get-Up'),
    ('Pistol Squat'),
    ('Wall Sit'),
    ('Side Plank'),
    ('Flutter Kick'),
    ('Jump Rope');

INSERT INTO [GymGenius].dbo.TrainingPrograms(Name, Description)
VALUES 
('Program A', 'A'),
('Program B', 'B')

