-- Active: 1692714594092@@localhost@5432@book_lib_db
-- authors
INSERT INTO "authors" ("author_name", "description")
VALUES
    ('J.K. Rowling', 'British author best known for Harry Potter series'),
    ('George Orwell', 'English novelist and essayist, known for 1984'),
    ('Jane Austen', 'English novelist known for Pride and Prejudice'),
    ('F. Scott Fitzgerald', 'American novelist known for The Great Gatsby'),
    ('J.D. Salinger', 'American author known for The Catcher in the Rye'),
    ('Aldous Huxley', 'English writer known for Brave New World'),
    ('Virginia Woolf', 'English writer known for To the Lighthouse'),
    ('Herman Melville', 'American novelist known for Moby-Dick'),
    ('Leo Tolstoy', 'Russian author known for War and Peace'),
    ('Homer', 'Ancient Greek poet known for The Odyssey'),
    ('J.R.R. Tolkien', 'English writer known for The Lord of the Rings'),
    ('J.K. Rowling', 'British author known for Harry Potter series'),
    ('Fyodor Dostoevsky', 'Russian novelist known for Crime and Punishment'),
    ('Stephen King', 'American author known for The Shining'),
    ('J.R.R. Tolkien', 'English writer known for The Hobbit'),
    ('Suzanne Collins', 'American author known for The Hunger Games'),
    ('Paulo Coelho', 'Brazilian author known for The Alchemist'),
    ('Dan Brown', 'American author known for The Da Vinci Code'),
    ('Stieg Larsson', 'Swedish author known for The Girl with the Dragon Tattoo'),
    ('George R.R. Martin', 'American author known for A Game of Thrones');

-- publishers
INSERT INTO "publishers" ("publisher_name")
VALUES
    ('Bloomsbury Publishing'),
    ('Secker and Warburg'),
    ('Thomas Egerton'),
    ('Charles Scribner''s Sons'),
    ('Little, Brown and Company'),
    ('Chatto & Windus'),
    ('Hogarth Press'),
    ('Richard Bentley'),
    ('Russian Messenger'),
    ('Homer'),
    ('Allen & Unwin'),
    ('Bloomsbury Publishing'),
    ('The Russian Messenger'),
    ('Doubleday'),
    ('George Allen & Unwin'),
    ('Scholastic Corporation'),
    ('HarperOne'),
    ('Doubleday'),
    ('Norstedts förlag'),
    ('Bantam Books');

-- books
INSERT INTO "books" ("name", "genre", "language", "author_id", "publisher_id", "publish_date", "pages")
VALUES
    ('Harry Potter and the Sorcerer''s Stone', 'Fantasy', 'English', 1, 1, '1997-06-26', 309),
    ('1984', 'ScienceFiction', 'English', 2, 2, '1949-06-08', 328),
    ('Pride and Prejudice', 'Romance', 'English', 3, 3, '1813-01-28', 432),
    ('The Great Gatsby', 'Romance', 'English', 4, 4, '1925-04-10', 180),
    ('The Catcher in the Rye', 'Romance', 'English', 5, 5, '1951-07-16', 224),
    ('Brave New World', 'ScienceFiction', 'English', 6, 6, '1932-02-15', 311),
    ('To the Lighthouse', 'Romance', 'English', 7, 7, '1927-05-05', 209),
    ('Moby-Dick', 'Romance', 'English', 8, 8, '1851-10-18', 704),
    ('War and Peace', 'Romance', 'English', 9, 9, '1869-01-01', 1225),
    ('The Odyssey', 'Romance', 'English', 10, 10, '1614-08-01', 374),
    ('The Lord of the Rings', 'Fantasy', 'English', 11, 11, '1954-07-29', 1178),
    ('Harry Potter and the Chamber of Secrets', 'Fantasy', 'English', 1, 1, '1998-07-02', 341),
    ('Crime and Punishment', 'Romance', 'English', 13, 13, '1866-12-22', 671),
    ('The Shining', 'Horror', 'English', 14, 14, '1977-01-28', 447),
    ('The Hobbit', 'Fantasy', 'English', 15, 11, '1937-09-21', 310),
    ('The Hunger Games', 'Action', 'English', 16, 15, '2008-09-14', 374),
    ('The Alchemist', 'Action', 'English', 17, 16, '1988-01-01', 197),
    ('The Da Vinci Code', 'Mystery', 'English', 18, 17, '2003-03-18', 454),
    ('The Girl with the Dragon Tattoo', 'Mystery', 'English', 19, 18, '2005-08-01', 672),
    ('A Game of Thrones', 'Fantasy', 'English', 20, 19, '1996-08-01', 694);
