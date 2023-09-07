-- Active: 1693557362053@@127.0.0.1@5432@book_lib_db
INSERT INTO "customer_books" ("customer_id", "book_id")
SELECT
    floor(random() * 10) + 1 AS "customer_id",
    floor(random() * 20) + 1 AS "book_id"
FROM generate_series(1, 50);