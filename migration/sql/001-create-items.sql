--liquibase formatted sql
 
-- Explicitly set the schema search path
SET search_path TO public;
 
-- changeset indre:1  
-- comment: Create items table
CREATE TABLE items (
    id SERIAL PRIMARY KEY,
    name VARCHAR NOT NULL
);
 
-- rollback DROP TABLE IF EXISTS items;