--liquibase formatted sql
 
-- Explicitly set the schema search path
SET search_path TO public;
 
-- changeset indre:2  
-- comment: Create orders table
CREATE TABLE orders (
    id SERIAL PRIMARY KEY,
    item_id INT NOT NULL REFERENCES items(id),
    user_id INT NOT NULL,
    created_at TIMESTAMP NOT NULL,
    is_paid BOOLEAN,
    is_completed BOOLEAN
);

-- rollback DROP TABLE IF EXISTS orders;