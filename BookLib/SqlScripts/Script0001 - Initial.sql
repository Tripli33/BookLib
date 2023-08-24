-- Active: 1692714594092@@localhost@5432@book_lib_db
--book_lib_db;
CREATE DATABASE book_lib_db;

CREATE TABLE IF NOT EXISTS "authors" (
    "author_id" serial primary key,
    "author_name" varchar(30) not null,
    "description" text
);

CREATE TABLE IF NOT EXISTS "publishers" (
    "publisher_id" serial primary key,
    "publisher_name" varchar(30) not null
);

CREATE TYPE genre_enum AS ENUM (
    'WithoutGenre',
    'Action',
    'Adventure',
    'Comedy',
    'Drama',
    'Fantasy',
    'Horror',
    'Mystery',
    'Romance',
    'ScienceFiction',
    'Thriller',
    'Western'
);

CREATE TYPE language_enum AS ENUM (
    'WithoutLanguage',
    'Russian',
    'English'
);

CREATE TABLE IF NOT EXISTS "books" (
    "book_id" serial primary key,
    "name" varchar(50) not null,
    "genre" genre_enum not null,
    "language" language_enum not null,
    "author_id" bigint not null,
    "publisher_id" bigint not null,
    "publish_date" date not null,
    "pages" integer not null,
    FOREIGN KEY ("author_id") REFERENCES "authors" ("author_id"),
    FOREIGN KEY ("publisher_id") REFERENCES "publishers" ("publisher_id")
);
