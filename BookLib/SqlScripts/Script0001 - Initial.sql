--BookLibDb
CREATE DATABASE BookLibDb;
-- Authors
CREATE TABLE IF NOT EXISTS "Authors" (
    "AuthorId" serial primary key,
    "AuthorName" varchar(30) not null,
    "Description" text
);

-- Publishers
CREATE TABLE IF NOT EXISTS "Publishers" (
    "PublisherId" serial primary key,
    "PublisherName" varchar(30) not null
);

-- Languages
CREATE TABLE IF NOT EXISTS "Languages" (
    "LanguageId" serial primary key,
    "Name" varchar(255) not null
);

-- Language
INSERT INTO "Languages" ("Name") VALUES
    ('Without language'),
    ('Russian'),
    ('English');

-- Genres
CREATE TABLE IF NOT EXISTS "Genres" (
    "GenreId" serial primary key,
    "Name" varchar(255) not null
);

-- Genre
INSERT INTO "Genres" ("Name") VALUES
    ('Without genre'),
    ('Action'),
    ('Adventure'),
    ('Comedy'),
    ('Drama'),
    ('Fantasy'),
    ('Horror'),
    ('Mystery'),
    ('Romance'),
    ('Science fiction'),
    ('Thriller'),
    ('Western');

-- Books
CREATE TABLE IF NOT EXISTS "Books" (
    "BookId" serial primary key,
    "Name" varchar(30) not null,
    "Genre" integer not null,
    "Language" integer not null,
    "AuthorId" bigint not null,
    "PublisherId" bigint not null,
    "PublishDate" date not null,
    "Pages" integer not null,
    FOREIGN KEY ("AuthorId") REFERENCES "Authors" ("AuthorId"),
    FOREIGN KEY ("PublisherId") REFERENCES "Publishers" ("PublisherId"),
    FOREIGN KEY ("Genre") REFERENCES "Genres" ("GenreId"),
    FOREIGN KEY ("Language") REFERENCES "Languages" ("LanguageId")
);
