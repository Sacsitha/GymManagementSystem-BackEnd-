select * from Enrollments;
UPDATE Enrollments
SET NextDueDate = '2024-11-23 12:27:04.6580000'
WHERE MemberId = 'CE6A269B-35C9-4D15-AA7C-08DD0B2174D0';


Update Users
SET Password = '$2a$10$MSYHbXhkxVL1ca9s8K6HZ.U2SuAoF0SV006oJDeFvWAQn6zRY9cta'
WHERE Roles = 0;
Update Users
SET Password = '$2a$10$MSYHbXhkxVL1ca9s8K6HZ.U2SuAoF0SV006oJDeFvWAQn6zRY9cta'
WHERE Roles = 1;
select * from Users;

select * from Members;

INSERT INTO Users (Id, Password, ProfileImage, Roles)
VALUES
('user1', '$2a$10$MSYHbXhkxVL1ca9s8K6HZ.U2SuAoF0SV006oJDeFvWAQn6zRY9cta', 'image1.jpg', 1),  -- Member 1
('user2', '$2a$10$MSYHbXhkxVL1ca9s8K6HZ.U2SuAoF0SV006oJDeFvWAQn6zRY9cta', 'image2.jpg', 1),  -- Member 2
('user3', '$2a$10$MSYHbXhkxVL1ca9s8K6HZ.U2SuAoF0SV006oJDeFvWAQn6zRY9cta', 'image3.jpg', 1),  -- Member 3
('user4', '$2a$10$MSYHbXhkxVL1ca9s8K6HZ.U2SuAoF0SV006oJDeFvWAQn6zRY9cta', 'adminimage1.jpg', 1),  -- Admin 1
('user5', '$2a$10$MSYHbXhkxVL1ca9s8K6HZ.U2SuAoF0SV006oJDeFvWAQn6zRY9cta', 'adminimage2.jpg', 1); 


INSERT INTO Members 
(
	Id,
    UserId, 
    FirstName, 
    LastName, 
    DOB, 
    ContactNo, 
    Email, 
    Age, 
    Gender, 
    Height, 
    Weight, 
    CreatedDate, 
    MemberStatus, 
    Address, 
    NicNo
)
VALUES
(
    '3C3A5678-06C6-4122-3934-08DD0BDE8E96', 'user1', 'John', 'Doe', '1990-05-15', '1234567890', 'john.doe@example.com', 34, 'Male', 180, 75, GETDATE(), 1, '123 Main St', 'ABC123'
),(
    '10A75593-FD3C-44DF-A915-08DD0EB5C682','user2', 'Jane', 'Smith', '1992-08-20', '0987654321', 'jane.smith@example.com', 32, 'Female', 165, 60, GETDATE(), 1, '456 Oak St', 'XYZ456'
),
(
   'D304AE5E-76D6-4D07-BA52-B7C611EA70B0', 'user3', 'Tom', 'Brown', '1985-03-10', '1122334455', 'tom.brown@example.com', 39, 'Male', 175, 80, GETDATE(), 1, '789 Pine St', 'LMN789'
),
(
   NEWID(), 'user4', 'Emily', 'Davis', '1995-11-05', '2233445566', 'emily.davis@example.com', 29, 'Female', 160, 55, GETDATE(), 1, '321 Maple St', 'OPQ123'
),
(
   NEWID(), 'user5', 'Michael', 'Wilson', '1980-07-30', '3344556677', 'michael.wilson@example.com', 44, 'Male', 185, 90, GETDATE(), 1, '654 Birch St', 'RST456'
);

INSERT INTO Users (Id, Password, ProfileImage,Roles)
VALUES ('Admin', '123', 'string',0);


INSERT INTO Subscriptions
(
    Id, 
    Title, 
    Description, 
    Duration, 
    Date, 
    IsSpecialOffer, 
    Status
)
VALUES
(
    '0102FC70-ABC7-48FF-3998-08DD0B203141', 'Basic Membership', 'Access to gym facilities and equipment for 1 month.', 1, GETDATE(), 0, 1
),
(
    '74F3B999-F4C5-4E00-40E4-08DD0DCF70D0', 'Semi-Annual Membership', 'Access to gym facilities, group classes, and personal trainer for 6 months.', 6, GETDATE(), 1, 1
),
(
    'B8586075-6634-4E34-40E5-08DD0DCF70D0', 'Yearly Membership', 'Access to gym facilities and equipment for 1 year at a discounted price.', 12, GETDATE(), 0, 1
);
select * from Subscriptions;
INSERT INTO WorkoutPrograms
(
    Id, 
    Name, 
    Description, 
    CreatedDate, 
    Status
)
VALUES
(
    NEWID(), 'Full Body Workout', 'A complete workout routine that targets all major muscle groups in the body.', GETDATE(), 1
),
(
    NEWID(), 'Cardio Burn', 'An intense cardio workout designed to burn fat and increase endurance.', GETDATE(), 1
),
(
    NEWID(), 'Strength Training', 'A program focused on building muscle strength through weightlifting.', GETDATE(), 0
),
(
    NEWID(), 'Yoga Flexibility', 'A workout program that focuses on improving flexibility and balance through yoga poses.', GETDATE(), 1
);