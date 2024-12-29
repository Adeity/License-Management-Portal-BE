create table Reseller.ContactType
(
    Id          int                                                     not null
        constraint PK_ContactType
            primary key,
    Name        nvarchar(50)
        constraint UQ_ContactType_Name
            unique,
    Description nvarchar(250)
        constraint DF__ContactTy__Descr__6FD49106 default ''            not null,
    UserID      nvarchar(256)
        constraint DF__ContactTy__UserI__70C8B53F default suser_sname() not null,
    UpdateDate  datetime
        constraint DF__ContactTy__Updat__71BCD978 default getdate()     not null
)
    go

INSERT INTO Reseller.ContactType (Id, Name, Description, UserID, UpdateDate) VALUES (1, N'DataManager', N'Reseller data manager with login account', N'NAPA\E0083258', N'2022-03-28 11:29:44.157');
INSERT INTO Reseller.ContactType (Id, Name, Description, UserID, UpdateDate) VALUES (2, N'Contact', N'Subscription company contact', N'NAPA\E0083258', N'2022-03-28 11:30:19.460');


create table Reseller.Country
(
    Id          int                                                    not null
        constraint PK_Country
            primary key,
    Name        nvarchar(250)                                          not null
        constraint UQ_Country_Name
            unique,
    SelectOrder int                                                    not null,
    UserID      nvarchar(256)
        constraint DF__Country__UserID__0C70CFB4 default suser_sname() not null,
    UpdateDate  datetime
        constraint DF__Country__UpdateD__0D64F3ED default getdate()    not null
)
    go

INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (1, N'United States', 1, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (2, N'Afghanistan', 2, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (3, N'Albania', 3, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (4, N'Algeria', 4, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (5, N'Andorra', 5, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (6, N'Angola', 6, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (7, N'Antigua and Barbuda', 7, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (8, N'Argentina', 8, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (9, N'Armenia', 9, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (10, N'Australia', 10, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (11, N'Austria', 11, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (12, N'Azerbaijan', 12, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (13, N'Bahamas, The', 13, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (14, N'Bahrain', 14, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (15, N'Bangladesh', 15, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (16, N'Barbados', 16, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (17, N'Belarus', 17, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (18, N'Belgium', 18, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (19, N'Belize', 19, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (20, N'Benin', 20, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (21, N'Bhutan', 21, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (22, N'Bolivia', 22, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (23, N'Bosnia and Herzegovina', 23, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (24, N'Botswana', 24, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (25, N'Brazil', 25, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (26, N'Brunei ', 26, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (27, N'Bulgaria', 27, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (28, N'Burkina Faso', 28, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (29, N'Burma', 29, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (30, N'Burundi', 30, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (31, N'Cambodia', 31, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (32, N'Cameroon', 32, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (33, N'Canada', 33, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (34, N'Cape Verde', 34, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (35, N'Central African Republic', 35, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (36, N'Chad', 36, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (37, N'Chile', 37, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (38, N'China', 38, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (39, N'Colombia', 39, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (40, N'Comoros', 40, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (41, N'Congo (Brazzaville)', 41, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (42, N'Congo (Kinshasa)', 42, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (43, N'Costa Rica', 43, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (44, N'Cote dIvoire', 44, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (45, N'Croatia', 45, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (46, N'Cyprus', 46, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (47, N'Czech Republic', 47, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (48, N'Denmark', 48, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (49, N'Djibouti', 49, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (50, N'Dominica', 50, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (51, N'Dominican Republic', 51, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (52, N'East Timor (see Timor-Leste)', 52, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (53, N'Ecuador', 53, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (54, N'Egypt', 54, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (55, N'El Salvador', 55, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (56, N'Equatorial Guinea', 56, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (57, N'Eritrea', 57, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (58, N'Estonia', 58, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (59, N'Ethiopia', 59, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (60, N'Fiji', 60, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (61, N'Finland', 61, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (62, N'France', 62, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (63, N'Gabon', 63, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (64, N'Gambia, The', 64, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (65, N'Georgia', 65, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (66, N'Germany', 66, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (67, N'Ghana', 67, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (68, N'Greece', 68, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (69, N'Grenada', 69, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (70, N'Guatemala', 70, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (71, N'Guinea', 71, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (72, N'Guinea-Bissau', 72, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (73, N'Guyana', 73, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (74, N'Haiti', 74, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (75, N'Holy See', 75, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (76, N'Honduras', 76, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (77, N'Hong Kong', 77, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (78, N'Hungary', 78, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (79, N'Iceland', 79, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (80, N'India', 80, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (81, N'Indonesia', 81, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (82, N'Iraq', 82, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (83, N'Ireland', 83, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (84, N'Israel', 84, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (85, N'Italy', 85, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (86, N'Jamaica', 86, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (87, N'Japan', 87, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (88, N'Jordan', 88, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (89, N'Kazakhstan', 89, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (90, N'Kenya', 90, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (91, N'Kiribati', 91, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (92, N'Korea, North', 92, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (93, N'Korea, South', 93, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (94, N'Kosovo', 94, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (95, N'Kuwait', 95, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (96, N'Kyrgyzstan', 96, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (97, N'Laos', 97, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (98, N'Latvia', 98, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (99, N'Lebanon', 99, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (100, N'Lesotho', 100, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (101, N'Liberia', 101, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (102, N'Libya', 102, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (103, N'Liechtenstein', 103, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (104, N'Lithuania', 104, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (105, N'Luxembourg', 105, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (106, N'Macau', 106, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (107, N'Macedonia', 107, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (108, N'Madagascar', 108, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (109, N'Malawi', 109, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (110, N'Malaysia', 110, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (111, N'Maldives', 111, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (112, N'Mali', 112, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (113, N'Malta', 113, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (114, N'Marshall Islands', 114, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (115, N'Mauritania', 115, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (116, N'Mauritius', 116, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (117, N'Mexico', 117, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (118, N'Micronesia', 118, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (119, N'Moldova', 119, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (120, N'Monaco', 120, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (121, N'Mongolia', 121, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (122, N'Montenegro', 122, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (123, N'Morocco', 123, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (124, N'Mozambique', 124, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (125, N'Namibia', 125, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (126, N'Nauru', 126, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (127, N'Nepal', 127, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (128, N'Netherlands', 128, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (129, N'Netherlands Antilles', 129, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (130, N'New Zealand', 130, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (131, N'Nicaragua', 131, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (132, N'Niger', 132, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (133, N'Nigeria', 133, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (135, N'Norway', 135, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (136, N'Oman', 136, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (137, N'Pakistan', 137, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (138, N'Palau', 138, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (139, N'Palestinian Territories', 139, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (140, N'Panama', 140, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (141, N'Papua New Guinea', 141, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (142, N'Paraguay', 142, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (143, N'Peru', 143, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (144, N'Philippines', 144, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (145, N'Poland', 145, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (146, N'Portugal', 146, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (147, N'Qatar', 147, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (148, N'Romania', 148, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (149, N'Russia', 149, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (150, N'Rwanda', 150, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (151, N'Saint Kitts and Nevis', 151, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (152, N'Saint Lucia', 152, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (153, N'Saint Vincent and the Grenadines', 153, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (154, N'Samoa ', 154, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (155, N'San Marino', 155, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (156, N'Sao Tome and Principe', 156, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (157, N'Saudi Arabia', 157, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (158, N'Senegal', 158, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (159, N'Serbia', 159, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (160, N'Seychelles', 160, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (161, N'Sierra Leone', 161, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (162, N'Singapore', 162, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (163, N'Slovakia', 163, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (164, N'Slovenia', 164, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (165, N'Solomon Islands', 165, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (166, N'Somalia', 166, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (167, N'South Africa', 167, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (168, N'South Korea', 168, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (169, N'Spain ', 169, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (170, N'Sri Lanka', 170, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (171, N'Suriname', 171, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (172, N'Swaziland ', 172, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (173, N'Sweden', 173, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (174, N'Switzerland', 174, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (175, N'Taiwan', 175, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (176, N'Tajikistan', 176, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (177, N'Tanzania', 177, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (178, N'Thailand ', 178, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (179, N'Timor-Leste', 179, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (180, N'Togo', 180, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (181, N'Tonga', 181, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (182, N'Trinidad and Tobago', 182, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (183, N'Tunisia', 183, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (184, N'Turkey', 184, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (185, N'Turkmenistan', 185, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (186, N'Tuvalu', 186, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (187, N'Uganda', 187, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (188, N'Ukraine', 188, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (189, N'United Arab Emirates', 189, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (190, N'United Kingdom', 190, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (191, N'Uruguay', 191, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (192, N'Uzbekistan', 192, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (193, N'Vanuatu', 193, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (194, N'Venezuela', 194, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (195, N'Vietnam', 195, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (196, N'Yemen', 196, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (197, N'Zambia', 197, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (198, N'Zimbabwe ', 198, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');
INSERT INTO Reseller.Country (Id, Name, SelectOrder, UserID, UpdateDate) VALUES (199, N'Other', 199, N'NAPA\E0083258', N'2022-03-28 11:46:25.913');


create table Reseller.AddressType
(
    Id          int                                                     not null
        constraint PK_AddressType
            primary key,
    Name        nvarchar(50)                                            not null
        constraint UQ_AddressType_Name
            unique,
    Description nvarchar(250)
        constraint DF__AddressTy__Descr__01F34141 default ''            not null,
    UserID      nvarchar(256)
        constraint DF__AddressTy__UserI__02E7657A default suser_sname() not null,
    UpdateDate  datetime
        constraint DF__AddressTy__Updat__03DB89B3 default getdate()     not null
)
    go

INSERT INTO Reseller.AddressType (Id, Name, Description, UserID, UpdateDate) VALUES (1, N'ContactAddress', N'Primary organization contact address', N'NAPA\E0083258', N'2022-03-28 11:39:45.243');


create table Reseller.OrganizationType
(
    Id          int                                                     not null
        constraint PK_OrganizationStatus
            primary key,
    Name        nvarchar(50),
    Description nvarchar(250)
        constraint DF__Organizat__Descr__6462DE5A default ''            not null,
    UserID      nvarchar(256)
        constraint DF__Organizat__UserI__65570293 default suser_sname() not null,
    UpdateDate  datetime
        constraint DF__Organizat__Updat__664B26CC default getdate()     not null
)
    go

INSERT INTO Reseller.OrganizationType (Id, Name, Description, UserID, UpdateDate) VALUES (1, N'Reseller', N'SR4 license reseller', N'NAPA\E0083258', N'2022-03-28 12:21:31.107');
INSERT INTO Reseller.OrganizationType (Id, Name, Description, UserID, UpdateDate) VALUES (2, N'Organization', N'Subscription owner organization', N'NAPA\E0083258', N'2022-03-28 11:14:10.653');


create table Reseller.OrganizationRole
(
    Id          int identity
        constraint PK_OrganizationRole
            primary key,
    Name        nvarchar(50)                                            not null
        constraint UQ_OrganizationRole_Name
            unique,
    Description nvarchar(250)
        constraint DF__Organizat__Descr__758D6A5C default ''            not null,
    UserID      nvarchar(256)
        constraint DF__Organizat__UserI__76818E95 default suser_sname() not null,
    UpdateDate  datetime
        constraint DF__Organizat__Updat__7775B2CE default getdate()     not null
)
    go

SET IDENTITY_INSERT Reseller.OrganizationRole ON;
INSERT INTO Reseller.OrganizationRole (Id, Name, Description, UserID, UpdateDate)VALUES (1, N'Fleet manager', N'Truck fleet manager', N'NAPA\E0083258', N'2022-03-28 11:26:28.730');
INSERT INTO Reseller.OrganizationRole (Id, Name, Description, UserID, UpdateDate) VALUES (2, N'Manager', N'Subscription owner', N'NAPA\E0083258', N'2022-03-28 11:27:13.580');
INSERT INTO Reseller.OrganizationRole (Id, Name, Description, UserID, UpdateDate) VALUES (3, N'Other', N'', N'NAPA\E0083258', N'2022-03-28 11:28:28.293');
SET IDENTITY_INSERT Reseller.OrganizationRole OFF;


create table Reseller.OrganizationAccount
(
    Id                   int identity
        constraint PK_OrganizationAccount
            primary key,
    OrganizationTypeId   int                                            not null
        constraint FK_OrganizationAccount_OrganizationType
            references Reseller.OrganizationType,
    ParentOrganizationId int
        constraint FK_OrganizationAccount_OrganizationAccount
            references Reseller.OrganizationAccount,
    Name                 nvarchar(250)                                  not null,
    AccountID            nvarchar(50),
    IsDeleted            bit                                            not null,
    UserID               nvarchar(256)
        constraint DF__Organizat__UserI__69279377 default suser_sname() not null,
    UpdateDate           datetime
        constraint DF__Organizat__Updat__6A1BB7B0 default getdate()     not null,
    constraint UQ_OrganizationAccount_Name
        unique (Name, ParentOrganizationId)
)
    go

create index IX_OrganizationAccount_Account
    on Reseller.OrganizationAccount (AccountID)
    go

create index IX_OrganizationAccount_OrganizationType
    on Reseller.OrganizationAccount (OrganizationTypeId)
    go

create index IX_OrganizationAccount_ParentOrganizationId
    on Reseller.OrganizationAccount (ParentOrganizationId)
    go

SET IDENTITY_INSERT Reseller.OrganizationAccount ON;
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate)VALUES (3, 1, null, N'EATON CHINA', N'1-CDQO1B9', 0, N'EATON\E0651459', N'2022-06-02 14:09:02.060');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (212, 2, 3, N'China Regionall', null, 0, N'NAPA\E0092925', N'2023-08-11 12:00:38.267');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (213, 2, 3, N'Test_Organization_Without_AccountID', null, 0, N'EATON\E0651459', N'2023-08-11 12:02:11.303');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (214, 2, 3, N'With Organization ID', N'WITH-ID', 0, N'EATON\E0651459', N'2023-08-11 12:04:20.247');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (215, 1, null, N'EATON-US - Without AccountID', null, 0, N'EATON\E0651459', N'2023-08-30 08:16:12.103');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (216, 2, 215, N'Diego Test Org 1-a', N'', 0, N'NAPA\E0092925', N'2023-09-06 12:52:58.753');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (217, 2, 215, N'Diego Test Org 2', N'1-TEST02', 0, N'NAPA\E0092925', N'2023-09-06 12:53:41.200');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (218, 2, 215, N'Diego Test Org 3', N'TEST-03', 0, N'NAPA\E0092925', N'2023-09-06 12:54:31.580');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (219, 2, 215, N'kevin''s Organization Test1', N'HelloAccount91112345', 0, N'EATON\E0651459', N'2023-09-21 08:29:23.637');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (220, 2, 215, N'Joe BrownTest', N'HelloAccount', 0, N'EATON\E0651459', N'2023-09-12 18:02:49.243');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (221, 2, 215, N'Eaton Corp', N'Eaton', 0, N'NAPA\E0092925', N'2023-09-06 13:50:29.497');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (222, 2, 215, N'Diego Test 134', N'Test101010', 0, N'EATON\E0651459', N'2023-09-12 18:02:24.250');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (223, 2, 215, N'Diego Test 10', N'TEST10', 0, N'EATON\E0651459', N'2023-09-12 17:10:42.503');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (224, 2, 3, N'Test Organization 1 Diego China Reseller Change 1', N'null', 0, N'EATON\E0651459', N'2023-09-13 05:26:15.453');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (225, 2, 215, N'Diego Test Organization', N'Test', 0, N'EATON\E0651459', N'2023-09-14 12:36:49.467');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (226, 2, 215, N'Eaton Corp.', N'312123', 0, N'NAPA\E0092925', N'2023-09-14 12:45:08.863');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (227, 2, 3, N'Test Chinese Organization 1', null, 0, N'EATON\E0651459', N'2023-09-21 08:03:57.923');
INSERT INTO Reseller.OrganizationAccount (Id, OrganizationTypeId, ParentOrganizationId, Name, AccountID, IsDeleted, UserID, UpdateDate) VALUES (228, 2, 3, N'Test Chinese Organization 2', null, 0, N'EATON\E0651459', N'2023-09-21 08:05:49.070');
SET IDENTITY_INSERT Reseller.OrganizationAccount OFF;


create table Reseller.OrganizationAddress
(
    Id                    int identity
        constraint PK_OrganizationAddress
            primary key,
    OrganizationAccountId int                                           not null
        constraint FK_OrganizationAddress_OrganizationAccount
            references Reseller.OrganizationAccount,
    AddressTypeId         int                                           not null
        constraint FK_OrganizationAddress_AddressType
            references Reseller.AddressType,
    Address               nvarchar(250)                                 not null,
    Address2              nvarchar(250),
    Address3              nvarchar(250),
    City                  nvarchar(250)                                 not null,
    State                 nvarchar(250)                                 not null,
    CountryId             int                                           not null
        constraint FK_OrganizationAddress_Country
            references Reseller.Country,
    PostalCode            nvarchar(50)                                  not null,
    UserID                nvarchar(256)
        constraint DF__Organizat__UserI__113584D1 default suser_sname() not null,
    UpdateDate            datetime
        constraint DF__Organizat__Updat__1229A90A default getdate()     not null
)
    go

create index IX_OrganizationAddress_AddressType
    on Reseller.OrganizationAddress (AddressTypeId)
    go

create index IX_OrganizationAddress_Country
    on Reseller.OrganizationAddress (CountryId)
    go

create index IX_OrganizationAddress_OrganizationAccount
    on Reseller.OrganizationAddress (OrganizationAccountId)
    go

SET IDENTITY_INSERT Reseller.OrganizationAddress ON;
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate)VALUES (1, 3, 1, N'2 Lou Yang Rd Suhou Industrial Park', null, null, N'Suzhou Jiangsu', N'Jiangsu', 38, N'215121', N'EATON\E0651459', N'2022-05-20 08:57:42.263');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (168, 212, 1, N'Fake Address China', null, null, N'Beijing', N'Beijing', 38, N'00001', N'NAPA\E0092925', N'2023-03-01 13:51:21.870');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (169, 213, 1, N'Without Account ID Rd.', null, null, N'Chicago', N'IL', 1, N'54374', N'EATON\E0651459', N'2023-08-11 12:02:11.880');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (170, 214, 1, N'231 With Organization ID RD.', null, null, N'Chicago', N'IL', 1, N'54371', N'EATON\E0651459', N'2023-08-11 12:03:44.023');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (172, 215, 1, N'13100 E Michigan Ave', null, null, N'Galesburg', N'MI', 1, N'49053', N'EATON\E0651459', N'2023-08-30 08:18:07.397');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (173, 216, 1, N'123 Test 1 St', null, null, N'Chicago', N'IL', 1, N'60606', N'NAPA\E0092925', N'2023-09-06 12:52:58.780');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (174, 217, 1, N'123 Test 1 St.', null, null, N'Chicago', N'IL', 1, N'60606', N'NAPA\E0092925', N'2023-09-06 12:54:01.493');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (175, 218, 1, N'123 Test 1 St.', null, null, N'Chciago', N'IL', 1, N'60606', N'NAPA\E0092925', N'2023-09-06 12:54:54.707');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (176, 219, 1, N'123 anywhere lane5544', null, null, N'mattawan', N'mi', 1, N'49021', N'EATON\E0651459', N'2023-09-21 08:29:23.667');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (177, 220, 1, N'123 anywhere lane test23', null, null, N'mattawan', N'mi', 1, N'49021', N'EATON\E0651459', N'2023-09-12 18:02:49.357');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (178, 221, 1, N'123 michigan ave', null, null, N'Mattawan', N'MI', 1, N'49071', N'NAPA\E0092925', N'2023-09-06 13:50:29.593');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (179, 222, 1, N'Diego Test 4', null, null, N'Chicago', N'MI', 1, N'56322', N'EATON\E0651459', N'2023-09-12 18:02:24.370');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (180, 223, 1, N'Test 10 Street', null, null, N'Test 10 City', N'MI', 1, N'32222', N'EATON\E0651459', N'2023-09-12 17:10:42.857');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (181, 224, 1, N'Street 1', null, null, N'Chicago', N'IL', 1, N'345667', N'EATON\E0651459', N'2023-09-13 05:26:15.480');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (182, 225, 1, N'Test 1', null, null, N'Test1', N'MI', 21, N'5554411', N'EATON\E0651459', N'2023-09-14 12:36:49.683');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (183, 226, 1, N'61240 Valley View Blvd', null, null, N'Mattawan', N'MI', 1, N'49071', N'NAPA\E0092925', N'2023-09-14 12:45:08.947');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (184, 227, 1, N'Chinese Reseller 1', null, null, N'City China 1', N'State China 1', 38, N'123456', N'EATON\E0651459', N'2023-09-21 08:03:58.100');
INSERT INTO Reseller.OrganizationAddress (Id, OrganizationAccountId, AddressTypeId, Address, Address2, Address3, City, State, CountryId, PostalCode, UserID, UpdateDate) VALUES (185, 228, 1, N'Address Chinese Reseller 2', null, null, N'City China 2', N'State China 2', 38, N'123456', N'EATON\E0651459', N'2023-09-21 08:05:49.150');
SET IDENTITY_INSERT Reseller.OrganizationAddress OFF;


create table Reseller.OrganizationContact
(
    Id                    int identity
        constraint PK_OrganizationContact
            primary key,
    OrganizationAccountId int                                           not null
        constraint FK_OrganizationContact_OrganizationAccount
            references Reseller.OrganizationAccount,
    FirstName             nvarchar(250)                                 not null,
    LastName              nvarchar(250)                                 not null,
    OrganizationRoleId    int                                           not null
        constraint FK_OrganizationContact_OrganizationRole
            references Reseller.OrganizationRole,
    ContactTypeId         int                                           not null
        constraint FK_OrganizationContact_ContactType
            references Reseller.ContactType,
    EMail                 nvarchar(250)                                 not null,
    PhoneNumber           nvarchar(50)                                  not null,
    Login                 varchar(50),
    UserID                nvarchar(256)
        constraint DF__Organizat__UserI__7B4643B2 default suser_sname() not null,
    UpdateDate            datetime
        constraint DF__Organizat__Updat__7C3A67EB default getdate()     not null
)
    go

create index IX_OrganizationContact_ContactType
    on Reseller.OrganizationContact (ContactTypeId)
    go

create index IX_OrganizationContact_OrganizationAccount
    on Reseller.OrganizationContact (OrganizationAccountId)
    go

SET IDENTITY_INSERT Reseller.OrganizationContact ON;
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate)VALUES (1, 215, N'Kevin', N'Brown', 2, 2, N'kevinbrown@eaton.com', N'1-2691112222', N'NAPA\E0092925', N'EATON\E0651459', N'2023-09-21 08:29:23.697');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (148, 3, N'Diego', N'Claramount', 3, 1, N'diegoaclaramountruiz@eaton.com', N'420-775642233', N'EATON\E0651459', N'EATON\E0651459', N'2023-10-20 07:43:33.440');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (149, 215, N'Shubhi', N'Kamdar', 3, 1, N'ShubhiKamdar@eaton.com', N'555-12345687', N'EATON\E0675639', N'EATON\E0651459', N'2023-09-01 08:29:58.123');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (150, 3, N'Jeff', N'Broughton', 3, 1, N'JeffBroughton@eaton.com', N'555-95465471', N'EATON\C3040121', N'EATON\E0651459', N'2022-06-02 15:05:51.097');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (151, 3, N'Jeff', N'Patterson', 3, 1, N'JeffPatterson@eaton.com', N'555-54244257', N'EATON\C9913689', N'EATON\E0651459', N'2022-05-20 08:57:42.280');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (159, 215, N'Alex', N'Xendzov', 3, 1, N'AlexanderVXendzov@Eaton.com', N'555-95465471', N'NAPA\E0083258', N'EATON\E0651459', N'2023-08-31 12:54:35.760');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (186, 3, N'Susy', N'Rodriguez', 3, 1, N'susyrodriguez@eaton.com', N'555-12345687', N'EATON\E0494892', N'EATON\E0651459', N'2022-05-20 08:57:42.280');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (187, 3, N'Robert', N'Green', 3, 1, N'RobertGreen@Eaton.com', N'269-3423377', N'NAPA\E0005026', N'EATON\E0651459', N'2022-05-20 08:57:42.280');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (188, 3, N'Mayuri', N'Ihare', 3, 1, N'MayuriIhare@eaton.com', N'9850432608', N'EATON\E0694530', N'NAPA\E0083258', N'2022-05-23 09:23:26.400');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (190, 3, N'Yi', N'Shen', 3, 1, N'yishen@eaton.com', N'86 21 5200 0225', N'EATON\E0490700', N'NAPA\E0083258', N'2022-06-02 14:03:55.543');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (193, 3, N'Shen', N'Yi', 3, 1, N'ShenYi@eaton.com', N'', N'EATON\C3059128', N'NAPA\E0083258', N'2022-06-20 09:24:28.427');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (194, 3, N'Huang', N'Yongqi', 3, 1, N'HuangYongqi@eaton.com', N'', N'EATON\C3059133', N'NAPA\E0083258', N'2022-06-20 09:25:43.297');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (195, 3, N'Xuehai', N'Liang', 3, 1, N'XuehaiLiang1@eaton.com', N'', N'EATON\C3056806', N'NAPA\E0083258', N'2022-06-20 09:26:45.240');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (196, 212, N'Yi', N'Shen', 3, 2, N'yishen@eaton.com', N'86-13861768520', null, N'NAPA\E0092925', N'2023-03-01 13:51:21.873');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (197, 213, N'Without', N'AccountID', 1, 2, N'without_account@gmail.com', N'1-123456789', null, N'EATON\E0651459', N'2023-08-11 12:02:12.470');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (198, 214, N'With', N'Organization ID', 2, 2, N'with_organizationID@gmail.com', N'1-123456789', null, N'EATON\E0651459', N'2023-08-11 12:03:44.563');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (199, 216, N'Test Name 1', N'Test Last Name 1', 2, 2, N'testcontact1@gmail.com', N'1-123456789', null, N'NAPA\E0092925', N'2023-09-06 12:52:58.807');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (200, 217, N'Test Name 2', N'Test Last Name 2', 2, 2, N'testcontact2@gmail.com', N'1-123456789', null, N'NAPA\E0092925', N'2023-09-06 12:54:01.520');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (201, 218, N'Test First Name 3', N'Test Last Name 3', 1, 2, N'testcontact3@gmail.com', N'1-123456789', null, N'NAPA\E0092925', N'2023-09-06 12:54:54.733');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (202, 219, N'Kevin', N'Brown', 2, 2, N'kevinbrown@eaton.com', N'1-2691112222', null, N'EATON\E0651459', N'2023-09-08 12:12:23.620');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (203, 220, N'Kevin', N'Brown', 2, 2, N'kevinbrown@eaton.com', N'86-2631112222', null, N'NAPA\E0092925', N'2023-09-06 12:58:38.167');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (204, 221, N'Kevin', N'Brown', 2, 2, N'kevinbrown@eaton.com', N'1-1112223333', null, N'NAPA\E0092925', N'2023-09-06 13:50:29.790');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (205, 222, N'Test 4', N'Last Name Test 4', 2, 2, N'test4@cz.com', N'1-123445555', null, N'EATON\E0651459', N'2023-09-12 16:42:07.920');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (206, 223, N'Test 10 Name', N'Test 10 Lat Name', 3, 2, N'test10@gmail.com', N'1-12345667', null, N'EATON\E0651459', N'2023-09-12 17:10:43.210');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (207, 224, N'First Name Test 1', N'Last Name Test 1', 3, 2, N'test1@gmail.com', N'1-345333444', null, N'EATON\E0651459', N'2023-09-13 05:25:46.660');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (208, 225, N'Diego', N'Claramount', 1, 2, N'diego@test.com', N'1-111222333', null, N'EATON\E0651459', N'2023-09-14 12:36:49.843');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (209, 226, N'Kevin', N'Brown', 1, 2, N'kevinbrown@eaton.com', N'1-2692074000', null, N'NAPA\E0092925', N'2023-09-14 12:45:09.033');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (210, 227, N'FN China 1', N'LN China1', 2, 2, N'china1@gmail.com', N'86-123456789', null, N'EATON\E0651459', N'2023-09-21 08:03:58.243');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (211, 228, N'FN China 2', N'LN China 2', 2, 2, N'china2@gmail.com', N'86-123456789', null, N'EATON\E0651459', N'2023-09-21 08:05:49.230');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (212, 3, N'Andrew', N'Laskovy', 3, 1, N'AndrewMLaskovy@Eaton.com', N'1-555555555', N'NAPA\E9915438', N'EATON\E0651459', N'2023-10-16 11:35:36.107');
INSERT INTO Reseller.OrganizationContact (Id, OrganizationAccountId, FirstName, LastName, OrganizationRoleId, ContactTypeId, EMail, PhoneNumber, Login, UserID, UpdateDate) VALUES (213, 3, N'Patrik', N'Pavelka', 3, 1, N'patrikpavelka@eaton.com', N'420-775642233', N'EATON\C9001558', N'EATON\E0651459', N'2024-11-29 09:07:12.590');
SET IDENTITY_INSERT Reseller.OrganizationContact OFF;

create table Activation.SerialNumberRequestLog
(
    ID          int identity (101, 1)
        constraint PK_SerialNumberRequestLog
            primary key,
    OrderdDate  datetime                                                  not null,
    RequestedSN int                                                       not null,
    UserID      nvarchar(256)
        constraint DF_SerialNumberRequestLog_UserID default suser_sname() not null,
    UpdateDate  datetime
        constraint DF_SerialNumberRequestLog_UpdateDate default getdate() not null
)
    go


SET IDENTITY_INSERT Activation.SerialNumberRequestLog ON;
INSERT INTO Activation.SerialNumberRequestLog (ID, OrderdDate, RequestedSN, UserID, UpdateDate)VALUES (63647, N'2023-09-06 17:48:34.940', 1, N'NAPA\E0092925', N'2023-09-06 17:48:34.940');
INSERT INTO Activation.SerialNumberRequestLog (ID, OrderdDate, RequestedSN, UserID, UpdateDate) VALUES (63648, N'2023-09-06 17:49:47.873', 5, N'NAPA\E0092925', N'2023-09-06 17:49:47.873');
INSERT INTO Activation.SerialNumberRequestLog (ID, OrderdDate, RequestedSN, UserID, UpdateDate) VALUES (63649, N'2023-09-06 17:51:13.240', 5, N'NAPA\E0092925', N'2023-09-06 17:51:13.240');
SET IDENTITY_INSERT Activation.SerialNumberRequestLog OFF;

create table Activation.SerialNumberDetails
(
    ID                       int identity (1001, 1)
        constraint PK_SerialNumberDetails
            primary key,
    SerialNumberRequestLogID int                                       not null
        constraint FK_SerialNumberDetails_SerialNumberRequestLogID
            references Activation.SerialNumberRequestLog,
    SerialNumber             varchar(50)                               not null,
    AccountID                varchar(50)                               not null,
    Prefix                   varchar(20)                               not null,
    ProductNumber            nvarchar(50)                              not null,
    ExpirationDate           datetime                                  not null,
    IsTemp                   bit,
    IsValid                  bit                                       not null,
    UserID                   nvarchar(256)
        constraint DF_SerialNumberDetails_UserID default suser_sname() not null,
    UpdateDate               datetime
        constraint DF_SerialNumberDetails_UpdateDate default getdate() not null,
    LatestModificationDate   datetime,
    ResellerCode             varchar(50)  default ''                   not null,
    ResellerAccount          nvarchar(50) default ''                   not null,
    ResellerInvoice          nvarchar(50) default ''                   not null,
    ResellerInvoiceLastRenew nvarchar(50) default ''                   not null
)
    go

SET IDENTITY_INSERT Activation.SerialNumberDetails ON;
INSERT INTO Activation.SerialNumberDetails (ID, SerialNumberRequestLogID, SerialNumber, AccountID, Prefix, ProductNumber, ExpirationDate, IsTemp, IsValid, UserID, UpdateDate, LatestModificationDate, ResellerCode, ResellerAccount, ResellerInvoice, ResellerInvoiceLastRenew)VALUES (99625, 63647, N'RPR-C1E8UL-F76YX-1K44K-KJQU8-MS3J3-27H18', N'HelloAccount', N'RPR', N'RPR-TRNHEV-001', N'2024-09-06 00:00:00.000', 0, 1, N'NAPA\E0092925', N'2023-09-06 17:48:34.940', null, N'', N'', N'', N'');
INSERT INTO Activation.SerialNumberDetails (ID, SerialNumberRequestLogID, SerialNumber, AccountID, Prefix, ProductNumber, ExpirationDate, IsTemp, IsValid, UserID, UpdateDate, LatestModificationDate, ResellerCode, ResellerAccount, ResellerInvoice, ResellerInvoiceLastRenew) VALUES (99626, 63648, N'RPR-7K7F5N-6RUTQ-VX3ND-6A9KF-SK81J-324JS', N'HelloAccount', N'RPR', N'RPR-TRNHEV-001', N'2024-09-06 00:00:00.000', 0, 1, N'NAPA\E0092925', N'2023-09-06 17:49:47.873', null, N'', N'', N'', N'');
INSERT INTO Activation.SerialNumberDetails (ID, SerialNumberRequestLogID, SerialNumber, AccountID, Prefix, ProductNumber, ExpirationDate, IsTemp, IsValid, UserID, UpdateDate, LatestModificationDate, ResellerCode, ResellerAccount, ResellerInvoice, ResellerInvoiceLastRenew) VALUES (99627, 63648, N'RPR-V7FC5E-4U534-P65W1-J9TXH-32QPM-G7KKN', N'HelloAccount', N'RPR', N'RPR-TRNHEV-001', N'2024-09-06 00:00:00.000', 0, 1, N'NAPA\E0092925', N'2023-09-06 17:49:47.873', null, N'', N'', N'', N'');
INSERT INTO Activation.SerialNumberDetails (ID, SerialNumberRequestLogID, SerialNumber, AccountID, Prefix, ProductNumber, ExpirationDate, IsTemp, IsValid, UserID, UpdateDate, LatestModificationDate, ResellerCode, ResellerAccount, ResellerInvoice, ResellerInvoiceLastRenew) VALUES (99628, 63648, N'RPR-JCY6TY-TVPRH-7FQY3-LM7A3-DFJ32-97LD7', N'HelloAccount', N'RPR', N'RPR-TRNHEV-001', N'2024-09-06 00:00:00.000', 0, 1, N'NAPA\E0092925', N'2023-09-06 17:49:47.873', null, N'', N'', N'', N'');
INSERT INTO Activation.SerialNumberDetails (ID, SerialNumberRequestLogID, SerialNumber, AccountID, Prefix, ProductNumber, ExpirationDate, IsTemp, IsValid, UserID, UpdateDate, LatestModificationDate, ResellerCode, ResellerAccount, ResellerInvoice, ResellerInvoiceLastRenew) VALUES (99629, 63648, N'RPR-VYDGP8-L0NJE-P3KD2-7H326-4TDW6-D75J1', N'HelloAccount', N'RPR', N'RPR-TRNHEV-001', N'2024-09-06 00:00:00.000', 0, 1, N'NAPA\E0092925', N'2023-09-06 17:49:47.873', null, N'', N'', N'', N'');
INSERT INTO Activation.SerialNumberDetails (ID, SerialNumberRequestLogID, SerialNumber, AccountID, Prefix, ProductNumber, ExpirationDate, IsTemp, IsValid, UserID, UpdateDate, LatestModificationDate, ResellerCode, ResellerAccount, ResellerInvoice, ResellerInvoiceLastRenew) VALUES (99630, 63648, N'RPR-VC3PPX-XWERT-U1J32-4HLCV-7ERP4-K7K2G', N'HelloAccount', N'RPR', N'RPR-TRNHEV-001', N'2024-09-06 00:00:00.000', 0, 1, N'NAPA\E0092925', N'2023-09-06 17:49:47.873', null, N'', N'', N'', N'');
INSERT INTO Activation.SerialNumberDetails (ID, SerialNumberRequestLogID, SerialNumber, AccountID, Prefix, ProductNumber, ExpirationDate, IsTemp, IsValid, UserID, UpdateDate, LatestModificationDate, ResellerCode, ResellerAccount, ResellerInvoice, ResellerInvoiceLastRenew) VALUES (99631, 63649, N'RPR-YDK9WU-X0RE8-3LVSH-9HFPH-7TRJ3-27HW8', N'Eaton', N'RPR', N'RPR-TRNHEV-001', N'2024-09-06 00:00:00.000', 0, 1, N'NAPA\E0092925', N'2023-09-06 17:51:13.240', null, N'', N'', N'', N'');
INSERT INTO Activation.SerialNumberDetails (ID, SerialNumberRequestLogID, SerialNumber, AccountID, Prefix, ProductNumber, ExpirationDate, IsTemp, IsValid, UserID, UpdateDate, LatestModificationDate, ResellerCode, ResellerAccount, ResellerInvoice, ResellerInvoiceLastRenew) VALUES (99632, 63649, N'RPR-CWR8MQ-XC56J-32FE8-RMWMN-TC1CE-J7HMD', N'Eaton', N'RPR', N'RPR-TRNHEV-001', N'2024-09-06 00:00:00.000', 0, 1, N'NAPA\E0092925', N'2023-09-06 17:51:13.240', null, N'', N'', N'', N'');
INSERT INTO Activation.SerialNumberDetails (ID, SerialNumberRequestLogID, SerialNumber, AccountID, Prefix, ProductNumber, ExpirationDate, IsTemp, IsValid, UserID, UpdateDate, LatestModificationDate, ResellerCode, ResellerAccount, ResellerInvoice, ResellerInvoiceLastRenew) VALUES (99633, 63649, N'RPR-23JPXE-D9QDK-0L4ND-X66HT-L3PEM-N7HYU', N'Eaton', N'RPR', N'RPR-TRNHEV-001', N'2024-09-06 00:00:00.000', 0, 1, N'NAPA\E0092925', N'2023-09-06 17:51:13.240', null, N'', N'', N'', N'');
INSERT INTO Activation.SerialNumberDetails (ID, SerialNumberRequestLogID, SerialNumber, AccountID, Prefix, ProductNumber, ExpirationDate, IsTemp, IsValid, UserID, UpdateDate, LatestModificationDate, ResellerCode, ResellerAccount, ResellerInvoice, ResellerInvoiceLastRenew) VALUES (99634, 63649, N'RPR-NGDECX-1H32G-7LUX9-PXCKT-VR341-075CA', N'Eaton', N'RPR', N'RPR-TRNHEV-001', N'2024-09-06 00:00:00.000', 0, 1, N'NAPA\E0092925', N'2023-09-06 17:51:13.240', null, N'', N'', N'', N'');
INSERT INTO Activation.SerialNumberDetails (ID, SerialNumberRequestLogID, SerialNumber, AccountID, Prefix, ProductNumber, ExpirationDate, IsTemp, IsValid, UserID, UpdateDate, LatestModificationDate, ResellerCode, ResellerAccount, ResellerInvoice, ResellerInvoiceLastRenew) VALUES (99635, 63649, N'RPR-K68T00-YRGUD-3EK6G-GEJ32-QATQV-J7HAL', N'Eaton', N'RPR', N'RPR-TRNHEV-001', N'2024-09-06 00:00:00.000', 0, 1, N'NAPA\E0092925', N'2023-09-06 17:51:13.240', null, N'', N'', N'', N'');
SET IDENTITY_INSERT Activation.SerialNumberDetails OFF;


create table Activation.PackageDetails
(
    ID            int identity
        constraint PK_PackageDetails
            primary key,
    ProductNumber nvarchar(50)                              not null,
    ProductName   nvarchar(50)                              not null,
    Title         nvarchar(max)                             not null,
    Prefix        nvarchar(10)                              not null,
    Legacy        bit
        constraint DF_PackageDetails_Legacy default 0,
    LegacyPlus    bit
        constraint [DF_PackageDetails_Legacy+] default 0,
    [Current]     bit
    constraint DF_PackageDetails_Current default 0,
    Advanced      bit
        constraint DF_PackageDetails_Advanced default 0,
    Engineering   bit
        constraint DF_PackageDetails_Engineerin default 0,
    Hybrid        bit
        constraint DF_PackageDetails_Hybrid default 0,
    Flags         int
        constraint DF_PackageDetails_Flags default 0,
    Subscription  int                                       not null,
    UserID        nvarchar(50)
        constraint DF_PackageDetails_UserID default suser_sname(),
    UpdateDate    datetime
        constraint DF_PackageDetails_UpdateDate default getdate(),
    RoleKeyId     int
        constraint DF_PackageDetails_RoleKeyId default (-1) not null
)
    go


SET IDENTITY_INSERT Activation.PackageDetails ON;
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId)VALUES (1, N'PRO-TRNHEV-001', N'ServiceRanger Professional', N'ServiceRanger Professional with Eaton transmission and hybrid product support - 1 year subscription', N'PRO', 1, 1, 1, 1, 0, 1, 23, 12, N'EATON\E0642050', N'2024-02-02 07:01:28.963', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (3, N'PRO-TRNHEV-003', N'ServiceRanger Professional', N'ServiceRanger Professional with Eaton transmission and hybrid product support - 3 year subscription', N'PRO', 1, 1, 1, 1, 0, 1, 23, 36, N'srxheo', N'2012-11-01 12:23:14.027', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (5, N'PRO-TRNHEV-005', N'ServiceRanger Professional', N'ServiceRanger Professional with Eaton transmission and hybrid product support - 5 year subscription', N'PRO', 1, 1, 1, 1, 0, 1, 23, 60, N'srxheo', N'2012-11-01 12:24:24.807', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (7, N'PRO-TRNHEV-003-VOL', N'ServiceRanger Professional', N'ServiceRanger Professional with Eaton transmission and hybrid product support - 3 year subscription volume license', N'PRO', 1, 1, 1, 1, 0, 1, 23, 36, N'srxheo', N'2012-11-01 12:26:14.033', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (8, N'PRO-TRNHEV-005-VOL', N'ServiceRanger Professional', N'ServiceRanger Professional with Eaton transmission and hybrid product support - 5 year subscription volume license', N'PRO', 1, 1, 1, 1, 0, 1, 23, 60, N'srxheo', N'2012-11-01 12:27:16.950', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (9, N'PRO-TRN-001', N'ServiceRanger Professional', N'ServiceRanger Professional with Eaton transmission support - 1 year subscription', N'PRO', 1, 1, 1, 1, 0, 0, 7, 12, N'srxheo', N'2012-11-01 12:28:23.727', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (11, N'PRO-TRN-003', N'ServiceRanger Professional', N'ServiceRanger Professional with Eaton transmission support - 3 year subscription', N'PRO', 1, 1, 1, 1, 0, 0, 7, 36, N'srxheo', N'2012-11-01 12:29:28.510', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (14, N'PRO-TRN-005', N'ServiceRanger Professional', N'ServiceRanger Professional with Eaton transmission support - 5 year subscription', N'PRO', 1, 1, 1, 1, 0, 0, 7, 60, N'srxheo', N'2012-11-01 12:30:24.053', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (15, N'PRO-TRN-003-VOL', N'ServiceRanger Professional', N'ServiceRanger Professional with Eaton transmission support - 3 year subscription volume license', N'PRO', 1, 1, 1, 1, 0, 0, 7, 36, N'srxheo', N'2012-11-01 12:31:20.580', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (16, N'PRO-TRN-005-VOL', N'ServiceRanger Professional', N'ServiceRanger Professional with Eaton transmission support - 5 year subscription volume license', N'PRO', 1, 1, 1, 1, 0, 0, 7, 60, N'srxheo', N'2012-11-01 12:32:07.823', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (18, N'STD-TRNHEV-001', N'ServiceRanger Standard', N'ServiceRanger Standard with Eaton transmission and hybrid product support - 1 year subscription', N'STD', 1, 1, 1, 1, 0, 1, 23, 12, N'srxheo', N'2012-11-01 13:03:50.390', 3);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (20, N'STD-TRNHEV-003', N'ServiceRanger Standard', N'ServiceRanger Standard with Eaton transmission and hybrid product support - 3 year subscription', N'STD', 1, 1, 1, 1, 0, 1, 23, 36, N'srxheo', N'2012-11-01 13:04:43.777', 3);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (21, N'STD-TRNHEV-005', N'ServiceRanger Standard', N'ServiceRanger Standard with Eaton transmission and hybrid product support - 5 year subscription', N'STD', 1, 1, 1, 1, 0, 1, 23, 60, N'srxheo', N'2012-11-01 13:05:40.037', 3);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (22, N'STD-TRN-001', N'ServiceRanger Standard', N'ServiceRanger Standard with Eaton transmission support - 1 year subscription', N'STD', 1, 1, 1, 1, 0, 0, 7, 12, N'srxheo', N'2012-11-01 13:07:04.393', 3);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (23, N'STD-TRN-003', N'ServiceRanger Standard', N'ServiceRanger Standard with Eaton transmission support - 3 year subscription', N'STD', 1, 1, 1, 1, 0, 0, 7, 36, N'srxheo', N'2012-11-01 13:07:54.607', 3);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (25, N'STD-TRN-005', N'ServiceRanger Standard', N'ServiceRanger Standard with Eaton transmission support - 5 year subscription', N'STD', 1, 1, 1, 1, 0, 0, 7, 60, N'srxheo', N'2012-11-01 13:08:44.337', 3);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (26, N'STD-CRB-001', N'ServiceRanger Standard', N'ServiceRanger Standard for Certified Rebuilder - 1 year subscription', N'CRB', 1, 1, 1, 0, 0, 0, 3, 12, N'srxheo', N'2012-11-01 13:10:13.677', 3);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (27, N'STD-CRB-003', N'ServiceRanger Standard', N'ServiceRanger Standard for Certified Rebuilder - 3 year subscription', N'CRB', 1, 1, 1, 0, 0, 0, 3, 36, N'srxheo', N'2012-11-01 13:10:53.440', 3);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (28, N'STD-CRB-005', N'ServiceRanger Standard', N'ServiceRanger Standard for Certified Rebuilder - 5 year subscription', N'CRB', 1, 1, 1, 0, 0, 0, 3, 60, N'srxheo', N'2012-11-01 13:11:39.020', 3);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (29, N'BSC-001', N'ServiceRanger Basic', N'ServiceRanger Basic - 1 year subscription', N'BSC', 1, 0, 0, 0, 0, 0, 0, 12, N'srxheo', N'2012-11-01 13:12:34.850', 0);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (30, N'BSC-003', N'ServiceRanger Basic', N'ServiceRanger Basic - 3 year subscription', N'BSC', 1, 0, 0, 0, 0, 0, 0, 36, N'srxheo', N'2012-11-01 13:13:02.937', 0);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (31, N'BSC-005', N'ServiceRanger Basic', N'ServiceRanger Basic - 5 year subscription', N'BSC', 1, 0, 0, 0, 0, 0, 0, 60, N'srxheo', N'2012-11-01 13:13:23.423', 0);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (32, N'PRO-RFM-003', N'ServiceRanger Professional', N'ServiceRanger RFM - 3 year subscription', N'RFM', 1, 1, 1, 1, 0, 1, 23, 36, N'srxheo', N'2012-11-01 13:14:43.223', 30);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (33, N'PRO-OEM-001', N'ServiceRanger Professional', N'ServiceRanger OEM - 1 year subscription', N'OEM', 1, 1, 1, 1, 0, 1, 23, 12, N'srxheo', N'2012-11-01 13:15:46.830', 20);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (34, N'PRO-OEM-003', N'ServiceRanger Professional', N'ServiceRanger OEM - 3 year subscription', N'OEM', 1, 1, 1, 1, 0, 1, 23, 36, N'srxheo', N'2012-11-01 13:16:07.657', 20);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (35, N'PRO-ENG-001', N'ServiceRanger Professional', N'ServiceRanger Engineering - 1 year subscription', N'ENG', 1, 1, 1, 1, 1, 1, 31, 12, N'srxheo', N'2012-11-01 13:16:54.857', 222);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (36, N'PRO-ENG-003', N'ServiceRanger Professional', N'ServiceRanger Engineering - 3 year subscription', N'ENG', 1, 1, 1, 1, 1, 1, 31, 36, N'NAPA\E0083258', N'2013-04-16 17:59:11.883', 222);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (37, N'MFG-TRNHEV', N'ServiceRanger Manufacturing', N'ServiceRanger Manufacturing with Eaton transmission and hybrid product support - Unlimited year subscription', N'MFG', 1, 1, 1, 1, 0, 1, 23, 24, N'NAPA\E0083258', N'2013-09-18 10:25:07.240', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (38, N'BSC-TRNHEV-001', N'ServiceRanger Basic', N'ServiceRanger Basic OEM - 1 year subscription', N'BSC', 1, 1, 1, 1, 0, 1, 23, 12, N'NAPA\E0083258', N'2013-09-18 10:25:07.497', 0);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (39, N'BSC-TRNHEV-003', N'ServiceRanger Basic', N'ServiceRanger Basic OEM - 3 year subscription', N'BSC', 1, 1, 1, 1, 0, 1, 23, 36, N'NAPA\E0083258', N'2013-09-18 10:25:07.503', 0);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (40, N'BSC-TRNHEV-005', N'ServiceRanger Basic', N'ServiceRanger Basic OEM - 5 year subscription', N'BSC', 1, 1, 1, 1, 0, 1, 23, 60, N'NAPA\E0083258', N'2013-09-18 10:25:07.510', 0);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (49, N'MFG', N'ServiceRanger Manufacturing', N'ServiceRanger Manufacturing with Eaton transmission and hybrid product support - Unlimited year subscription', N'MFG', 1, 1, 1, 1, 0, 1, 23, 24, N'NAPA\C9996377', N'2013-09-16 19:20:10.997', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (53, N'ETN', N'Link Commander Eaton Edition ', N'This will have certain features (features have to be decided) with an duration of activation. Activation packages will be already created for this edition. ', N'ETN', 1, 1, 1, 1, 1, 1, 31, 24, N'NAPA\E0083258', N'2014-04-22 15:55:09.263', 222);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (54, N'NON', N'Link Commander Non Eaton Edition ', N'This will have limited features (features have to be decided) with an duration  of activation. Activation packages will be already created for this edition', N'NON', 1, 1, 1, 1, 1, 1, 31, 24, N'NAPA\E0083258', N'2014-04-22 15:57:22.967', 222);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (55, N'ADM', N'Link Commander Admin Edition ', N'This will be a special edition which the call center users can activate for a period of time.
For generating a serial number for this edition, Call center reps will have to create a license package with the features and time duration for which they want to activate and then generate the serial number.
Once the duration completes, user’s previous edition will be put back in use.', N'ADM', 1, 1, 1, 1, 1, 1, 31, 24, N'NAPA\E0083258', N'2014-04-22 15:58:14.747', 222);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (58, N'PRO-TRN-CRB', N'ServiceRanger Professional', N'ServiceRanger Professional - Legacy products 1 year', N'PRO', 1, 0, 0, 0, 0, 0, 0, 12, N'NAPA\E0083258', N'2015-06-17 16:43:00.367', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (59, N'PRO-TRN-IND', N'ServiceRanger Professional', N'ServiceRanger Professional - Legacy products (IND) - 1 year', N'PRO', 1, 0, 0, 0, 0, 0, 0, 12, N'NAPA\E0083258', N'2015-06-17 16:45:54.777', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (60, N'STD-TRN-IND', N'ServiceRanger Standard', N'ServiceRanger Standard - Legacy products - 1 year', N'STD', 1, 0, 0, 0, 0, 0, 0, 12, N'NAPA\E0083258', N'2015-06-17 16:48:15.650', 3);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (61, N'PRO-TRN-IND-003', N'ServiceRanger Professional', N'ServiceRanger Professional - Legacy products (IND) - 3 year', N'PRO', 1, 0, 0, 0, 0, 0, 0, 36, N'NAPA\E0083258', N'2018-03-23 10:47:24.243', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (62, N'PRO-TRN-CRB-003', N'ServiceRanger Professional', N'ServiceRanger Professional - Legacy products 3 year', N'PRO', 1, 0, 0, 0, 0, 0, 0, 36, N'NAPA\E0083258', N'2018-04-12 13:47:49.857', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (1058, N'PRO-TRNHEV-001 PLUS', N'ServiceRanger Professional PLUS', N'ServiceRanger Professional with Eaton transmission and hybrid product support - 1 year subscription', N'PRO', 1, 1, 1, 1, 0, 1, 23, 12, N'srxheo', N'2012-11-01 12:19:55.923', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (1059, N'PRO-TRNHEV-003 PLUS', N'ServiceRanger Professional PLUS', N'ServiceRanger Professional with Eaton transmission and hybrid product support - 3 year subscription', N'PRO', 1, 1, 1, 1, 0, 1, 23, 36, N'srxheo', N'2012-11-01 12:23:14.027', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (1061, N'EMB', N'Link Commander eMobility Edition ', N'This will have limited features based on license claims with a duration  of activation. Activation packages will be already created for this edition', N'EMB', 1, 1, 1, 1, 1, 1, 31, 24, N'NAPA\C9995801', N'2020-07-30 00:00:00.000', 222);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (2061, N'PRO-TRN-IND PLUS', N'ServiceRanger Professional PLUS', N'ServiceRanger Professional - Legacy products PLUS (IND) - 1 year', N'PRO', 1, 0, 0, 0, 0, 0, 0, 12, N'NAPA\E0083258', N'2021-01-08 19:17:27.077', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (2062, N'RBA-TRNHEV-001', N'ServiceRanger Basic', N'ServiceRanger Basic Regional organization - 1 year subscription', N'RBA', 1, 1, 1, 1, 0, 1, 23, 12, N'NAPA\E0092925', N'2022-05-20 15:11:51.903', 0);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (2063, N'RPR-TRNHEV-001', N'ServiceRanger Professional', N'ServiceRanger Professional  Regional with Eaton transmission and hybrid product support - 1 year subscription', N'RPR', 1, 1, 1, 1, 0, 1, 23, 12, N'NAPA\E0083258', N'2021-01-19 15:47:48.207', 5);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (2064, N'ROM-OEM-001', N'ServiceRanger Professional', N'ServiceRanger OEM Regional - 1 year subscription', N'ROM', 1, 1, 1, 1, 0, 1, 23, 12, N'NAPA\E0083258', N'2021-01-19 15:49:33.877', 20);
INSERT INTO Activation.PackageDetails (ID, ProductNumber, ProductName, Title, Prefix, Legacy, LegacyPlus, [Current], Advanced, Engineering, Hybrid, Flags, Subscription, UserID, UpdateDate, RoleKeyId) VALUES (3062, N'VCP-003', N'VCP Professional', N'VCP - 3 year subscription', N'VCP', 1, 1, 1, 1, 1, 1, 31, 36, N'NAPA\E0083258', N'2021-02-18 13:26:37.193', 20);
SET IDENTITY_INSERT Activation.PackageDetails OFF;


create table Reseller.OrganizationPackageDetails
(
    Id                    int identity
        constraint PK_OrganizationPackageDetails
            primary key,
    OrganizationAccountId int                                           not null
        constraint FK_OrganizationPackageDetails_OrganizationAccount
            references Reseller.OrganizationAccount,
    PackageDetailsId      int                                           not null
        constraint FK_OrganizationPackageDetails_PackageDetails
            references Activation.PackageDetails,
    SerialNumbersCount    int                                           not null,
    UserID                nvarchar(256)
        constraint DF__Organizat__UserI__2818EA29 default suser_sname() not null,
    UpdateDate            datetime
        constraint DF__Organizat__Updat__290D0E62 default getdate()     not null
)
    go

SET IDENTITY_INSERT Reseller.OrganizationPackageDetails ON;
INSERT INTO Reseller.OrganizationPackageDetails (Id, OrganizationAccountId, PackageDetailsId, SerialNumbersCount, UserID, UpdateDate)VALUES (2, 3, 2063, 1000, N'EATON\E0651459', N'2022-06-06 08:59:22.550');
INSERT INTO Reseller.OrganizationPackageDetails (Id, OrganizationAccountId, PackageDetailsId, SerialNumbersCount, UserID, UpdateDate) VALUES (3, 215, 2063, 500, N'EATON\E0651459', N'2023-08-30 08:42:53.457');
SET IDENTITY_INSERT Reseller.OrganizationPackageDetails OFF;

create table Reseller.InvoiceType
(
    Id          int                                                     not null
        constraint PK_InvoiceType
            primary key,
    Name        nvarchar(50)                                            not null
        constraint UQ_InvoiceType_Name
            unique,
    Description nvarchar(250)
        constraint DF__InvoiceTy__Descr__2DD1C37F default ''            not null,
    UserID      nvarchar(256)
        constraint DF__InvoiceTy__UserI__2EC5E7B8 default suser_sname() not null,
    UpdateDate  datetime
        constraint DF__InvoiceTy__Updat__2FBA0BF1 default getdate()     not null
)
    go

INSERT INTO Reseller.InvoiceType (Id, Name, Description, UserID, UpdateDate) VALUES (1, N'Create', N'Create new licenses', N'NAPA\E0083258', N'2022-03-28 12:02:30.740');
INSERT INTO Reseller.InvoiceType (Id, Name, Description, UserID, UpdateDate) VALUES (2, N'Transfer', N'Transfer licenses to different PC', N'NAPA\E0083258', N'2022-03-28 12:03:00.960');
INSERT INTO Reseller.InvoiceType (Id, Name, Description, UserID, UpdateDate) VALUES (3, N'Renew', N'Renew licenses expiration date', N'NAPA\E0083258', N'2022-03-28 12:03:29.837');
INSERT INTO Reseller.InvoiceType (Id, Name, Description, UserID, UpdateDate) VALUES (4, N'Terminate', N'Terminate licenses', N'NAPA\E0083258', N'2022-03-28 12:03:46.670');
INSERT INTO Reseller.InvoiceType (Id, Name, Description, UserID, UpdateDate) VALUES (5, N'Move', N'Move License from Organization to Organization', N'EATON\E0651459', N'2022-11-30 14:46:40.860');

create table Reseller.Invoice
(
    Id                    int identity
        constraint PK_Invoice
            primary key,
    OrganizationAccountId int                                          not null
        constraint FK_Invoice_OrganizationAccount
            references Reseller.OrganizationAccount,
    InvoiceTypeId         int                                          not null
        constraint FK_Invoice_InvoiceType
            references Reseller.InvoiceType,
    UserID                nvarchar(256)
        constraint DF__Invoice__UserID__3E082B48 default suser_sname() not null,
    UpdateDate            datetime
        constraint DF__Invoice__UpdateD__3EFC4F81 default getdate()    not null
)
    go

create index IX_Invoice_InvoiceType
    on Reseller.Invoice (InvoiceTypeId)
    go

create index IX_Invoice_OrganizationAccount
    on Reseller.Invoice (OrganizationAccountId)
    go

SET IDENTITY_INSERT Reseller.Invoice ON;
INSERT INTO Reseller.Invoice (Id, OrganizationAccountId, InvoiceTypeId, UserID, UpdateDate)VALUES (103, 220, 1, N'NAPA\E0092925', N'2023-09-06 13:48:25.323');
INSERT INTO Reseller.Invoice (Id, OrganizationAccountId, InvoiceTypeId, UserID, UpdateDate) VALUES (104, 220, 1, N'NAPA\E0092925', N'2023-09-06 13:49:36.970');
INSERT INTO Reseller.Invoice (Id, OrganizationAccountId, InvoiceTypeId, UserID, UpdateDate) VALUES (105, 221, 1, N'NAPA\E0092925', N'2023-09-06 13:51:02.363');
SET IDENTITY_INSERT Reseller.Invoice OFF;


create table Reseller.SubscriptionItem
(
    Id                    int identity
        constraint PK_SubscriptionItem
            primary key,
    InvoiceId             int                                           not null
        constraint FK_SubscriptionItem_Invoice
            references Reseller.Invoice
            on delete cascade,
    SerialNumberDetailsId int                                           not null
        constraint FK_SubscriptionItem_SerialNumberDetails
            references Activation.SerialNumberDetails
            on delete cascade,
    EMailSentCount        int
        constraint DF_SubscriptionItem_EMailSentCount default 0         not null,
    UserID                nvarchar(256)
        constraint DF__Subscript__UserI__43C1049E default suser_sname() not null,
    UpdateDate            datetime
        constraint DF__Subscript__Updat__44B528D7 default getdate()     not null
)
    go

SET IDENTITY_INSERT Reseller.SubscriptionItem ON;
INSERT INTO Reseller.SubscriptionItem (Id, InvoiceId, SerialNumberDetailsId, EMailSentCount, UserID, UpdateDate)VALUES (739, 103, 99625, 0, N'NAPA\E0092925', N'2023-09-06 13:48:25.560');
INSERT INTO Reseller.SubscriptionItem (Id, InvoiceId, SerialNumberDetailsId, EMailSentCount, UserID, UpdateDate) VALUES (740, 104, 99626, 0, N'NAPA\E0092925', N'2023-09-06 13:49:37.090');
INSERT INTO Reseller.SubscriptionItem (Id, InvoiceId, SerialNumberDetailsId, EMailSentCount, UserID, UpdateDate) VALUES (741, 104, 99627, 0, N'NAPA\E0092925', N'2023-09-06 13:49:37.197');
INSERT INTO Reseller.SubscriptionItem (Id, InvoiceId, SerialNumberDetailsId, EMailSentCount, UserID, UpdateDate) VALUES (742, 104, 99628, 0, N'NAPA\E0092925', N'2023-09-06 13:49:37.313');
INSERT INTO Reseller.SubscriptionItem (Id, InvoiceId, SerialNumberDetailsId, EMailSentCount, UserID, UpdateDate) VALUES (743, 104, 99629, 0, N'NAPA\E0092925', N'2023-09-06 13:49:37.420');
INSERT INTO Reseller.SubscriptionItem (Id, InvoiceId, SerialNumberDetailsId, EMailSentCount, UserID, UpdateDate) VALUES (744, 104, 99630, 0, N'NAPA\E0092925', N'2023-09-06 13:49:37.530');
INSERT INTO Reseller.SubscriptionItem (Id, InvoiceId, SerialNumberDetailsId, EMailSentCount, UserID, UpdateDate) VALUES (745, 105, 99631, 0, N'NAPA\E0092925', N'2023-09-06 13:51:02.483');
INSERT INTO Reseller.SubscriptionItem (Id, InvoiceId, SerialNumberDetailsId, EMailSentCount, UserID, UpdateDate) VALUES (746, 105, 99632, 0, N'NAPA\E0092925', N'2023-09-06 13:51:02.617');
INSERT INTO Reseller.SubscriptionItem (Id, InvoiceId, SerialNumberDetailsId, EMailSentCount, UserID, UpdateDate) VALUES (747, 105, 99633, 0, N'NAPA\E0092925', N'2023-09-06 13:51:02.793');
INSERT INTO Reseller.SubscriptionItem (Id, InvoiceId, SerialNumberDetailsId, EMailSentCount, UserID, UpdateDate) VALUES (748, 105, 99634, 0, N'NAPA\E0092925', N'2023-09-06 13:51:02.960');
INSERT INTO Reseller.SubscriptionItem (Id, InvoiceId, SerialNumberDetailsId, EMailSentCount, UserID, UpdateDate) VALUES (749, 105, 99635, 0, N'NAPA\E0092925', N'2023-09-06 13:51:03.083');
SET IDENTITY_INSERT Reseller.SubscriptionItem OFF;
