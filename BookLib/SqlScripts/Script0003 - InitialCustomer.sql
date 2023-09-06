-- Active: 1693557362053@@127.0.0.1@5432@book_lib_db
CREATE TABLE IF NOT EXISTS "customers" (
    "customer_id" serial PRIMARY KEY,
    "first_name" varchar(15) NOT NULL,
    "last_name" varchar(15) NOT NULL,
    "email" varchar(30) NOT NULL,
    "contact_number" varchar(20) NOT NULL,
    "address" varchar(50) NOT NULL,
    "created_date" date NOT NULL,
    "modified_date" date
);