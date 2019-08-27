CREATE SCHEMA IF NOT EXISTS effort;
CREATE TABLE IF NOT EXISTS effort."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE SCHEMA IF NOT EXISTS effort;

CREATE TABLE effort.activity_type (
    "Id" bigserial NOT NULL,
    "Name" character varying(100) NOT NULL,
    "Code" character varying(100) NOT NULL,
    "Comment" character varying(250) NULL,
    "Deleted" boolean NOT NULL,
    CONSTRAINT "PK_activity_type" PRIMARY KEY ("Id")
);

CREATE TABLE effort.timesheet (
    "Id" bigserial NOT NULL,
    "Date" timestamp without time zone NOT NULL,
    "ActivityTypeId" bigint NOT NULL,
    "UserId" character varying(250) NOT NULL,
    "WorkItemId" bigint NOT NULL,
    "Duration" bigint NOT NULL,
    "Comment" character varying(250) NULL,
    "Deleted" boolean NOT NULL,
    "Inserted" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '2019-07-01 01:03:18.648292',
    "LastUpdated" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '2019-07-01 01:03:18.642669',
    CONSTRAINT "PK_timesheet" PRIMARY KEY ("Id")
);

INSERT INTO effort.activity_type ("Id", "Code", "Comment", "Deleted", "Name")
VALUES (1, 'analyze', 'Анализ задачи', FALSE, 'Анализ');
INSERT INTO effort.activity_type ("Id", "Code", "Comment", "Deleted", "Name")
VALUES (2, 'develop', 'Разработка', FALSE, 'Разработка');
INSERT INTO effort.activity_type ("Id", "Code", "Comment", "Deleted", "Name")
VALUES (3, 'test', 'Тестирование', FALSE, 'Тестирование');

INSERT INTO effort.timesheet ("Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId")
VALUES (1, 1, 'текст', TIMESTAMP '2019-07-01 01:03:18.65523', TRUE, 15, 'iloer', 11);

INSERT INTO effort.timesheet ("Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId")
VALUES (2, 1, 'текст', TIMESTAMP '2019-07-01 01:03:18.65696', FALSE, 15, 'iloer', 22);

INSERT INTO effort.timesheet ("Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId")
VALUES (3, 1, 'текст', TIMESTAMP '2019-07-01 01:03:18.656965', FALSE, 15, 'iloer', 33);

INSERT INTO effort.timesheet ("Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId")
VALUES (4, 2, 'текст', TIMESTAMP '2019-07-01 01:03:18.656965', TRUE, 15, 'iloer', 44);

INSERT INTO effort.timesheet ("Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId")
VALUES (5, 2, 'текст', TIMESTAMP '2019-07-01 01:03:18.656967', FALSE, 15, 'iloer', 55);

INSERT INTO effort.timesheet ("Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId")
VALUES (6, 2, 'текст', TIMESTAMP '2019-07-01 01:03:18.656967', FALSE, 15, 'iloer', 66);

INSERT INTO effort.timesheet ("Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId")
VALUES (7, 2, 'текст', TIMESTAMP '2019-07-01 01:03:18.656968', FALSE, 15, 'iloer', 77);

INSERT INTO effort.timesheet ("Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId")
VALUES (8, 3, 'текст', TIMESTAMP '2019-07-01 01:03:18.656968', TRUE, 15, 'iloer', 88);

INSERT INTO effort.timesheet ("Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId")
VALUES (9, 3, 'текст', TIMESTAMP '2019-07-01 01:03:18.656969', FALSE, 15, 'iloer', 99);

INSERT INTO effort.timesheet ("Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId")
VALUES (10, 3, 'текст', TIMESTAMP '2019-07-01 01:03:18.656969', FALSE, 15, 'iloer', 100);

INSERT INTO effort.timesheet ("Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId")
VALUES (11, 3, 'текст', TIMESTAMP '2019-07-01 01:03:18.65697', FALSE, 15, 'iloer', 110);

INSERT INTO effort.timesheet ("Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId")
VALUES (12, 3, 'текст', TIMESTAMP '2019-07-01 01:03:18.65697', FALSE, 15, 'iloer', 120);

INSERT INTO effort."__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20190630220319_InitialCreate', '2.2.4-servicing-10062');

