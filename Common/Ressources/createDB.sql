-- create user
CREATE ROLE "FindDBUser" WITH
	LOGIN
	SUPERUSER
	CREATEDB
	CREATEROLE
	INHERIT
	NOREPLICATION
	CONNECTION LIMIT -1
	PASSWORD 'Kappa123';

-- create database
CREATE DATABASE "FindDB"
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1;
	
-- grant access to FindDBUser
GRANT ALL ON DATABASE "FindDB" TO FindDBUser;

-- create table
CREATE TABLE public."tblFiles"
(
    idfiles serial NOT NULL,
    path text,
    content text,
    filename text,
    driveletter text,
    lastchange text,
	filetype text,
    PRIMARY KEY (idfiles)
);

-- grant access to FindDBUser
ALTER TABLE public."tblFiles"
    OWNER to FindDBUser;

GRANT ALL ON TABLE public."tblFiles" TO FindDBUser;


-- insert test values
INSERT INTO "tblFiles" ("path", "content", "filename", "driveletter", "lastchange", "filetype")
VALUES ('c:\daten\file1.pdf', 'ONE: Content von dem ersten dokument', 'file1.pdf', 'C', '09.07.2019', 'pdf');

INSERT INTO "tblFiles" ("path", "content", "filename", "driveletter", "lastchange", "filetype")
VALUES ('c:\daten\project\file2.pdf', 'TWO: Content von dem zweiten dokument', 'file2.pdf', 'C', '09.07.2021', 'doc');
