-- Active: 1693557362053@@127.0.0.1@5432@book_lib_db
CREATE TABLE IF NOT EXISTS "customer_books" (
    "customer_id" bigint not null,
    "book_id" bigint not null,
    FOREIGN KEY ("customer_id") REFERENCES "customers" ("customer_id"),
    FOREIGN KEY ("book_id") REFERENCES "books" ("book_id")
);